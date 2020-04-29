using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiMarket.Database;
using MultiMarket.Libraries.Email;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _repositoryCliente;
        private INewsletterRepository _repositoryNewsletter;
        private LoginCliente _loginCliente;
        private GerenciarEmail _email;
        private IProdutoRepository _produtoRepository;
        private ILogger<HomeController> _logger;

        //PARA INJETAR ALGUMA CLASSE, É NECESSÁRIO UM CONSTRUTOR. ELE CUIDOU DE INSTANCIAR A CLASSE
        //E FAZER AS COISAS NECESSARIAS PARA SER UTILIZADA 
        public HomeController(ILogger<HomeController> logger, IClienteRepository dbCliente,INewsletterRepository dbNewsletter,LoginCliente loginCliente,GerenciarEmail gerenciarEmail,IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _repositoryCliente = dbCliente;
            _repositoryNewsletter = dbNewsletter;
            _loginCliente = loginCliente;
            _email = gerenciarEmail;
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public IActionResult Index([FromForm]NewsletterEmail newsletter)
        {

            if (ModelState.IsValid)
            {
                if (_repositoryNewsletter.VerificarNewsletter(newsletter) == null)
                {
                    _repositoryNewsletter.Cadastrar(newsletter);
                    TempData["MSG_S"] = "E-mail cadastrado. Agora você receberá nossas promoções";
                }
                else
                {
                    TempData["MSG_S"] = "Seu e-mail já está cadastrado. Fique atento as nossas promoções";
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Index(int? pagina,string pesquisa,string ordem)
        {
            return View();
        }
        public IActionResult Categoria()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult ContatoAcao()
        {
            try
            {
                var MsgCliente = new Contactar();

                MsgCliente.Email = HttpContext.Request.Form["email"];
                MsgCliente.Mensagem = HttpContext.Request.Form["texto"];
                MsgCliente.Nome = HttpContext.Request.Form["nome"];

                var ListaMensagens = new List<ValidationResult>();
                var Contexto = new ValidationContext(MsgCliente);
                bool IsValid = Validator.TryValidateObject(MsgCliente, Contexto, ListaMensagens, true);

                if (IsValid)
                {
                    _email.SendEmailContato(MsgCliente);
                    ViewData["CLASSE"] = "alert alert-success";
                    ViewData["MSG_S"] = "Dados enviados com sucesso!";
                }
                else
                {
                    var Sb = new StringBuilder();
                    foreach (var a in ListaMensagens)
                    {
                        Sb.Append(a.ErrorMessage + "<br>");
                    }
                    ViewData["MSG_S"] = Sb.ToString();
                    ViewData["CLASSE"] = "alert alert-danger";
                    ViewData["ELEMENTO"] = MsgCliente;
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Home > ContatoAcao");
                ViewData["CLASSE"] = "alert alert-danger";
                ViewData["MSG_S"] = "Erro inesperado. Tente novamente mais tarde";
            }

            return View("Contato");

        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}