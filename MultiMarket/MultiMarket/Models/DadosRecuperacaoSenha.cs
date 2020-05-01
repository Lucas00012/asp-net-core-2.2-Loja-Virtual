using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    public class DadosRecuperacaoSenha
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Chave { get; set; }
        public int? ClienteId { get; set; }
        public int? ColaboradorId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("ColaboradorId")]
        public virtual Colaborador Colaborador { get; set; }
    }
}
