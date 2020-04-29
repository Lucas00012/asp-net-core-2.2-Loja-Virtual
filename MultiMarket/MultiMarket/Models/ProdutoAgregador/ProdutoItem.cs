using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models.ProdutoAgregador
{
    public class ProdutoItem:Produto
    {
        //ARMAZENA A QUANTIDADE QUE O USUARIO PRETENDE COMPRAR
        public int QuantidadeCarrinhoProduto { get; set; }
    }
}
