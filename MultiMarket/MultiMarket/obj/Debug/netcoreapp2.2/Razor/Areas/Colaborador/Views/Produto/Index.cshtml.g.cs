#pragma checksum "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55cf7efddc4d48d2b4b17ab4d0ed1545d25f2348"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Colaborador_Views_Produto_Index), @"mvc.1.0.view", @"/Areas/Colaborador/Views/Produto/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Colaborador/Views/Produto/Index.cshtml", typeof(AspNetCore.Areas_Colaborador_Views_Produto_Index))]
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
#line 1 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
using MultiMarket.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55cf7efddc4d48d2b4b17ab4d0ed1545d25f2348", @"/Areas/Colaborador/Views/Produto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Areas/Colaborador/Views/_ViewImports.cshtml")]
    public class Areas_Colaborador_Views_Produto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MultiMarket.Libraries.Pagination.PaginationEngine<Produto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Actions.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cadastrar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Atualizar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Excluir", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Produto", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Colaborador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
  
    ViewData["Title"] = "Index";
    string pesquisa = Context.Request.Query["pesquisa"];

#line default
#line hidden
            BeginContext(193, 22, true);
            WriteLiteral("\r\n<h1>Produto</h1>\r\n\r\n");
            EndContext();
            BeginContext(215, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f23487581", async() => {
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
            BeginContext(254, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(256, 236, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f23488759", async() => {
                BeginContext(294, 88, true);
                WriteLiteral("\r\n    <p>\r\n        <input type=\"text\" name=\"pesquisa\" id=\"pesquisa\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 382, "\"", 399, 1);
#line 13 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
WriteAttributeValue("", 390, pesquisa, 390, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(400, 85, true);
                WriteLiteral(" />\r\n        <button type=\"submit\" class=\"btn btn-info\">Procurar</button>\r\n    </p>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(492, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
 if (Model.Elementos.Count > 0)
{

    if (TempData["MSG_S"] != null)
    {

#line default
#line hidden
            BeginContext(575, 39, true);
            WriteLiteral("        <p class=\"alert alert-success\">");
            EndContext();
            BeginContext(615, 17, false);
#line 22 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                                  Write(TempData["MSG_S"]);

#line default
#line hidden
            EndContext();
            BeginContext(632, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 23 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(645, 47, true);
            WriteLiteral("    <div class=\"table-responsive\">\r\n        <p>");
            EndContext();
            BeginContext(692, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f234812383", async() => {
                BeginContext(739, 9, true);
                WriteLiteral("Cadastrar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(752, 220, true);
            WriteLiteral("</p>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <!--ESSE COMANDO SERVE PARA MOSTRAR O NOME DA PROPRIEDADE DO ELEMENTO CAPTURADO-->\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(973, 48, false);
#line 30 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Id));

#line default
#line hidden
            EndContext();
            BeginContext(1021, 43, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(1065, 50, false);
#line 31 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1115, 43, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(1159, 55, false);
#line 32 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Categoria));

#line default
#line hidden
            EndContext();
            BeginContext(1214, 43, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(1258, 51, false);
#line 33 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Valor));

#line default
#line hidden
            EndContext();
            BeginContext(1309, 121, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">Ações</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 38 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                 foreach (MultiMarket.Models.Produto produto in Model.Elementos)
                {

#line default
#line hidden
            BeginContext(1531, 66, true);
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
            EndContext();
            BeginContext(1598, 10, false);
#line 41 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                                   Write(produto.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1608, 35, true);
            WriteLiteral("</th>\r\n                        <td>");
            EndContext();
            BeginContext(1644, 12, false);
#line 42 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                       Write(produto.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1656, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1692, 44, false);
#line 43 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                       Write(Html.DisplayFor(A => produto.Categoria.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1736, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1772, 13, false);
#line 44 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                       Write(produto.Valor);

#line default
#line hidden
            EndContext();
            BeginContext(1785, 65, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1850, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f234818304", async() => {
                BeginContext(1927, 9, true);
                WriteLiteral("Atualizar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                                                                                WriteLiteral(produto.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1940, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(1970, 85, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f234820840", async() => {
                BeginContext(2044, 7, true);
                WriteLiteral("Excluir");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 47 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                                                                             WriteLiteral(produto.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2055, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 50 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2134, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 54 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"



    var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
    var nextDisabled = !Model.HasNextPage ? "disabled" : "";



#line default
#line hidden
            BeginContext(2324, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(2328, 240, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f234824168", async() => {
                BeginContext(2542, 22, true);
                WriteLiteral("\r\n        Voltar\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagina", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 63 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
             WriteLiteral(Model.PageIndex-1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pagina", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 64 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
               WriteLiteral(pesquisa);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pesquisa"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pesquisa", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pesquisa"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2514, "btn", 2514, 3, true);
            AddHtmlAttributeValue(" ", 2517, "btn-dark", 2518, 9, true);
#line 66 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
AddHtmlAttributeValue(" ", 2526, prevDisabled, 2527, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2568, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(2574, 241, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "55cf7efddc4d48d2b4b17ab4d0ed1545d25f234828296", async() => {
                BeginContext(2788, 23, true);
                WriteLiteral("\r\n        Avançar\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagina", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 71 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
             WriteLiteral(Model.PageIndex+1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pagina", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 72 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
               WriteLiteral(pesquisa);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pesquisa"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pesquisa", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pesquisa"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2760, "btn", 2760, 3, true);
            AddHtmlAttributeValue(" ", 2763, "btn-dark", 2764, 9, true);
#line 74 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
AddHtmlAttributeValue(" ", 2772, nextDisabled, 2773, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2815, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 77 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(2827, 36, true);
            WriteLiteral("<p>Não há registros cadastrados!</p>");
            EndContext();
#line 79 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Produto\Index.cshtml"
                                     }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MultiMarket.Libraries.Pagination.PaginationEngine<Produto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
