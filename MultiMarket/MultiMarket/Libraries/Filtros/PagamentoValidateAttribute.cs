using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiMarket.Libraries.Cookie;
using MultiMarket.Libraries.Frete;
using MultiMarket.Libraries.Texto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Filtros
{
    public class PagamentoValidateAttribute : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            GerenciadorCookie _cookie = (GerenciadorCookie)context.HttpContext.RequestServices.GetService(typeof(GerenciadorCookie));
            CookieValorPrazoFrete _cookieFrete = (CookieValorPrazoFrete)context.HttpContext.RequestServices.GetService(typeof(CookieValorPrazoFrete));
            CarrinhoCompra.CarrinhoCompra _cookieCarrinho = (CarrinhoCompra.CarrinhoCompra)context.HttpContext.RequestServices.GetService(typeof(CarrinhoCompra.CarrinhoCompra));

            Controller controller = (Controller)context.Controller;

            string CookieCarrinho = _cookie.Consultar("Carrinho.Compras");
            string CEP = _cookie.Consultar("Carrinho.CEP", false);
            string TipoFrete = _cookie.Consultar("Carrinho.TipoFrete", false);

            if (CookieCarrinho == null)
            {
                controller.TempData["MSG_E"] = "Não há itens no carrinho! Adicione produtos para prosseguir";
                context.Result = new RedirectToActionResult("Index", "CarrinhoCompra", null);
            }
            if(CEP==null || TipoFrete == null)
            {
                controller.TempData["MSG_E"] = "Calcule o frete para prosseguir com o pagamento!";
                context.Result = new RedirectToActionResult("Index", "CarrinhoCompra", null);
            }
            List<Models.Correios.Frete> CookieFrete = _cookieFrete.Consultar();
            string CarrinhoId = HashGenerator.CreateMD5(JsonConvert.SerializeObject(_cookieCarrinho.Consultar()));

            Models.Correios.Frete frete = CookieFrete.Where(a => a.CarrinhoId == CarrinhoId && a.CEP == CEP).FirstOrDefault();
            if (frete == null)
            {
                _cookie.Excluir("Carrinho.CEP");
                _cookie.Excluir("Carrinho.TipoFrete");
                _cookieFrete.RemoverTodos();

                controller.TempData["MSG_E"] = "Alteração no carrinho detectada! Calculeo frete novamente para prosseguir";
                context.Result = new RedirectToActionResult("Index", "CarrinhoCompra", null);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
