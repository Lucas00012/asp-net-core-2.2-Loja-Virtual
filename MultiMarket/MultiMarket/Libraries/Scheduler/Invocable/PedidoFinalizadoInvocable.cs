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
    public class PedidoFinalizadoInvocable : IInvocable
    {
        private IPedidoRepository _pedidoRepository;
        private IPedidoSituacaoRepository _pedidoSituacaoRepository;
        private IMapper _mapper;
        public PedidoFinalizadoInvocable(IPedidoRepository pedidoRepository, IPedidoSituacaoRepository pedidoSituacaoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoSituacaoRepository = pedidoSituacaoRepository;
            _mapper = mapper;
        }
        public Task Invoke()
        {
            List<Pedido> pedidos = _pedidoRepository.ObterPedidosPorSituacao(PedidoSituacaoConstant.ENTREGUE);
            foreach(Pedido pedido in pedidos)
            {
                if (DateTime.Now >= pedido.DataRegistro.AddDays(7))
                {
                    pedido.Situacao = PedidoSituacaoConstant.FINALIZADO;
                    pedido.DataRegistro = DateTime.Now;

                    PedidoSituacao pedidoSituacao = _mapper.Map<Pedido, PedidoSituacao>(pedido);
                    pedidoSituacao.Situacao = PedidoSituacaoConstant.FINALIZADO;

                    _pedidoRepository.Atualizar(pedido);
                    _pedidoSituacaoRepository.Cadastrar(pedidoSituacao);
                }
            }
            return Task.CompletedTask;
        }
    }
}
