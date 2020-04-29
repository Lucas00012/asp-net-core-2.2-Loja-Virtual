using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.CarrinhoCompra;
using MultiMarket.Libraries.Cookie;
using MultiMarket.Libraries.Frete;
using MultiMarket.Models;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Controllers
{
    public class BaseController : Controller
    {
        protected CarrinhoCompra _carrinhoCompra;
        protected IProdutoRepository _produtoRepository;
        protected IMapper _mapper;
        protected WSCalcularFrete _frete;
        protected WSCalcularPacote _pacote;
        protected CookieValorPrazoFrete _cookieValorPrazoFrete;
        protected GerenciadorCookie _cookie;
        public BaseController(CarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository, IMapper mapper, WSCalcularFrete frete, WSCalcularPacote pacote, CookieValorPrazoFrete cookieValorPrazoFrete,GerenciadorCookie cookie)
        {
            _carrinhoCompra = carrinhoCompra;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _frete = frete;
            _pacote = pacote;
            _cookieValorPrazoFrete = cookieValorPrazoFrete;
            _cookie = cookie;
        }
        protected List<ProdutoItem> CarregarProdutoDB()
        {
            List<ProdutoItem> ProdutosCarrinho = _carrinhoCompra.Consultar();
            List<ProdutoItem> ProdutosCompleto = new List<ProdutoItem>();

            foreach (var item in ProdutosCarrinho)
            {
                Produto produto = _produtoRepository.ObterProduto(item.Id);

                //NECESSARIO PARA TER ACESSO A PROPRIEDADE REFERENTE A QUANTIDADE NO CARRINHO
                //O AutoMapper FAZ ISSO FACILMENTE
                ProdutoItem produtoItem = _mapper.Map<ProdutoItem>(produto);
                produtoItem.QuantidadeCarrinhoProduto = item.QuantidadeCarrinhoProduto;

                ProdutosCompleto.Add(produtoItem);
            }

            return ProdutosCompleto;
        }
    }
}