﻿using MultiMarket.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    public class PedidoEstornoCartao
    {
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Motivo { get; set; }
        public string FormaPagamento { get; set; } = TipoPagamentoConstant.CARTAO_CREDITO;
    }
}
