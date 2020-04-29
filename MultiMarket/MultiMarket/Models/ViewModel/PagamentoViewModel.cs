using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models.ViewModel
{
    public class PagamentoViewModel
    {
        public Cartao.Cartao CartaoCredito { get; set; }
        public int Parcelas { get; set; }
    }
}
