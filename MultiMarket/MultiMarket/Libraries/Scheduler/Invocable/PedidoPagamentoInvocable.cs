using Coravel.Invocable;
using MultiMarket.Libraries.Pagamento;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PagarMe;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Libraries.Json;
using Microsoft.Extensions.Logging;

namespace MultiMarket.Libraries.Scheduler.Invocable
{
    public class PedidoPagamentoInvocable : IInvocable
    {
        private GerenciarPagarMe _gerenciarPagarMe;
        private IPedidoRepository _pedidoRepository;
        private IPedidoSituacaoRepository _pedidoSituacaoRepository;
        private IProdutoRepository _produtoRepository;
        private IMapper _mapper;
        private ILogger<PedidoPagamentoInvocable> _logger;
        public PedidoPagamentoInvocable(ILogger<PedidoPagamentoInvocable> logger, GerenciarPagarMe gerenciarPagarMe,IPedidoRepository pedidoRepository,IMapper mapper,IPedidoSituacaoRepository pedidoSituacaoRepository, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _gerenciarPagarMe = gerenciarPagarMe;
            _pedidoRepository = pedidoRepository;
            _pedidoSituacaoRepository = pedidoSituacaoRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
        public Task Invoke()
        {
            _logger.LogInformation("--- SCHEDULER PedidoPagamentoInvocable (inicio) ---");
            List<Pedido> pedidos = _pedidoRepository.ObterPedidosPorSituacao(PedidoSituacaoConstant.AGUARDANDO_PAGAMENTO);
            foreach(var pedido in pedidos)
            {
                string Situacao = null;
                var transaction = _gerenciarPagarMe.ObterTransacao(pedido.TransactionId);
                if(transaction.Status==TransactionStatus.WaitingPayment && transaction.PaymentMethod == PaymentMethod.Boleto && transaction.BoletoExpirationDate<DateTime.Now)
                {
                    Situacao = PedidoSituacaoConstant.PAGAMENTO_NAO_REALIZADO;
                    _produtoRepository.DevolverEstoque(pedido);
                }
                else if (transaction.Status == TransactionStatus.Refused)
                {
                    Situacao = PedidoSituacaoConstant.PAGAMENTO_REJEITADO;
                    _produtoRepository.DevolverEstoque(pedido);
                }
                else if (transaction.Status == TransactionStatus.Authorized || transaction.Status == TransactionStatus.Paid)
                {
                    Situacao = PedidoSituacaoConstant.PAGAMENTO_APROVADO;
                }
                else if (transaction.Status == TransactionStatus.Refunded)
                {
                    Situacao = PedidoSituacaoConstant.ESTORNO;
                    _produtoRepository.DevolverEstoque(pedido);
                }
                if (Situacao != null)
                {
                    //TransacaoPagarMe transacaoPagarMe = _mapper.Map<Transaction, TransacaoPagarMe>(transaction);

                    PedidoSituacao pedidoSituacao = new PedidoSituacao();
                    pedidoSituacao.PedidoId = pedido.Id;
                    pedidoSituacao.Situacao = Situacao;
                    pedidoSituacao.Data = transaction.DateUpdated.Value;

                    _pedidoSituacaoRepository.Cadastrar(pedidoSituacao);
                    pedido.Situacao = Situacao;
                    _pedidoRepository.Atualizar(pedido);
                }
            }
            _logger.LogInformation("--- SCHEDULER PedidoPagamentoInvocable (fim) ---");
            return Task.CompletedTask;
        }
    }
}
