using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Filtros
{
    /*Tipos de filtros:
     * Autorização
     * Recurso
     * Ação
     * Exceção
     * Resultado
     */
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente=(LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            Cliente cliente = _loginCliente.BuscaClienteSessao();
            if (cliente == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home",new { area="Cliente"});
            }

        }
    }
}
