#pragma checksum "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6d024c420a67e9106d5a6c00b1012a5c2bd07b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Colaborador_Views_Colaboradores_Index), @"mvc.1.0.view", @"/Areas/Colaborador/Views/Colaboradores/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Colaborador/Views/Colaboradores/Index.cshtml", typeof(AspNetCore.Areas_Colaborador_Views_Colaboradores_Index))]
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
#line 1 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
using MultiMarket.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6d024c420a67e9106d5a6c00b1012a5c2bd07b1", @"/Areas/Colaborador/Views/Colaboradores/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Areas/Colaborador/Views/_ViewImports.cshtml")]
    public class Areas_Colaborador_Views_Colaboradores_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MultiMarket.Libraries.Pagination.PaginationEngine<Colaborador>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cadastrar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GerarSenha", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Atualizar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Excluir", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnDelete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Categoria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Colaborador", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
  
    ViewData["Title"] = "Index";
    string pesquisa = Context.Request.Query["pesquisa"];

#line default
#line hidden
            BeginContext(197, 24, true);
            WriteLiteral("\r\n<h1>Colaborador</h1>\r\n");
            EndContext();
            BeginContext(221, 236, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b18139", async() => {
                BeginContext(259, 88, true);
                WriteLiteral("\r\n    <p>\r\n        <input type=\"text\" name=\"pesquisa\" id=\"pesquisa\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 347, "\"", 364, 1);
#line 11 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
WriteAttributeValue("", 355, pesquisa, 355, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(365, 85, true);
                WriteLiteral(" />\r\n        <button type=\"submit\" class=\"btn btn-info\">Procurar</button>\r\n    </p>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(457, 5, true);
            WriteLiteral("\r\n<p>");
            EndContext();
            BeginContext(462, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b110641", async() => {
                BeginContext(512, 9, true);
                WriteLiteral("Cadastrar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(525, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 16 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
 if (Model.Elementos.Count > 0)
{

    if (TempData["MSG_S"] != null)
    {

#line default
#line hidden
            BeginContext(612, 39, true);
            WriteLiteral("        <p class=\"alert alert-success\">");
            EndContext();
            BeginContext(652, 17, false);
#line 21 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                                  Write(TempData["MSG_S"]);

#line default
#line hidden
            EndContext();
            BeginContext(669, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 22 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
    }
    

#line default
#line hidden
#line 23 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
     if (TempData["MSG_E"] != null)
    {

#line default
#line hidden
            BeginContext(726, 38, true);
            WriteLiteral("        <p class=\"alert alert-danger\">");
            EndContext();
            BeginContext(765, 17, false);
#line 25 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                                 Write(TempData["MSG_S"]);

#line default
#line hidden
            EndContext();
            BeginContext(782, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 26 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(795, 250, true);
            WriteLiteral("    <div class=\"table-responsive\">\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <!--ESSE COMANDO SERVE PARA MOSTRAR O NOME DA PROPRIEDADE DO ELEMENTO CAPTURADO-->\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(1046, 48, false);
#line 32 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Id));

#line default
#line hidden
            EndContext();
            BeginContext(1094, 43, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(1138, 50, false);
#line 33 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1188, 43, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">");
            EndContext();
            BeginContext(1232, 51, false);
#line 34 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                               Write(Html.DisplayNameFor(A => A.Elementos.First().Email));

#line default
#line hidden
            EndContext();
            BeginContext(1283, 121, true);
            WriteLiteral("</th>\r\n                    <th scope=\"col\">Ações</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 39 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                 foreach (MultiMarket.Models.Colaborador colaborador in Model.Elementos)
                {

#line default
#line hidden
            BeginContext(1513, 66, true);
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
            EndContext();
            BeginContext(1580, 14, false);
#line 42 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                                   Write(colaborador.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1594, 35, true);
            WriteLiteral("</th>\r\n                        <td>");
            EndContext();
            BeginContext(1630, 16, false);
#line 43 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                       Write(colaborador.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1646, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1682, 17, false);
#line 44 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                       Write(colaborador.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1699, 65, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1764, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b117784", async() => {
                BeginContext(1843, 11, true);
                WriteLiteral("Gerar senha");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 46 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                                                         WriteLiteral(colaborador.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1858, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(1888, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b120310", async() => {
                BeginContext(1969, 9, true);
                WriteLiteral("Atualizar");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 47 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                                                        WriteLiteral(colaborador.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1982, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(2012, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b122833", async() => {
                BeginContext(2105, 7, true);
                WriteLiteral("Excluir");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                                                      WriteLiteral(colaborador.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2116, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 51 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2195, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 55 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"



    var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
    var nextDisabled = !Model.HasNextPage ? "disabled" : "";



#line default
#line hidden
            BeginContext(2385, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(2389, 203, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b126244", async() => {
                BeginContext(2566, 22, true);
                WriteLiteral("\r\n        Voltar\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagina", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 64 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
             WriteLiteral(Model.PageIndex-1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pagina", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2538, "btn", 2538, 3, true);
            AddHtmlAttributeValue(" ", 2541, "btn-dark", 2542, 9, true);
#line 66 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
AddHtmlAttributeValue(" ", 2550, prevDisabled, 2551, 13, false);

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
            BeginContext(2592, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(2598, 204, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6d024c420a67e9106d5a6c00b1012a5c2bd07b129684", async() => {
                BeginContext(2775, 23, true);
                WriteLiteral("\r\n        Avançar\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagina", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 71 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
             WriteLiteral(Model.PageIndex+1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pagina", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagina"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2747, "btn", 2747, 3, true);
            AddHtmlAttributeValue(" ", 2750, "btn-dark", 2751, 9, true);
#line 73 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
AddHtmlAttributeValue(" ", 2759, nextDisabled, 2760, 13, false);

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
            BeginContext(2802, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 76 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(2814, 36, true);
            WriteLiteral("<p>Não há registros cadastrados!</p>");
            EndContext();
#line 78 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Colaborador\Views\Colaboradores\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MultiMarket.Libraries.Pagination.PaginationEngine<Colaborador>> Html { get; private set; }
    }
}
#pragma warning restore 1591
