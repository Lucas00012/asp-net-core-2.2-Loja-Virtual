using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    [ClienteAutorizacao]
    public class EnderecoEntregaController : Controller
    {
        private LoginCliente _loginCliente;
        private IEnderecoEntregaRepository _enderecoEntregaRepository;
        public EnderecoEntregaController(LoginCliente loginCliente,IEnderecoEntregaRepository enderecoEntregaRepository)
        {
            _loginCliente = loginCliente;
            _enderecoEntregaRepository = enderecoEntregaRepository;
        }
        public IActionResult Index()
        {
            List<EnderecoEntrega> enderecos= _enderecoEntregaRepository.ObterTodosEnderecos();
            return View(enderecos);
        }
        [HttpGet]
        [ClienteAutorizacao]
        public IActionResult CadastroEnderecoEntrega()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroEnderecoEntrega([FromForm]EnderecoEntrega enderecoEntrega, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                enderecoEntrega.ClienteId = _loginCliente.BuscaClienteSessao().Id;
                _enderecoEntregaRepository.Cadastrar(enderecoEntrega);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    TempData["MSG_S"] = "Registro cadastrado com sucesso!";
                    return RedirectToAction(nameof(CadastroEnderecoEntrega));
                }
                else
                    return Redirect(returnUrl);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            EnderecoEntrega endereco= _enderecoEntregaRepository.ObterEndereco(id);
            Models.Cliente cliente = _loginCliente.BuscaClienteSessao();
            if (endereco.ClienteId != cliente.Id)
                return new ForbidResult();
            return View(endereco);
        }
        [HttpPost]
        public IActionResult Atualizar(EnderecoEntrega enderecoEntrega)
        {
            if (ModelState.IsValid)
            {
                enderecoEntrega.ClienteId = _loginCliente.BuscaClienteSessao().Id;
                _enderecoEntregaRepository.Atualizar(enderecoEntrega);
                TempData["MSG_S"] = "Endereço atualizado com sucesso!";
                return RedirectToAction(nameof(Atualizar));
            }
            return View(enderecoEntrega);
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            EnderecoEntrega endereco = _enderecoEntregaRepository.ObterEndereco(id);
            Models.Cliente cliente = _loginCliente.BuscaClienteSessao();
            if (endereco.ClienteId != cliente.Id)
                return new ForbidResult();

            _enderecoEntregaRepository.Excluir(id);
            TempData["MSG_S"] = "Endereço excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}