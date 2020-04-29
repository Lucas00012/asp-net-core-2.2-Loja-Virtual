using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models.Cartao
{
    public class Parcela
    {
        public decimal Total { get; set; }
        public decimal ParcelaValor { get; set; }
        public int ParcelaQuantidade { get; set; }
        public bool Juros { get; set; }
    }
}
