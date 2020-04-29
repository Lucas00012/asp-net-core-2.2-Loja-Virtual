using AutoMapper;
using MultiMarket.Libraries.Json;
using MultiMarket.Models;
using MultiMarket.Models.ProdutoAgregador;
using Newtonsoft.Json;
using PagarMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.AutoMapper
{
    //NUGET-> AutoMapper.Extentions
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoItem>();
            CreateMap<Transaction, TransacaoPagarMe>();
            CreateMap<Cliente, EnderecoEntrega>()
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(orig=>0))
                .ForMember(dest=>dest.Nome,opt=>opt.MapFrom(orig=> string.Format("Endereço do cliente({0})", orig.Nome.ToUpper())));
            CreateMap<TransacaoPagarMe, Pedido>()
                .ForMember(dest=>dest.Id,opt=>opt.MapFrom(orig=>0))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(orig => int.Parse( orig.Customer.ExternalId)))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.FreteEmpresa, opt => opt.MapFrom(orig => "ECT - CORREIOS"))
                .ForMember(dest => dest.FormaPagamento, opt => opt.MapFrom(orig => orig.PaymentMethod == 0 ? TipoPagamentoConstant.CARTAO_CREDITO : TipoPagamentoConstant.BOLETO))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(orig => (decimal)orig.Amount / 100))
                .ForMember(dest => dest.DadosTransaction, opt => opt.MapFrom(orig => JsonConvert.SerializeObject(orig)))
                .ForMember(dest => dest.DataRegistro, opt => opt.MapFrom(orig => DateTime.Now));
            CreateMap<List<ProdutoItem>, Pedido>()
                .ForMember(dest => dest.DadosProdutos, opt => opt.MapFrom(orig => JsonConvert.SerializeObject(orig, new JsonSerializerSettings { 
                    ContractResolver = new UndoJsonIgnore<List<ProdutoItem>>(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                })));
            CreateMap<Pedido, PedidoSituacao>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(orig => 0))
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(orig => orig.Id))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(orig => DateTime.Now));
            CreateMap<Cliente, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Senha, opt => opt.Ignore());
            CreateMap<PedidoEstornoBoleto, BankAccount>()
                .ForMember(dest => dest.BankCode, opt => opt.MapFrom(orig => orig.BancoCodigo))
                .ForMember(dest => dest.Agencia, opt => opt.MapFrom(orig => orig.Agencia))
                .ForMember(dest => dest.AgenciaDv, opt => opt.MapFrom(orig => orig.AgenciaDV))
                .ForMember(dest => dest.Conta, opt => opt.MapFrom(orig => orig.Conta))
                .ForMember(dest => dest.ContaDv, opt => opt.MapFrom(orig => orig.ContaDV))
                .ForMember(dest => dest.LegalName, opt => opt.MapFrom(orig => orig.Nome))
                .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(orig => orig.CPF));

        }
    }
}
