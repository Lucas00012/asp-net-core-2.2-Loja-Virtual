#pragma checksum "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffe8ed46fd165091da498f9fa43e25fe0929fc90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_Visualizar), @"mvc.1.0.view", @"/Views/Produto/Visualizar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produto/Visualizar.cshtml", typeof(AspNetCore.Views_Produto_Visualizar))]
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
#line 2 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
using MultiMarket.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffe8ed46fd165091da498f9fa43e25fe0929fc90", @"/Views/Produto/Visualizar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ed1d286704faafb66f6c362a6279f19f91eff5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_Visualizar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MultiMarket.Models.Produto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/vender-produtos.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/vender-produtos.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AdicionarItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CarrinhoCompra", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  btn-outline-primary btn-adiciona"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
  
    ViewData["Title"] = "Visualizar";

#line default
#line hidden
            BeginContext(108, 304, true);
            WriteLiteral(@"<br style=""clear:both"" />

<main role=""main"">

    <div class=""container"" id=""code_prod_detail"" style=""margin-top: 50px"">
        <div class=""card"">
            <div class=""row no-gutters"">
                <aside class=""col-sm-5 border-right"">
                    <article class=""gallery-wrap"">
");
            EndContext();
#line 15 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                         if (Model.ImagemProduto.Count() > 0)
                        {

#line default
#line hidden
            BeginContext(502, 96, true);
            WriteLiteral("                            <div class=\"img-big-wrap\">\r\n                                <div> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 598, "\"", 636, 1);
#line 18 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
WriteAttributeValue("", 605, Model.ImagemProduto[0].Caminho, 605, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(637, 22, true);
            WriteLiteral(" data-fancybox=\"\"><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 659, "\"", 696, 1);
#line 18 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
WriteAttributeValue("", 665, Model.ImagemProduto[0].Caminho, 665, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(697, 134, true);
            WriteLiteral("></a></div>\r\n                            </div> <!-- slider-product.// -->\r\n                            <div class=\"img-small-wrap\">\r\n");
            EndContext();
#line 21 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                 foreach (Imagem imagem in Model.ImagemProduto)
                                {

#line default
#line hidden
            BeginContext(947, 67, true);
            WriteLiteral("                                    <div class=\"item-gallery\"> <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1014, "\"", 1035, 1);
#line 23 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
WriteAttributeValue("", 1020, imagem.Caminho, 1020, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1036, 9, true);
            WriteLiteral("></div>\r\n");
            EndContext();
#line 24 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                }

#line default
#line hidden
            BeginContext(1080, 59, true);
            WriteLiteral("                            </div> <!-- slider-nav.// -->\r\n");
            EndContext();
#line 26 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(1223, 94, true);
            WriteLiteral("                            <div class=\"img-big-wrap\">\r\n                                <div> ");
            EndContext();
            BeginContext(1317, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffe8ed46fd165091da498f9fa43e25fe0929fc908503", async() => {
                BeginContext(1370, 37, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ffe8ed46fd165091da498f9fa43e25fe0929fc908767", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-fancybox", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1411, 71, true);
            WriteLiteral("</div>\r\n                            </div> <!-- slider-product.// -->\r\n");
            EndContext();
#line 32 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                        }

#line default
#line hidden
            BeginContext(1509, 219, true);
            WriteLiteral("                    </article> <!-- gallery-wrap .end// -->\r\n                </aside>\r\n                <aside class=\"col-sm-7\">\r\n                    <article class=\"p-5\">\r\n                        <h3 class=\"title mb-3\">");
            EndContext();
            BeginContext(1729, 10, false);
#line 37 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                          Write(Model.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1739, 188, true);
            WriteLiteral("</h3>\r\n\r\n                        <div class=\"mb-3\">\r\n                            <var class=\"price h3 text-warning\">\r\n                                <span class=\"currency\">R$</span><span>");
            EndContext();
            BeginContext(1928, 11, false);
#line 41 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                                                 Write(Model.Valor);

#line default
#line hidden
            EndContext();
            BeginContext(1939, 343, true);
            WriteLiteral(@"</span>
                            </var>
                            <span>/por un</span>
                        </div> <!-- price-detail-wrap .// -->
                        <dl>
                            <dt>Descrição</dt>
                            <dd>
                                <p>
                                    ");
            EndContext();
            BeginContext(2283, 15, false);
#line 49 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                               Write(Model.Descricao);

#line default
#line hidden
            EndContext();
            BeginContext(2298, 257, true);
            WriteLiteral(@"
                                </p>
                            </dd>
                        </dl>
                        <dl class=""row"">
                            <dt class=""col-sm-3"">Peso</dt>
                            <dd class=""col-sm-9"">");
            EndContext();
            BeginContext(2556, 10, false);
#line 55 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                            Write(Model.Peso);

#line default
#line hidden
            EndContext();
            BeginContext(2566, 124, true);
            WriteLiteral(" kg</dd>\r\n\r\n                            <dt class=\"col-sm-3\">Largura</dt>\r\n                            <dd class=\"col-sm-9\">");
            EndContext();
            BeginContext(2691, 13, false);
#line 58 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                            Write(Model.Largura);

#line default
#line hidden
            EndContext();
            BeginContext(2704, 123, true);
            WriteLiteral(" cm</dd>\r\n\r\n                            <dt class=\"col-sm-3\">Altura</dt>\r\n                            <dd class=\"col-sm-9\">");
            EndContext();
            BeginContext(2828, 12, false);
#line 61 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                            Write(Model.Altura);

#line default
#line hidden
            EndContext();
            BeginContext(2840, 128, true);
            WriteLiteral(" cm</dd>\r\n\r\n                            <dt class=\"col-sm-3\">Comprimento</dt>\r\n                            <dd class=\"col-sm-9\">");
            EndContext();
            BeginContext(2969, 17, false);
#line 64 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                            Write(Model.Comprimento);

#line default
#line hidden
            EndContext();
            BeginContext(2986, 254, true);
            WriteLiteral(" cm</dd>\r\n                        </dl>\r\n                        <div class=\"rating-wrap\">\r\n\r\n                        </div> <!-- rating-wrap.// -->\r\n                        <hr>\r\n                        <hr>\r\n                        <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3240, "\"", 3257, 1);
#line 71 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
WriteAttributeValue("", 3248, Model.Id, 3248, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3258, 48, true);
            WriteLiteral(" class=\"produto-id\" />\r\n                        ");
            EndContext();
            BeginContext(3306, 251, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffe8ed46fd165091da498f9fa43e25fe0929fc9016247", async() => {
                BeginContext(3439, 114, true);
                WriteLiteral("\r\n                            <i class=\"fas fa-shopping-cart\"></i> Adicionar ao carrinho\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 72 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                                                                        WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3557, 179, true);
            WriteLiteral("\r\n                    </article> <!-- card-body.// -->\r\n                </aside> <!-- col.// -->\r\n            </div> <!-- row.// -->\r\n        </div> <!-- card.// -->\r\n    </div>\r\n");
            EndContext();
#line 80 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
     if (TempData["MSG_E"] != null)
    {

#line default
#line hidden
            BeginContext(3780, 112, true);
            WriteLiteral("        <div class=\"container text-center\">\r\n            <p id=\"error-msg\" class=\"alert alert-danger msg-error\">");
            EndContext();
            BeginContext(3893, 17, false);
#line 83 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
                                                              Write(TempData["MSG_E"]);

#line default
#line hidden
            EndContext();
            BeginContext(3910, 22, true);
            WriteLiteral("</p>\r\n        </div>\r\n");
            EndContext();
#line 85 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(3956, 156, true);
            WriteLiteral("        <div class=\"container text-center\">\r\n            <p id=\"error-msg\" class=\"alert alert-danger msg-error\" style=\"display:none;\"></p>\r\n        </div>\r\n");
            EndContext();
#line 91 "C:\Users\lucas\Documents\Projetos\MultiMarket\MultiMarket\Views\Produto\Visualizar.cshtml"
    }

#line default
#line hidden
            BeginContext(4119, 9, true);
            WriteLiteral("</main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MultiMarket.Models.Produto> Html { get; private set; }
    }
}
#pragma warning restore 1591