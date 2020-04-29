using Microsoft.AspNetCore.Mvc;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Component
{
    public class StatusViewComponent:ViewComponent
    {
        List<PedidoStatus> statusDefault=new List<PedidoStatus>();
        List<PedidoStatus> statusPaymentUnfinished = new List<PedidoStatus>();
        List<PedidoStatus> statusReturned = new List<PedidoStatus>();
        List<PedidoStatus> statusDevolution = new List<PedidoStatus>();
        public StatusViewComponent()
        {
            statusDefault.Add(new PedidoStatus { Status= PedidoSituacaoConstant.AGUARDANDO_PAGAMENTO});
            statusDefault.Add(new PedidoStatus { Status = PedidoSituacaoConstant.PAGAMENTO_APROVADO});
            statusDefault.Add(new PedidoStatus { Status = PedidoSituacaoConstant.NF_EMITIDA });
            statusDefault.Add(new PedidoStatus { Status = PedidoSituacaoConstant.EM_TRANSPORTE});
            statusDefault.Add(new PedidoStatus { Status = PedidoSituacaoConstant.ENTREGUE});
            statusDefault.Add(new PedidoStatus { Status = PedidoSituacaoConstant.FINALIZADO});

            statusPaymentUnfinished.Add(new PedidoStatus { Status = PedidoSituacaoConstant.AGUARDANDO_PAGAMENTO });
            statusPaymentUnfinished.Add(new PedidoStatus { Status = PedidoSituacaoConstant.PAGAMENTO_NAO_REALIZADO,Cor="red" });

            statusReturned.Add(new PedidoStatus { Status = PedidoSituacaoConstant.AGUARDANDO_PAGAMENTO });
            statusReturned.Add(new PedidoStatus { Status = PedidoSituacaoConstant.PAGAMENTO_APROVADO });
            statusReturned.Add(new PedidoStatus { Status = PedidoSituacaoConstant.NF_EMITIDA });
            statusReturned.Add(new PedidoStatus { Status = PedidoSituacaoConstant.ESTORNO,Cor="red" });

            statusDevolution.Add(new PedidoStatus { Status = PedidoSituacaoConstant.DEVOLVER });
            statusDevolution.Add(new PedidoStatus { Status = PedidoSituacaoConstant.DEVOLVER_ENTREGUE });
            statusDevolution.Add(new PedidoStatus { Status = PedidoSituacaoConstant.DEVOLUCAO_ACEITA });
            statusDevolution.Add(new PedidoStatus { Status = PedidoSituacaoConstant.DEVOLVER_ESTORNO });
            statusDevolution.Add(new PedidoStatus { Status = PedidoSituacaoConstant.DEVOLUCAO_REJEITADA,Cor="red" });
        }
        public async Task<IViewComponentResult> InvokeAsync(Pedido pedido)
        {
            List<PedidoSituacao> situacoes = pedido.PedidoSituacoes;
            List<PedidoStatus> statusFinal = statusDefault;

            if (pedido.Situacao == PedidoSituacaoConstant.PAGAMENTO_NAO_REALIZADO) statusFinal = statusPaymentUnfinished;
            else if (pedido.Situacao == PedidoSituacaoConstant.ESTORNO) { 
                statusFinal = statusReturned;
                PedidoStatus pedidoStatus = statusFinal.Where(a => a.Status == PedidoSituacaoConstant.NF_EMITIDA).FirstOrDefault();
                PedidoSituacao pedidoSituacao = situacoes.Where(a => a.Situacao == PedidoSituacaoConstant.NF_EMITIDA).FirstOrDefault();
                if (pedidoSituacao == null) statusFinal.Remove(pedidoStatus);
            }
            else if (statusDevolution.Where(a => a.Status == pedido.Situacao).FirstOrDefault() != null)
            {
                statusFinal = statusDevolution;
                if (pedido.Situacao == PedidoSituacaoConstant.DEVOLUCAO_REJEITADA)
                {
                    statusFinal.Remove(statusFinal[2]);
                    statusFinal.Remove(statusFinal[2]);
                }
                else
                {
                    statusFinal.Remove(statusFinal[4]);
                }
            }


            foreach(PedidoSituacao situacao in situacoes)
            {
                PedidoStatus pedidoStatus = statusFinal.Where(a => a.Status == situacao.Situacao).FirstOrDefault();
                if ( pedidoStatus!= null)
                {
                    pedidoStatus.Data = situacao.Data;
                    pedidoStatus.Existe = true;
                }
            }
            return View(statusFinal);
        }
    }
}
