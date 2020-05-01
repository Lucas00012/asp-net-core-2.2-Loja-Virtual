using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.CarrinhoCompra;
using MultiMarket.Models;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Repositories.Contracts;
using AutoMapper;
using MultiMarket.Libraries.Frete;
using MultiMarket.Models.Correios;
using MultiMarket.Models.PacoteCorreio;
using Microsoft.AspNetCore.Http;
using MultiMarket.Libraries.Cookie;
using Newtonsoft.Json;
using MultiMarket.Libraries.Texto;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Login;

namespace MultiMarket.Controllers
{
    public class CarrinhoCompraController : BaseController
    {
        private IEnderecoEntregaRepository _enderecoEntregaRepository;
        private LoginCliente _loginCliente;
        public CarrinhoCompraController(LoginCliente loginCliente,IEnderecoEntregaRepository enderecoEntregaRepository, GerenciadorCookie cookie,CarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository, IMapper mapper, WSCalcularFrete frete, WSCalcularPacote pacote, CookieValorPrazoFrete cookieValorPrazoFrete) : base(carrinhoCompra, produtoRepository, mapper, frete, pacote, cookieValorPrazoFrete,cookie)
        {
            _enderecoEntregaRepository = enderecoEntregaRepository;
            _loginCliente = loginCliente;
        }

        public IActionResult Index()
        {
            ViewData["CEP"] = _cookie.Consultar("Carrinho.CEP", false);
            List<ProdutoItem> ProdutosCompleto = CarregarProdutoDB();

            return View(ProdutosCompleto);
        }
        //Azure Data Lake and Stream Analytics
        public IActionResult AdicionarItem(int id)
        {
            Produto produto = _produtoRepository.ObterProduto(id);
            if (produto == null)
            {
                return BadRequest(new { mensagem = "Oops! Este produto não foi encontrado" });
            }
            else if (produto.Quantidade == 0)
            {
                return BadRequest(new { mensagem = "Oops! Produto indisponível no estoque!" });
            }
            ProdutoItem produtoItem = _carrinhoCompra.ConsultarProduto(id);
            if (produtoItem!=null && produtoItem.QuantidadeCarrinhoProduto == produto.Quantidade)
            {
                return BadRequest(new { mensagem = "Oops! Não temos essa quantidade em estoque!" });
            }
            //A QUANTIDADE CARRINHO PRODUTO = 1 SO FUNCIONARA COM NOVOS. O RESTO SERA INCREMENTADO
            var item=new ProdutoItem() { Id = id, QuantidadeCarrinhoProduto = 1 };
            _carrinhoCompra.Cadastrar(item);
            return Ok();
        }
        [HttpGet]
        [ClienteAutorizacao]
        [PagamentoValidate]
        public IActionResult EnderecoEntrega(int? pagina,string pesquisa)
        {
            ViewBag.Produtos = CarregarProdutoDB();
            ViewBag.Cliente = _loginCliente.BuscaClienteSessao();
            ViewBag.CEP = _cookie.Consultar("Carrinho.CEP", false);

            return View(_enderecoEntregaRepository.GeneratePagination(pagina, pesquisa));
        }
        public IActionResult RemoverItem(int id)
        {
            _carrinhoCompra.Remover(new ProdutoItem() { Id = id });
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AlterarQuantidade(int id,int quantidade)
        {
            Produto produto = _produtoRepository.ObterProduto(id);
            if (quantidade < 1)
            {
                return BadRequest(new { mensagem="A quantidade não pode ser 0! Caso queira remova o item do carrinho!", qtdMax = produto.Quantidade });
            }
            else if (quantidade > produto.Quantidade)
            {
                return BadRequest(new { mensagem = "Oops! Temos somente "+produto.Quantidade+" unidades no estoque!",qtdMax=produto.Quantidade});
            }
            var item=new ProdutoItem() { Id = id, QuantidadeCarrinhoProduto = quantidade };
            _carrinhoCompra.Atualizar(item);
            return Ok();
        }
        public async Task<IActionResult> CalcularFrete(string cepDestino)
        {
            try
            {

                Frete frete=_cookieValorPrazoFrete.Consultar().Where(a=>a.CEP==cepDestino && a.CarrinhoId==HashGenerator.CreateMD5(JsonConvert.SerializeObject(_carrinhoCompra.Consultar()))).FirstOrDefault();
                var options = new CookieOptions() { Expires = DateTime.Now.AddDays(7),IsEssential=true };

                HttpContext.Response.Cookies.Append("Carrinho.CEP", cepDestino, options);
                if (frete != null)
                {
                    return Ok(frete);
                }
                else
                {

                    List<ProdutoItem> produtos = CarregarProdutoDB();
                    List<Pacote> pacotes = _pacote.CalcularPacote(produtos);

                    ValorPrazoFrete valorPAC = await _frete.CalcularFrete(cepDestino, TipoFreteConstant.PAC, pacotes);
                    ValorPrazoFrete valorSEDEX = await _frete.CalcularFrete(cepDestino, TipoFreteConstant.Sedex, pacotes);
                    ValorPrazoFrete valorSEDEX10 = await _frete.CalcularFrete(cepDestino, TipoFreteConstant.Sedex10, pacotes);

                    List<ValorPrazoFrete> lista = new List<ValorPrazoFrete>();
                    if (valorPAC != null) lista.Add(valorPAC);
                    if (valorSEDEX != null) lista.Add(valorSEDEX);
                    if (valorSEDEX10 != null) lista.Add(valorSEDEX10);

                    if (lista.Count() == 0)
                    {
                        return BadRequest(new { erro = "Este CEP não possui acesso ao servico dos CORREIOS" }); ;
                    }

                    frete = new Frete()
                    {
                        CEP = cepDestino,
                        CarrinhoId = HashGenerator.CreateMD5(JsonConvert.SerializeObject(_carrinhoCompra.Consultar())),
                        Valores = lista
                    };

                    _cookieValorPrazoFrete.Cadastrar(frete);

                    return Ok(frete);
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}