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
    public class Categoria
    {
        [Key]
        [Display(Name ="Código")]
        public int Id { get; set; }

        [NomeUnicoCategoria]
        [Required(ErrorMessageResourceType =typeof(Mensagem),ErrorMessageResourceName ="MSG_E001")]
        [MinLength(4,ErrorMessageResourceType =typeof(Mensagem),ErrorMessageResourceName ="MSG_E002")]
        public string Nome { get; set; }

        //URL AMIGAVEL
        [SlugUnicoCategoria]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Slug { get; set; }

        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }

        //ASSUME O VALOR GUARDADO EM CategoriaPaiId COMO UM REGISTRO NO BANCO E O BUSCA COM BASE NESSE VALOR

        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }


    }
}
