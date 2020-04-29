using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private IClienteRepository _clienteRepository;
        private LoginCliente _loginCliente;
        private IEnderecoEntregaRepository _enderecoEntregaRepository;
        public HomeController(IClienteRepository clienteRepository,LoginCliente loginCliente,IEnderecoEntregaRepository endereco)
        {
            _clienteRepository = clienteRepository;
            _loginCliente = loginCliente;
            _enderecoEntregaRepository = endereco;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm]Models.Cliente cliente, string returnUrl)
        {
            Models.Cliente Cliente = _clienteRepository.Login(cliente.Email, cliente.Senha);
            if (Cliente != null)
            {
                _loginCliente.CriarLogin(Cliente);

                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Painel));
                else
                    return Redirect(returnUrl);
            }
            ViewData["MSG_E"] = "Cliente não localizado";
            return View();
        }


        [HttpGet]
        [ClienteAutorizacaoAttribute]
        public IActionResult Painel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Models.Cliente cliente, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                _clienteRepository.Cadastrar(cliente);
                _loginCliente.CriarLogin(cliente);

                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Painel));

                return Redirect(returnUrl);
            }
            return View();
        }

        [ClienteAutorizacao]
        public IActionResult Logout()
        {
            _loginCliente.Logout();
            return RedirectToAction("Index","Home",new { area="" } );
        }
    }
}