using MultiMarket.Libraries.Lang;
using MultiMarket.Libraries.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    [Table("EnderecosEntrega")]
    public class EnderecoEntrega
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        //[MaxLength(7,ErrorMessageResourceType =typeof(Mensagem),ErrorMessageResourceName ="MSG_E003")]
        public string Nome { get; set; }

        //[CepUnicoCliente]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string CEP { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Rua { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Cidade { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Bairro { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public int Numero { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public string Estado { get; set; }

        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
