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
    public class ColaboradorAutorizacaoAttribute : Attribute,IAuthorizationFilter
    {
        private string _tipoColaborador;
        private LoginColaborador _loginColaborador;
        public ColaboradorAutorizacaoAttribute(string tipoColaborador="C")
        {
            _tipoColaborador = tipoColaborador;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));
            Colaborador colaborador = _loginColaborador.BuscaSessaoColaborador();
            if (colaborador == null)
            {
                //JA QUE O FILTRO NAO RETORNA UM IActionResult DEVEMOS USAR O context.Result
                context.Result = new RedirectToActionResult("Login","Home",null);
            }
            else
            {
                if(_tipoColaborador=="G" && colaborador.Tipo == "C")
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
