using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    public class Imagem
    {
        [Key]
        public int Id { get; set; }
        public string Caminho { get; set; }

        public int? ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto ProdutoImagem { get; set; }
    }
}
