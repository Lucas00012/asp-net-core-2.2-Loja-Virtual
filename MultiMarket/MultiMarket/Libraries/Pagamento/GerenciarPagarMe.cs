using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Models.Cartao;
using MultiMarket.Models.Correios;
using MultiMarket.Models.ProdutoAgregador;
using PagarMe;

namespace MultiMarket.Libraries.Pagamento
{
    public class GerenciarPagarMe
    {
        private IConfiguration _conf;
        private LoginCliente _loginCliente;
        private IMapper _mapper;
        public GerenciarPagarMe(IConfiguration configuration,LoginCliente loginCliente,IMapper mapper)
        {
            _loginCliente = loginCliente;
            _conf = configuration;
            _mapper = mapper;
        }
       
        public Transaction GerarBoleto(decimal valor, EnderecoEntrega enderecoEntrega,ValorPrazoFrete frete,List<ProdutoItem> produtos)
        {

            Cliente cliente = _loginCliente.BuscaClienteSessao();

            PagarMeService.DefaultApiKey = _conf.GetValue<string>("PagarMe:APIKey");
            PagarMeService.DefaultEncryptionKey = _conf.GetValue<string>("PagarMe:EncriptionKey");

            Transaction transaction = new Transaction();

            transaction.Amount = (int)(valor*100);
            transaction.PaymentMethod = PaymentMethod.Boleto;
            transaction.BoletoExpirationDate = DateTime.Now.AddDays(2);
            transaction.Customer = new Customer
            {
                ExternalId = cliente.Id.ToString(),
                Name = cliente.Nome,
                Type = CustomerType.Individual,
                Country = "br",
                Email = cliente.Email,
                Documents = new[]
                    {
                new Document{
                    Type = DocumentType.Cpf,
                    Number = RemoverMascara(cliente.CPF)
                },
            },
                PhoneNumbers = new string[]
                {
                "+55"+RemoverMascara(cliente.Telefone),
                },
                Birthday = cliente.Nascimento.ToString("yyyy-MM-dd")
            };
            transaction.Shipping = new Shipping
            {
                Name = enderecoEntrega.Nome,
                Fee = (int)( frete.Valor * 100),
                DeliveryDate = DateTime.Now.AddDays(3 + frete.Prazo).ToString("yyyy-MM-dd"),
                Expedited = false,
                Address = new Address()
                {
                    Country = "br",
                    State = enderecoEntrega.Estado,
                    City = enderecoEntrega.Cidade,
                    Neighborhood = enderecoEntrega.Bairro,
                    Street = enderecoEntrega.Rua,
                    Complementary = enderecoEntrega.Complemento == null ? "" : enderecoEntrega.Complemento,
                    StreetNumber = enderecoEntrega.Numero.ToString(),
                    Zipcode = RemoverMascara(enderecoEntrega.CEP)
                }
            };
            transaction.Item = new Item[produtos.Count];

            for (int i = 0; i < produtos.Count; i++)
            {
                transaction.Item[i] = new Item()
                {
                    Id = produtos[i].Id.ToString(),
                    Title = produtos[i].Nome,
                    Quantity = produtos[i].QuantidadeCarrinhoProduto,
                    Tangible = true,
                    UnitPrice = (int)(produtos[i].Valor * 100)
                };
            }
            transaction.Save();
            transaction.Customer.Gender = cliente.Sexo == "M" ? Gender.Male : Gender.Female;
            return transaction;
            
        }
        public Transaction GerarPagCartaoCredito(Parcela parcela,Cartao cartao, List<ProdutoItem> produtos, EnderecoEntrega enderecoEntrega,ValorPrazoFrete frete)
        {
            Cliente cliente = _loginCliente.BuscaClienteSessao();

            PagarMeService.DefaultApiKey = _conf.GetValue<string>("PagarMe:APIKey");
            PagarMeService.DefaultEncryptionKey = _conf.GetValue<string>("PagarMe:EncriptionKey");

            Card card = new Card()
            {
                Number = cartao.Numero,
                Cvv = cartao.CVV,
                ExpirationDate = cartao.VencimentoMM+cartao.VencimentoYY,
                HolderName = cartao.Nome,
            };

            card.Save();

            Transaction transaction = new Transaction();
            transaction.PaymentMethod = PaymentMethod.CreditCard;

            transaction.Card = new Card
            {
                Id = card.Id
            };

            transaction.Customer = new Customer
            {
                ExternalId = cliente.Id.ToString(),
                Name = cliente.Nome,
                Type = CustomerType.Individual,
                Country = "br",
                Email = cliente.Email,
                Documents = new[]
                {
                    new Document{
                      Type = DocumentType.Cpf,
                      Number = RemoverMascara(cliente.CPF)
                    },
                },
                PhoneNumbers = new string[]
                {
                    "+55"+RemoverMascara(cliente.Telefone),
                },
                Birthday = cliente.Nascimento.ToString("yyyy-MM-dd")
            };

            transaction.Billing = new Billing
            {
                Name = cliente.Nome,
                Address = new Address()
                {
                    Country = "br",
                    State = cliente.Estado,
                    City = cliente.Cidade,
                    Neighborhood = cliente.Bairro,
                    Street = cliente.Rua,
                    Complementary= cliente.Complemento,
                    StreetNumber = cliente.Numero.ToString(),
                    Zipcode = RemoverMascara(cliente.CEP)
                }
            };

            var Today = DateTime.Now;

            transaction.Shipping = new Shipping
            {
                Name = enderecoEntrega.Nome,
                Fee = (int)(frete.Valor*100),
                DeliveryDate = Today.AddDays(3+frete.Prazo).ToString("yyyy-MM-dd"),
                Expedited = false,
                Address = new Address()
                {
                    Country = "br",
                    State = enderecoEntrega.Estado,
                    City = enderecoEntrega.Cidade,
                    Neighborhood = enderecoEntrega.Bairro,
                    Street = enderecoEntrega.Rua,
                    Complementary= enderecoEntrega.Complemento == null ? "" : enderecoEntrega.Complemento,
                    StreetNumber = enderecoEntrega.Numero.ToString(),
                    Zipcode = RemoverMascara( enderecoEntrega.CEP)
                }
            };

            transaction.Item = new Item[produtos.Count];

            for (int i=0;i<produtos.Count;i++)
            {
                transaction.Item[i] = new Item()
                {
                    Id = produtos[i].Id.ToString(),
                    Title=produtos[i].Nome,
                    Quantity=produtos[i].QuantidadeCarrinhoProduto,
                    Tangible=true,
                    UnitPrice=(int)(produtos[i].Valor*100)
                };
            }
            transaction.Amount = (int)(parcela.Total*100);
            transaction.Installments = parcela.ParcelaQuantidade;
            transaction.Save();
            transaction.Customer.Gender = cliente.Sexo == "M" ? Gender.Male : Gender.Female;
            return transaction;
        }
        private string RemoverMascara(string a)
        {
            return a.Replace(" ", "").Replace(")", "").Replace("(", "").Replace("-", "");
        }
        
        //1x = 1000 2x = 1050 3x = 1120
        public List<Parcela> CalcularParcelaProduto(decimal valor)
        {
            int ParcelasIsentas = _conf.GetValue<int>("PagarMe:ParcelasTotaisIsentas");
            int ParcelasMaximas = _conf.GetValue<int>("PagarMe:ParcelasMaximas");
            decimal Taxa= _conf.GetValue<decimal>("PagarMe:TaxaPorParcela");

            List<Parcela> parcelas = new List<Parcela>();

            for(int parcela = 1; parcela <= ParcelasMaximas; parcela++)
            {
                Parcela ParcelaProduto = new Parcela();
                ParcelaProduto.Total = valor;
                ParcelaProduto.ParcelaQuantidade = parcela;
                ParcelaProduto.Juros = parcela <= ParcelasIsentas ? false : true;

                for (int i = ParcelasIsentas; i < parcela; i++) ParcelaProduto.Total *= 1 + Taxa;

                ParcelaProduto.ParcelaValor = Math.Round(ParcelaProduto.Total / ParcelaProduto.ParcelaQuantidade,2);
                parcelas.Add(ParcelaProduto);
            }

            return parcelas;
        }
        public Transaction ObterTransacao(string transactionId)
        {
            PagarMeService.DefaultApiKey = _conf.GetValue<string>("PagarMe:APIKey");

            var transaction = PagarMeService.GetDefaultService().Transactions.Find(transactionId);
            return transaction;
        }

        public void EstornoCartao(string transactionId)
        {
            PagarMeService.DefaultApiKey = _conf.GetValue<string>("PagarMe:APIKey");
            var transaction = PagarMeService.GetDefaultService().Transactions.Find(transactionId);
            transaction.Refund();
        }
        public bool EstornoBoleto(string transactionId,PedidoEstornoBoleto estornoBoleto)
        {
            try
            {
                PagarMeService.DefaultApiKey = _conf.GetValue<string>("PagarMe:APIKey");
                var transaction = PagarMeService.GetDefaultService().Transactions.Find(transactionId);
                BankAccount bankAccount = _mapper.Map<PedidoEstornoBoleto, BankAccount>(estornoBoleto);
                transaction.Refund(bankAccount);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }

}