#pragma checksum "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0575f03121ed5eef473e267a3f22a4bc054f556e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pedido_Index), @"mvc.1.0.view", @"/Views/Pedido/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pedido/Index.cshtml", typeof(AspNetCore.Views_Pedido_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
using MultiMarket.Models;

#line default
#line hidden
#line 3 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
using MultiMarket.Models.ProdutoAgregador;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0575f03121ed5eef473e267a3f22a4bc054f556e", @"/Views/Pedido/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ed1d286704faafb66f6c362a6279f19f91eff5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Pedido_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MultiMarket.Models.Pedido>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(147, 97, true);
            WriteLiteral("<br />\r\n<br />\r\n<div class=\"container text-center\" style=\"font-family:Arial\">\r\n    <h1>Pedido nº ");
            EndContext();
            BeginContext(245, 8, false);
#line 10 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
             Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(253, 1, true);
            WriteLiteral("-");
            EndContext();
            BeginContext(255, 19, false);
#line 10 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
                       Write(Model.TransactionId);

#line default
#line hidden
            EndContext();
            BeginContext(274, 203, true);
            WriteLiteral("</h1>\r\n    <table class=\"table table-bordered\">\r\n        <thead>\r\n            <tr>\r\n                <th>Nome</th>\r\n                <th>Quantidade</th>\r\n                <th>Valor</th>\r\n            </tr>\r\n");
            EndContext();
#line 18 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
             foreach (ProdutoItem produto in ViewBag.Produtos)
            {

#line default
#line hidden
            BeginContext(556, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(603, 12, false);
#line 21 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
                   Write(produto.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(615, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(647, 33, false);
#line 22 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
                   Write(produto.QuantidadeCarrinhoProduto);

#line default
#line hidden
            EndContext();
            BeginContext(680, 34, true);
            WriteLiteral("</td>\r\n                    <td>R$ ");
            EndContext();
            BeginContext(715, 13, false);
#line 23 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
                      Write(produto.Valor);

#line default
#line hidden
            EndContext();
            BeginContext(728, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 25 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(773, 32, true);
            WriteLiteral("        </thead>\r\n        <tr>\r\n");
            EndContext();
#line 28 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
              
                decimal ValorFrete = (decimal)ViewBag.Transacao.Shipping.Fee / 100;
            

#line default
#line hidden
            BeginContext(921, 59, true);
            WriteLiteral("            <td colspan=\"2\">Frete</td>\r\n            <td>R$ ");
            EndContext();
            BeginContext(981, 27, false);
#line 32 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
              Write(ValorFrete.ToString("0.00"));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 143, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <th colspan=\"2\" style=\"font-size:20px;\">TOTAL</th>\r\n            <td style=\"font-size:20px;\">R$ ");
            EndContext();
            BeginContext(1152, 16, false);
#line 36 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
                                      Write(Model.ValorTotal);

#line default
#line hidden
            EndContext();
            BeginContext(1168, 38, true);
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n    </table>\r\n");
            EndContext();
#line 40 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
     if (Model.FormaPagamento == TipoPagamentoConstant.BOLETO)
    {

#line default
#line hidden
            BeginContext(1277, 223, true);
            WriteLiteral("        <br />\r\n        <br />\r\n        <h3>Boleto</h3>\r\n        <!--OBS: O ambiente de teste do PAGARME não gera um link de boleto! A propriedade BoletoUrl redireciona para a página principal da empresa-->\r\n        <iframe");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1500, "\"", 1534, 1);
#line 46 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
WriteAttributeValue("", 1506, ViewBag.Transacao.BoletoUrl, 1506, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1535, 102, true);
            WriteLiteral(" style=\"width: 100%; min-height: 400px; border: 1px solid #CCC;\"></iframe>\r\n        <a target=\"_blank\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1637, "\"", 1672, 1);
#line 47 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
WriteAttributeValue("", 1644, ViewBag.Transacao.BoletoUrl, 1644, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1673, 49, true);
            WriteLiteral(" class=\"btn btn-outline-secondary\">Imprimir</a>\r\n");
            EndContext();
#line 48 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Pedido\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1729, 28, true);
            WriteLiteral("    <br />\r\n    <br />\r\n    ");
            EndContext();
            BeginContext(1757, 103, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0575f03121ed5eef473e267a3f22a4bc054f556e10712", async() => {
                BeginContext(1840, 16, true);
                WriteLiteral("Voltar a comprar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1860, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MultiMarket.Models.Pedido> Html { get; private set; }
    }
}
#pragma warning restore 1591
