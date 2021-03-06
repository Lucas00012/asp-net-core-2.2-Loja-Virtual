#pragma checksum "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4068b1f4d29cd21dea799713134b862f20edab3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Cliente_Views_Pedido_Visualizar), @"mvc.1.0.view", @"/Areas/Cliente/Views/Pedido/Visualizar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Cliente/Views/Pedido/Visualizar.cshtml", typeof(AspNetCore.Areas_Cliente_Views_Pedido_Visualizar))]
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
#line 1 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
using MultiMarket.Models;

#line default
#line hidden
#line 2 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
using MultiMarket.Models.ProdutoAgregador;

#line default
#line hidden
#line 3 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
using MultiMarket.Libraries.Json;

#line default
#line hidden
#line 4 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4068b1f4d29cd21dea799713134b862f20edab3", @"/Areas/Cliente/Views/Pedido/Visualizar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Areas/Cliente/Views/_ViewImports.cshtml")]
    public class Areas_Cliente_Views_Pedido_Visualizar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pedido>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 6 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
  
    ViewData["Title"] = "Visualizar";

    TransacaoPagarMe transacao = JsonConvert.DeserializeObject<TransacaoPagarMe>( Model.DadosTransaction);
    List<ProdutoItem> produtos = JsonConvert.DeserializeObject<List<ProdutoItem>>(Model.DadosProdutos,new JsonSerializerSettings { 
        ContractResolver=new UndoJsonIgnore<List<ProdutoItem>>(),
    });

#line default
#line hidden
            BeginContext(510, 95, true);
            WriteLiteral("    <div class=\"text-center container\">\r\n        <br />\r\n        <br />\r\n        <h1>Pedido nº ");
            EndContext();
            BeginContext(606, 8, false);
#line 17 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                 Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(614, 1, true);
            WriteLiteral("-");
            EndContext();
            BeginContext(616, 19, false);
#line 17 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                           Write(Model.TransactionId);

#line default
#line hidden
            EndContext();
            BeginContext(635, 15, true);
            WriteLiteral("</h1>\r\n        ");
            EndContext();
            BeginContext(651, 61, false);
#line 18 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
   Write(await Component.InvokeAsync("Status", new { pedido = Model }));

#line default
#line hidden
            EndContext();
            BeginContext(712, 185, true);
            WriteLiteral("\r\n        <br />\r\n        <h3>Dados do pedido</h3>\r\n        <table class=\"table table-bordered\">\r\n            <tr>\r\n                <td colspan=\"2\"><strong>Situação do pedido:</strong> ");
            EndContext();
            BeginContext(898, 14, false);
#line 23 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                                Write(Model.Situacao);

#line default
#line hidden
            EndContext();
            BeginContext(912, 92, true);
            WriteLiteral("</td>\r\n\r\n            </tr>\r\n            <tr>\r\n                <td><strong>Cliente:</strong> ");
            EndContext();
            BeginContext(1005, 23, false);
#line 27 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                         Write(transacao.Customer.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1028, 56, true);
            WriteLiteral("</td>\r\n                <td><strong>Nascimento:</strong> ");
            EndContext();
            BeginContext(1085, 27, false);
#line 28 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                            Write(transacao.Customer.Birthday);

#line default
#line hidden
            EndContext();
            BeginContext(1112, 101, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td><strong>Forma de pagamento: </strong>");
            EndContext();
            BeginContext(1214, 20, false);
#line 31 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                    Write(Model.FormaPagamento);

#line default
#line hidden
            EndContext();
            BeginContext(1234, 92, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <strong>Nota Fiscal Eletrônica: </strong>\r\n");
            EndContext();
#line 34 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                     if (Model.NFE != null)
                    {

#line default
#line hidden
            BeginContext(1394, 26, true);
            WriteLiteral("                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1420, "\"", 1437, 1);
#line 36 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
WriteAttributeValue("", 1427, Model.NFE, 1427, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1438, 29, true);
            WriteLiteral(">Nota fiscal eletrônica</a>\r\n");
            EndContext();
#line 37 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1539, 50, true);
            WriteLiteral("                        <span>Não emitida</span>\r\n");
            EndContext();
#line 41 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                    }

#line default
#line hidden
            BeginContext(1612, 242, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n        </table>\r\n        <h3>Entrega</h3>\r\n        <table class=\"table table-bordered\">\r\n            <tr>\r\n                <td colspan=\"4\">\r\n                    <strong>Endereço de entrega: </strong>");
            EndContext();
            BeginContext(1855, 23, false);
#line 49 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                     Write(transacao.Shipping.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1878, 104, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                <td><strong>CEP:</strong> ");
            EndContext();
            BeginContext(1983, 34, false);
#line 53 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                     Write(transacao.Shipping.Address.Zipcode);

#line default
#line hidden
            EndContext();
            BeginContext(2017, 52, true);
            WriteLiteral("</td>\r\n                <td><strong>Estado:</strong> ");
            EndContext();
            BeginContext(2070, 32, false);
#line 54 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                        Write(transacao.Shipping.Address.State);

#line default
#line hidden
            EndContext();
            BeginContext(2102, 52, true);
            WriteLiteral("</td>\r\n                <td><strong>Cidade:</strong> ");
            EndContext();
            BeginContext(2155, 31, false);
#line 55 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                        Write(transacao.Shipping.Address.City);

#line default
#line hidden
            EndContext();
            BeginContext(2186, 52, true);
            WriteLiteral("</td>\r\n                <td><strong>Bairro:</strong> ");
            EndContext();
            BeginContext(2239, 39, false);
#line 56 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                        Write(transacao.Shipping.Address.Neighborhood);

#line default
#line hidden
            EndContext();
            BeginContext(2278, 104, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td colspan=\"2\"><strong>Endereço: </strong> ");
            EndContext();
            BeginContext(2383, 33, false);
#line 59 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                       Write(transacao.Shipping.Address.Street);

#line default
#line hidden
            EndContext();
            BeginContext(2416, 57, true);
            WriteLiteral("</td>\r\n                <td><strong>Complemento: </strong>");
            EndContext();
            BeginContext(2474, 40, false);
#line 60 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                             Write(transacao.Shipping.Address.Complementary);

#line default
#line hidden
            EndContext();
            BeginContext(2514, 52, true);
            WriteLiteral("</td>\r\n                <td><strong>Número: </strong>");
            EndContext();
            BeginContext(2567, 39, false);
#line 61 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                        Write(transacao.Shipping.Address.StreetNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2606, 109, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td colspan=\"2\"><strong>Transportadora:</strong> ");
            EndContext();
            BeginContext(2716, 18, false);
#line 64 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                            Write(Model.FreteEmpresa);

#line default
#line hidden
            EndContext();
            BeginContext(2734, 60, true);
            WriteLiteral("</td>\r\n                <td><strong>Valor do frete:</strong> ");
            EndContext();
            BeginContext(2796, 53, false);
#line 65 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                 Write(((decimal)transacao.Shipping.Fee / 100).ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(2850, 82, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <strong>Rastreamento: </strong>\r\n");
            EndContext();
#line 68 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                     if (Model.FreteCodRastreamento != null)
                    {
                        

#line default
#line hidden
            BeginContext(3042, 26, false);
#line 70 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                   Write(Model.FreteCodRastreamento);

#line default
#line hidden
            EndContext();
#line 70 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                                                   
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(3142, 50, true);
            WriteLiteral("                        <span>Não emitido</span>\r\n");
            EndContext();
#line 75 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                    }

#line default
#line hidden
            BeginContext(3215, 313, true);
            WriteLiteral(@"                </td>
            </tr>
        </table>
        <h3>Lista de produtos</h3>
        <table class=""table table-bordered"">
            <tr>
                <th>Quantidade</th>
                <th>Nome</th>
                <th>Valor</th>
                <th>TOTAL</th>
            </tr>

");
            EndContext();
#line 88 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
             foreach (var produto in produtos)
            {

#line default
#line hidden
            BeginContext(3591, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(3638, 33, false);
#line 91 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                   Write(produto.QuantidadeCarrinhoProduto);

#line default
#line hidden
            EndContext();
            BeginContext(3671, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3703, 12, false);
#line 92 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                   Write(produto.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(3715, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3748, 38, false);
#line 93 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                    Write(((decimal)produto.Valor).ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(3787, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(3820, 76, false);
#line 94 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                    Write((((decimal)produto.Valor) * produto.QuantidadeCarrinhoProduto).ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(3897, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 96 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
            }

#line default
#line hidden
            BeginContext(3942, 101, true);
            WriteLiteral("\r\n            <tr>\r\n                <td colspan=\"3\"><strong>FRETE</strong></td>\r\n                <td>");
            EndContext();
            BeginContext(4045, 53, false);
#line 100 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
                Write(((decimal)transacao.Shipping.Fee / 100).ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(4099, 125, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td colspan=\"3\"><strong>TOTAL</strong></td>\r\n                <td>");
            EndContext();
            BeginContext(4225, 30, false);
#line 104 "C:\Users\lucas\Documents\Git\asp-net-core-2.2-Loja-Virtual\MultiMarket\MultiMarket\Areas\Cliente\Views\Pedido\Visualizar.cshtml"
               Write(Model.ValorTotal.ToString("C"));

#line default
#line hidden
            EndContext();
            BeginContext(4255, 328, true);
            WriteLiteral(@"</td>
            </tr>
        </table>

        <br />
        <br />
        <button class=""btn btn-outline-primary btn-lg"" id=""btn-imprimir"">Imprimir</button>
    </div>
<script>
    var botao = document.getElementById(""btn-imprimir"");
    botao.addEventListener(""click"", function () { window.print();})
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pedido> Html { get; private set; }
    }
}
#pragma warning restore 1591
