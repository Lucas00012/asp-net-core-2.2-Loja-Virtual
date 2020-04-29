using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Filtros
{
    public class ValidateRequestAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //EXECUTADO DEPOIS DA REQUISICAO PASSAR PELO CONTROLADOR
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //EXECUTADO ANTES DA REQUISICAO PASSAR PELO CONTROLADOR

            string Referer = context.HttpContext.Request.Headers["referer"].ToString();
            if (string.IsNullOrEmpty(Referer))
            {
                context.Result = new ContentResult() { Content = "Acesso negado!" };
            }

            Uri MyUri = new Uri(Referer);
            string Host = context.HttpContext.Request.Host.Host;
            string UserAddresHost = MyUri.Host;

            if (UserAddresHost != Host)
            {
                context.Result = new ContentResult() { Content = "Acesso negado!" };
            }

        }
    }
}
