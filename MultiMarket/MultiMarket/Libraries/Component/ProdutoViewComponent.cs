using Microsoft.AspNetCore.Mvc;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Component
{
    public class ProdutoViewComponent:ViewComponent
    {
        private IProdutoRepository _produtoRepository;
        ICategoriaRepository _categoriaRepository;
        public ProdutoViewComponent(IProdutoRepository produtoRepository,ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int? pagina = 1;
            if (HttpContext.Request.Query.ContainsKey("pagina"))
                pagina = int.Parse(HttpContext.Request.Query["pagina"]);
            string pesquisa = HttpContext.Request.Query["pesquisa"];
            string ordem = HttpContext.Request.Query["ordem"];
            List<Categoria> categorias = null;
            if (ViewContext.RouteData.Values.ContainsKey("slug"))
            {
                var slug = ViewContext.RouteData.Values["slug"].ToString();
                Categoria categoria = _categoriaRepository.ObterCategoria(a => a.Slug == slug);
                categorias = _categoriaRepository.VerificarCategoriasSlug(categoria);
                return View(_produtoRepository.GeneratePagination(pagina, pesquisa, ordem, categorias));
            }

            return View(_produtoRepository.GeneratePagination(pagina, pesquisa, ordem));
        }
    }
}
