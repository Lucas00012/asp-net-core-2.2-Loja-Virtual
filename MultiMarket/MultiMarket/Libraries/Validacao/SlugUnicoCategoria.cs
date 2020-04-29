using MultiMarket.Models;
using MultiMarket.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Validacao
{
    public class SlugUnicoCategoria : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ICategoriaRepository categoriaRepository = (ICategoriaRepository)validationContext.GetService(typeof(ICategoriaRepository));
            Categoria categoria = (Categoria)validationContext.ObjectInstance;
            if (categoria.Id == 0)
            {
                if (categoriaRepository.ObterCategoriaNoTracking(a => a.Slug == categoria.Slug) == null) return ValidationResult.Success;
            }
            else
            {
                Categoria categoriaDB = categoriaRepository.ObterCategoriaNoTracking(a => a.Slug == categoria.Slug);
                if (categoriaDB == null || categoriaDB.Id == categoria.Id) return ValidationResult.Success;
            }
            return new ValidationResult("Esse slug já existe!");
        }
    }
}
