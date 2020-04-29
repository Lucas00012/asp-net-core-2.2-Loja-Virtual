using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Validacao
{
    public class CepUnicoClienteAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LoginCliente _loginCliente = (LoginCliente)validationContext.GetService(typeof(LoginCliente));
            IEnderecoEntregaRepository _enderecoEntregaRepository= (IEnderecoEntregaRepository)validationContext.GetService(typeof(IEnderecoEntregaRepository));

            string CEP = value.ToString();

            Cliente cliente = _loginCliente.BuscaClienteSessao();
            EnderecoEntrega endereco = _enderecoEntregaRepository.ObterEndereco(a => a.CEP == CEP && a.ClienteId==cliente.Id);

            if (CEP == cliente.CEP || endereco != null) return new ValidationResult("O CEP já está cadastrado");
            return ValidationResult.Success;
        }
    }
}
