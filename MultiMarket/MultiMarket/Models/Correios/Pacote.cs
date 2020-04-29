using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models.Correios
{
    public class Pacote
    {
        public int? Altura { get; set; } = 0;
        public int? Comprimento { get; set; } = 0;
        public int? Largura { get; set; } = 0;
        public decimal? Peso { get; set; } = 0;
    }
}
