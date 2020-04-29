using MultiMarket.Models;
using MultiMarket.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Validacao
{
    //OBS: F12 ENTRA DENTRO DA CLASSE E PERMITE VER SEUS METODOS
    public class EmailUnicoColaboradorAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //O VALIDATION CONTEXT SERVE PARA INJETAR DEPENDENCIAS
            IColaboradorRepository _colaboradorRepository = (IColaboradorRepository)validationContext.GetService(typeof(IColaboradorRepository));
            //O value EQUIVALE AO VALOR DO CAMPO ONDE É INSERIDO O ATRIBUTO
            string Email = value==null?"":(value.ToString()).Trim();


            //RETORNA TODO O OBJETO NO QUAL A PROPRIEDADE PERTENCE 
            Colaborador ObjColaborador = (Colaborador)validationContext.ObjectInstance;

            List<Colaborador> colaboradores = _colaboradorRepository.ObterColaboradoresEmail(Email);

            if (colaboradores.Count() > 1) return new ValidationResult("E-mail já existente");
            if (colaboradores.Count() == 1 && ObjColaborador.Id != colaboradores[0].Id) return new ValidationResult("E-mail já existente");
            return ValidationResult.Success;
        }
    }
}
