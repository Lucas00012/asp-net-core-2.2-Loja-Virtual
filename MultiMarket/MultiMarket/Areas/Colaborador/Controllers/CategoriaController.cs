using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class CategoriaController : Controller
    {
        private ICategoriaRepository _categoriaRepository;
        private IProdutoRepository _produtoRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository,IProdutoRepository produtoRepository)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        } 

        //RECEBE pagina VIA QUERYSTRING
        public IActionResult Index(int? pagina,string pesquisa)
        {
            return View(_categoriaRepository.GeneratePagination(pagina,pesquisa));
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(a => new SelectListItem(a.Nome, a.Id.ToString())); ;
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar([FromForm]Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Cadastrar(categoria);
                TempData["MSG_S"] = "Categoria cadastrada com sucesso!";
                return new RedirectResult(nameof(Cadastrar));
            }

            //RETORNA UMA LISTA DE 2 ELEMENTOS DO TIPO Categoria VOLTADO PARA O SELECT DO HTML
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(a=>new SelectListItem(a.Nome,a.Id.ToString()));
            return View();
        }
        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Where(A => A.Id != id).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View(_categoriaRepository.ObterCategoria(id));
        }
        [HttpPost]
        public IActionResult Atualizar([FromForm]Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "Categoria atualizada com sucesso!";
                _categoriaRepository.Atualizar(categoria);
            }
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Where(A=>A.Id!=categoria.Id).Select(a => new SelectListItem(a.Nome, a.Id.ToString()));
            return View(categoria);
        }
        [HttpGet]
        [ValidateRequest]
        public IActionResult Excluir(int id)
        {
            Categoria categoria= _categoriaRepository.ObterCategoria(id);
            List<Categoria> categoriasFilho = _categoriaRepository.ObterCategorias(a=>a.CategoriaPaiId==categoria.Id);
            List<Produto> produtos = _produtoRepository.ObterProdutos(a => a.CategoriaId == categoria.Id);
            StringBuilder sb = new StringBuilder();
            if (categoriasFilho.Count() > 0)
            {
                sb.Append("Não é possível excluir categorias que possuem filhos: ");
                foreach(var categoriaF in categoriasFilho)
                {
                    sb.Append($" '{categoriaF.Nome}' ");
                }
            }
            else if (produtos.Count() > 0)
            {
                sb.Append("Erro! Há produtos com essa categoria: ");
                foreach (var produto in produtos)
                {
                    sb.Append($" '{produto.Nome}' ");
                }
            }
            else
            {
                TempData["MSG_S"] = "Registro excluído com sucesso!";
                _categoriaRepository.Excluir(id);
                return RedirectToAction(nameof(Index));
            }
            TempData["MSG_E"] = sb.ToString();
            return RedirectToAction(nameof(Index));
        }
    }
}