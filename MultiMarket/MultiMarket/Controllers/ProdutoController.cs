using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;
        private ICategoriaRepository _categoriaRepository;
        public ProdutoController(IProdutoRepository produtoRepository,ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        [HttpGet]
        [Route("/Produto/Categoria/{slug}")]
        public IActionResult ListagemProduto(string slug)
        {
            ViewData["Categoria"] = _categoriaRepository.ObterCategoriaNoTracking(a => a.Slug == slug).Nome;
            return View();
        }
        [HttpGet]
        public IActionResult Visualizar(int Id)
        {
            return View(_produtoRepository.ObterProduto(Id));
        }
    }
}