using MultiMarket.Libraries.Lang;
using MultiMarket.Libraries.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models.ViewModel
{
    public class PedidoVisualizacaoViewModel
    {
        public Pedido pedido { get; set; }
        public PedidoEstornoBoleto estornoBoleto { get; set; }
        public PedidoEstornoCartao estornoCartao { get; set; }
        public DadosDevolucao Devolucao { get; set; }
        public DevolucaoRejeitar RejeitarDevolucao { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string NFE { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string CodRastreamento { get; set; }
    }
}
