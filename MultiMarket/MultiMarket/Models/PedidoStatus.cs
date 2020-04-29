using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    public class PedidoStatus
    {
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public bool Existe { get; set; } = false;
        public string Cor { get; set; } = "";
    }
}
