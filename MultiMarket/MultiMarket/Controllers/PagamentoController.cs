using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiMarket.Libraries.CarrinhoCompra;
using MultiMarket.Libraries.Cookie;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Frete;
using MultiMarket.Libraries.Login;
using MultiMarket.Libraries.Pagamento;
using MultiMarket.Libraries.Texto;
using MultiMarket.Models;
using MultiMarket.Models.Cartao;
using MultiMarket.Models.Correios;
using MultiMarket.Models.PacoteCorreio;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Models.ViewModel;
using MultiMarket.Repositories.Contracts;
using Newtonsoft.Json;
using PagarMe;

namespace MultiMarket.Controllers
{
    [PagamentoValidate]
    [ClienteAutorizacao]
    public class PagamentoController : BaseController
    {
        private IEnderecoEntregaRepository _enderecoEntrega;
        private LoginCliente _loginCliente;
        private GerenciarPagarMe _gerenciarPagarMe;
        private IPedidoRepository _pedidoRepository;
        private IPedidoSituacaoRepository _pedidoSituacaoRepository;
        public PagamentoController(IPedidoSituacaoRepository pedidoSituacaoRepository, IPedidoRepository pedidoRepository, GerenciarPagarMe gerenciarPagarMe,LoginCliente loginCliente, IEnderecoEntregaRepository enderecoEntrega, GerenciadorCookie cookie, CarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository, IMapper mapper, WSCalcularFrete frete, WSCalcularPacote pacote, CookieValorPrazoFrete cookieValorPrazoFrete) : base(carrinhoCompra, produtoRepository, mapper, frete, pacote, cookieValorPrazoFrete,cookie)
        {
            _pedidoSituacaoRepository = pedidoSituacaoRepository;
            _pedidoRepository = pedidoRepository;
            _enderecoEntrega = enderecoEntrega;
            _loginCliente = loginCliente;
            _gerenciarPagarMe=gerenciarPagarMe;
        }
        public IActionResult Index()
        {

            ViewBag.Frete = ObterFrete();
            ViewBag.Produtos = CarregarProdutoDB();

            List<Parcela> parcelas = _gerenciarPagarMe.CalcularParcelaProduto(ObterValorTotal(ViewBag.Produtos,ViewBag.Frete));
            ViewBag.Parcelas = parcelas.Select(a => new SelectListItem(string.Format("{0}x de {1} {2}",a.ParcelaQuantidade,a.ParcelaValor,a.Juros==false?"s/ juros":"c/ juros"),a.ParcelaQuantidade.ToString()));
            return View();

        }
        [HttpPost]
        public IActionResult Index([FromForm]PagamentoViewModel pagamento)
        {
            if (ModelState.IsValid)
            {
                List<ProdutoItem> produtos = CarregarProdutoDB();
                EnderecoEntrega endereco = ObterEndereco();
                ValorPrazoFrete frete = ObterFrete();
                try
                {
                    Parcela parcela = _gerenciarPagarMe.CalcularParcelaProduto(ObterValorTotal(produtos, frete)).Where(a => a.ParcelaQuantidade == pagamento.Parcelas).First();
                    Transaction pagarMe = _gerenciarPagarMe.GerarPagCartaoCredito(parcela, pagamento.CartaoCredito, produtos, endereco, frete);

                    Pedido pedido= SalvarPedido(produtos, pagarMe);

                    return new RedirectToActionResult("Index", "Pedido", new { id = pedido.Id });
                }
                catch (PagarMeException e)
                {
                    TempData["MSG_E"] = MontarMensagensExceptionsPagarme(e);
                    return RedirectToAction(nameof(Index));
                }

            }
            return Index();
        }

        private Pedido SalvarPedido(List<ProdutoItem> produtos, Transaction pagarMe)
        {
            TransacaoPagarMe transacao = _mapper.Map<Transaction, TransacaoPagarMe>(pagarMe);

            Pedido pedido = _mapper.Map<TransacaoPagarMe, Pedido>(transacao);
            pedido = _mapper.Map(produtos, pedido);
            pedido.Situacao = PedidoSituacaoConstant.AGUARDANDO_PAGAMENTO;

            _pedidoRepository.Cadastrar(pedido);

            PedidoSituacao pedidoSituacao = _mapper.Map<Pedido, PedidoSituacao>(pedido);
            pedidoSituacao.Situacao = PedidoSituacaoConstant.AGUARDANDO_PAGAMENTO;

            _pedidoSituacaoRepository.Cadastrar(pedidoSituacao);

            BaixaEstoque(produtos);
            _cookie.Excluir("Carrinho.Compras");
            _cookie.Excluir("Carrinho.ValorPrazoFrete");

            return pedido;
        }

        private void BaixaEstoque(List<ProdutoItem> produtos)
        {
            foreach (ProdutoItem produto in produtos)
            {
                Produto produtoDB = _produtoRepository.ObterProduto(produto.Id);
                produtoDB.Quantidade -= produto.QuantidadeCarrinhoProduto;
                _produtoRepository.Atualizar(produtoDB);
            }
        }

        public IActionResult Boleto()
        {
            List<ProdutoItem> produtos = CarregarProdutoDB();
            EnderecoEntrega endereco = ObterEndereco();
            ValorPrazoFrete frete = ObterFrete();
            decimal Total = ObterValorTotal(produtos, frete);

            try
            {
                Transaction transaction = _gerenciarPagarMe.GerarBoleto(Total,endereco,frete,produtos);
                Pedido pedido= SalvarPedido(produtos, transaction);
                return new RedirectToActionResult("Index", "Pedido", new { id = pedido.Id });
            }
            catch(PagarMeException e)
            {
                TempData["MSG_E"] = MontarMensagensExceptionsPagarme(e);
                return RedirectToAction(nameof(Index));
            }
        }
        private EnderecoEntrega ObterEndereco()
        {
            Cliente cliente = _loginCliente.BuscaClienteSessao();
            string CEP = _cookie.Consultar("Carrinho.CEP", false);

            if (cliente.CEP.Replace("-", "") == CEP)
            {
                EnderecoEntrega endereco = new EnderecoEntrega();
                endereco=_mapper.Map<EnderecoEntrega>(cliente);
                return endereco;
            }
            return _enderecoEntrega.ObterEndereco(a => a.CEP.Replace("-", "") == CEP && a.ClienteId == cliente.Id);
        }
        private ValorPrazoFrete ObterFrete()
        {
            string CEP = _cookie.Consultar("Carrinho.CEP", false);
            string TipoFrete= _cookie.Consultar("Carrinho.TipoFrete", false);

            if (TipoFrete == "SEDEX") TipoFrete = TipoFreteConstant.Sedex;
            else if (TipoFrete == "PAC") TipoFrete = TipoFreteConstant.PAC;
            else if (TipoFrete == "SEDEX10") TipoFrete = TipoFreteConstant.Sedex10;

            Frete frete = _cookieValorPrazoFrete.Consultar().Where(a => a.CEP == CEP && a.CarrinhoId == HashGenerator.CreateMD5(JsonConvert.SerializeObject(_carrinhoCompra.Consultar()))).FirstOrDefault();
            return frete.Valores.Where(a => a.TipoFrete == TipoFrete).FirstOrDefault();
        }
        private decimal ObterValorTotal(List<ProdutoItem> produtos,ValorPrazoFrete frete)
        {
            decimal Total = (decimal)frete.Valor;
            foreach(ProdutoItem produto in produtos)
            {
                Total += (decimal)produto.Valor * produto.QuantidadeCarrinhoProduto;
            }
            return Total;
        }
        private string MontarMensagensExceptionsPagarme(PagarMeException e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ERRO:</br>");
            foreach (var erro in e.Error.Errors)
            {
                sb.Append(erro.Message + "</br>");
            }
            return sb.ToString();
        }
    }
}