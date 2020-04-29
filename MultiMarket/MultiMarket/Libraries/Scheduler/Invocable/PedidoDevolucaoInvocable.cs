using AutoMapper;
using Coravel.Invocable;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Scheduler.Invocable
{
    public class PedidoDevolucaoInvocable : IInvocable
    {
        private IPedidoRepository _pedidoRepository;
        private IPedidoSituacaoRepository _pedidoSituacaoRepository;
        private IMapper _mapper;
        public PedidoDevolucaoInvocable(IPedidoRepository pedidoRepository, IPedidoSituacaoRepository pedidoSituacaoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoSituacaoRepository = pedidoSituacaoRepository;
            _mapper = mapper;
        }
        public Task Invoke()
        {
            List<Pedido> pedidos = _pedidoRepository.ObterPedidosPorSituacao(PedidoSituacaoConstant.DEVOLVER);
            foreach (Pedido pedido in pedidos)
            {
                try
                {
                    var result = new Correios.NET.Services().GetPackageTracking(pedido.FreteCodRastreamento);
                    if (result.IsDelivered)
                    {
                        pedido.Situacao = PedidoSituacaoConstant.DEVOLVER_ENTREGUE;
                        pedido.DataRegistro = result.DeliveryDate.Value;

                        PedidoSituacao pedidoSituacao = _mapper.Map<Pedido, PedidoSituacao>(pedido);
                        pedidoSituacao.Situacao = PedidoSituacaoConstant.DEVOLVER_ENTREGUE;
                        pedidoSituacao.Data = result.DeliveryDate.Value;

                        _pedidoRepository.Atualizar(pedido);
                        _pedidoSituacaoRepository.Cadastrar(pedidoSituacao);


                    }
                }
                catch
                {

                }
            }
            return Task.CompletedTask;
        }
    }
}



