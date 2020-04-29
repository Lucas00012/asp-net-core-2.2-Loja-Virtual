using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models.Correios
{
    public class Frete
    {
        public string CEP;
        public string CarrinhoId;
        public List<ValorPrazoFrete> Valores;
    }
}
