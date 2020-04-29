using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;
        public ValidateAntiForgeryTokenMiddleware(RequestDelegate request, IAntiforgery antiforgery)
        {
            _next = request;
            _antiforgery = antiforgery;
        }
        //ESSA VARIAVEL RECEBE O CONTEXTO HTTP DO SITE
        public async Task InvokeAsync(HttpContext context)
        {
            //OBTEM O CABEÇALHO DA REQUISIÇAO
            var Cabeçalho = context.Request.Headers["x-requested-with"];
            bool Ajax = (Cabeçalho == "XMLHttpRequest")?true:false;
            //SE A REQUISICAO DO USUARIO FOR UM METODO POST O TOKEN E ATIVADO
            //Files.Count==1 verifica se há 1 arquivo na requisição
            if (HttpMethods.IsPost(context.Request.Method) && !(context.Request.Form.Files.Count == 1 && Ajax))
            {
                await _antiforgery.ValidateRequestAsync(context);
            }
            await _next(context);
        }
    }
}
