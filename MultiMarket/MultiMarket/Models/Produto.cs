using MultiMarket.Libraries.Lang;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [Display(Name ="Código")]
        public int Id { get; set; }

        [JsonIgnore]
        [Required(ErrorMessageResourceType =typeof(Mensagem),ErrorMessageResourceName ="MSG_E001")]
        public string Nome { get; set; }

        [Display(Name="Descrição")]
        [JsonIgnore]
        public string Descricao { get; set; }

        [JsonIgnore]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Display(Name="Preço (R$)")]
        public decimal? Valor { get; set; }

        [JsonIgnore]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(0,100000,ErrorMessageResourceType =typeof(Mensagem),ErrorMessageResourceName ="MSG_E006")]
        public int? Quantidade { get; set; }

        //CORREIOS - CALCULAR FRETE

        [JsonIgnore]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(0.001, 30, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E006")]
        [Display(Name = "Peso (kg)")]
        public decimal? Peso { get; set; }

        [JsonIgnore]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(11, 105, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E006")]
        [Display(Name = "Largura (cm)")]
        public int? Largura { get; set; }

        [JsonIgnore]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(2, 105, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E006")]
        [Display(Name = "Altura (cm)")]
        public int? Altura { get; set; }

        [JsonIgnore]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [Range(16, 105, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E006")]
        [Display(Name="Comprimento (cm)")]
        public int? Comprimento { get; set; }

        //CHAVE ESTRANGEIRA -> CATEGORIA
        [JsonIgnore]
        [Display(Name="Categoria")]
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        public int? CategoriaId { get; set; }

        [JsonIgnore]
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        [JsonIgnore]
        public virtual List<Imagem> ImagemProduto { get; set; }

    }
}
