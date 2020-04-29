using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Email;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;
        private LoginColaborador _loginColaborador;
        private IClienteRepository _clienteRepository;
        private IProdutoRepository _produtoRepository;
        private INewsletterRepository _newsletterRepository;
        private IPedidoRepository _pedidoRepository;
        private IRecuperacaoSenhaRepository _recuperacaoSenhaRepository;
        private GerenciarEmail _email;
        public HomeController(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, INewsletterRepository newsletterRepository, IClienteRepository clienteRepository,GerenciarEmail email, IRecuperacaoSenhaRepository recuperacaoSenhaRepository, IColaboradorRepository colaboradorRepository,LoginColaborador loginColaborador)
        {
            _clienteRepository = clienteRepository;
            _colaboradorRepository = colaboradorRepository;
            _loginColaborador = loginColaborador;
            _newsletterRepository = newsletterRepository;
            _recuperacaoSenhaRepository = recuperacaoSenhaRepository;
            _pedidoRepository = pedidoRepository;
            _email = email;
            _produtoRepository = produtoRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //EVITA FAZER LOGIN DE OUTRAS PAGINAS QUE NAO SEJAM DO PROPRIO SITE (CSRF)
        //[ValidateAntiForgeryToken]
        public IActionResult Login([FromForm]Models.Colaborador colaborador)
        {
            Models.Colaborador UserColaborador = _colaboradorRepository.Login(colaborador.Email, colaborador.Senha);
            if (UserColaborador != null)
            {

                _loginColaborador.CriarLogin(UserColaborador);

                return new RedirectResult(nameof(Painel));
            }
            ViewData["MSG_E"] = "Colaborador não localizado";
            return View();
        }

        [ColaboradorAutorizacaoAttribute]
        public IActionResult Painel()
        {
            ViewBag.Clientes = _clienteRepository.ContarRegistros();
            ViewBag.Newsletter = _newsletterRepository.ContarRegistros();
            ViewBag.Produto = _produtoRepository.ContarRegistros();
            ViewBag.NumeroPedidos = _pedidoRepository.ContarRegistros();
            ViewBag.ValorTotalPedidos = _pedidoRepository.TotalVendas();
            decimal[] res = _pedidoRepository.PorcentagemBoletoCartao();
            ViewBag.PorcentagemBoletoBancario = Math.Round(res[0],2);
            ViewBag.PorcentagemCartao = Math.Round(res[1],2);
            return View();
        }
        [HttpGet]
        public IActionResult GerarCsvNewsletter()
        {
            List <NewsletterEmail> newsletters= _newsletterRepository.ObterTodasNewsletters();
            string Dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "temp", "newsletter.csv");
            using (StreamWriter sw = new StreamWriter(Dir))
            {
                foreach(var newsletter in newsletters)
                {
                    sw.WriteLine(newsletter.Email);
                }
            }
            byte[] bytes= System.IO.File.ReadAllBytes(Dir);
            return File(bytes, "application/octet-stream", "newsletter.csv");
        }
        [HttpGet]
        public IActionResult RecuperarSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecuperarSenha([FromForm]Models.Colaborador colaborador)
        {
            if (colaborador.Email != null)
            {
                Models.Colaborador colaboradorDB = _colaboradorRepository.ObterColaborador(a => a.Email == colaborador.Email);
                if (colaboradorDB != null)
                {
                    try
                    {
                        DadosRecuperacaoSenha dados = new DadosRecuperacaoSenha();
                        dados.ColaboradorId = colaboradorDB.Id;
                        dados.Data = DateTime.Now;
                        int verificador = CriarVerificador(colaboradorDB.Id);
                        dados.Chave = (verificador * 1000000 + new Random().Next(100000, 999999)) * 10 + colaboradorDB.Id % 10;
                        _email.SendEmailRecuperarSenha(colaboradorDB, dados, false);
                        _recuperacaoSenhaRepository.Cadastrar(dados);
                        TempData["MSG_S"] = "E-mail enviado! Confira sua caixa de entrada";
                        return Redirect("/colaborador/home/login");
                    }
                    catch
                    {
                        ViewData["MSG_E"] = "Oops! Houve um problema no sistema! Tente novamente";
                    }
                }
                else ViewData["MSG_E"] = "O e-mail não consta em nosso sistema!";
            }
            return View();
        }
        [HttpGet]
        [Route("/colaborador/RecuperarSenha/{Chave}")]
        public IActionResult SalvarNovaSenha(int Chave)
        {
            DadosRecuperacaoSenha dados = _recuperacaoSenhaRepository.ObterRegistro(a => a.Chave == Chave);
            if (dados == null || dados.Data.AddDays(1) < DateTime.Now) return new StatusCodeResult(400);
            return View();
        }
        [HttpPost]
        [Route("/colaborador/RecuperarSenha/{Chave}")]
        public IActionResult SalvarNovaSenha([FromForm]Models.Colaborador colaborador, int Chave)
        {
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                DadosRecuperacaoSenha dados = _recuperacaoSenhaRepository.ObterRegistro(a => a.Chave == Chave);
                Models.Colaborador colaboradorDB = _colaboradorRepository.ObterColaborador((int)dados.ColaboradorId);
                colaboradorDB.Senha = colaborador.Senha;
                _recuperacaoSenhaRepository.Excluir(dados.Id);
                _colaboradorRepository.Atualizar(colaboradorDB);
                TempData["MSG_S"] = "A nova senha foi salva com sucesso!";
                return Redirect("/colaborador/home/login");
            }
            return View();
        }
        private int CriarVerificador(int id)
        {
            int mediaDigitos = 0;
            int qtdDigitos = 0;
            while (id != 0)
            {
                qtdDigitos++;
                mediaDigitos += id % 10;
                id /= 10;

            }
            mediaDigitos /= qtdDigitos;
            return mediaDigitos + qtdDigitos;
        }
        [ColaboradorAutorizacao]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction("Login", "Home");//new { area = "" }
        }
    }
}