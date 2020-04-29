using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiMarket.Libraries.Arquivo;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;
        private ICategoriaRepository _categoriaRepository;
        private IImagemRepository _imagemRepository;
        public ProdutoController(IProdutoRepository produtoRepository,ICategoriaRepository categoriaRepository,IImagemRepository imagemRepository)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _imagemRepository = imagemRepository;
        }
        public IActionResult Index(int? pagina,string pesquisa)
        {
            return View(_produtoRepository.GeneratePagination(pagina,pesquisa));
        }
        [HttpGet]
        [ValidateRequest]
        public IActionResult Excluir(int Id)
        {
            _imagemRepository.ExcluirImagens(Id);
            _produtoRepository.Excluir(Id);
            GerenciadorArquivo.RemoverPasta(Id);
            TempData["MSG_S"] = "Registro excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Atualizar(int Id)
        {
            Produto produto = _produtoRepository.ObterProduto(Id);
            produto.ImagemProduto = _imagemRepository.ObterTodasImagens(Id);
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            return View(produto);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "Registro cadastrado com sucesso!";
                _produtoRepository.Cadastrar(produto);
                List<string> ImagesAddress = HttpContext.Request.Form["imageAddress"].ToList();
                _imagemRepository.CadastrarImagens(GerenciadorArquivo.MoverImagensProduto(ImagesAddress, produto.Id));
                return new RedirectResult(nameof(Cadastrar));
            }
            ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            ViewData["imagens"] = HttpContext.Request.Form["imageAddress"].ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Atualizar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "Registro atualizado com sucesso!";
                _produtoRepository.Atualizar(produto);
                List<string> ImagesAddress = HttpContext.Request.Form["imageAddress"].ToList();
                List<Imagem> imagens = GerenciadorArquivo.MoverImagensProduto(ImagesAddress, produto.Id);
                _imagemRepository.ExcluirImagens(produto.Id);
                _imagemRepository.CadastrarImagens(imagens);
                GerenciadorArquivo.AnalisaDiretorio(imagens,produto.Id);
                //GerenciadorArquivo.RemoverPasta(produto.Id);
                ViewBag.Categorias = _categoriaRepository.ObterTodasCategorias().Select(c => new SelectListItem()
                { Text = c.Nome, Value = c.Id.ToString() }).ToList();
            }
            //return RedirectToAction(nameof(Atualizar));
            return View(produto);
        }
    }
}