#pragma checksum "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Produto\ListagemProduto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a307caee44a4d1af84425937b2fc99da6791c8ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_ListagemProduto), @"mvc.1.0.view", @"/Views/Produto/ListagemProduto.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produto/ListagemProduto.cshtml", typeof(AspNetCore.Views_Produto_ListagemProduto))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a307caee44a4d1af84425937b2fc99da6791c8ae", @"/Views/Produto/ListagemProduto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ed1d286704faafb66f6c362a6279f19f91eff5f", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_ListagemProduto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Produto\ListagemProduto.cshtml"
  
    ViewData["Title"] = "ListagemProduto";
    string slug = ViewContext.RouteData.Values["slug"].ToString();

#line default
#line hidden
            BeginContext(119, 44, true);
            WriteLiteral("<br />\r\n<h1 class=\"text-center\">Categoria > ");
            EndContext();
            BeginContext(164, 21, false);
#line 6 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Produto\ListagemProduto.cshtml"
                               Write(ViewData["Categoria"]);

#line default
#line hidden
            EndContext();
            BeginContext(185, 17, true);
            WriteLiteral("</h1>\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(203, 38, false);
#line 9 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Views\Produto\ListagemProduto.cshtml"
Write(await Component.InvokeAsync("Produto"));

#line default
#line hidden
            EndContext();
            BeginContext(241, 1, true);
            WriteLiteral(";");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
