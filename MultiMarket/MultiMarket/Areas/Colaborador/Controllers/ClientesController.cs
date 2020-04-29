using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Models;
using MultiMarket.Repositories;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ClientesController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClientesController(IClienteRepository cliente)
        {
            _clienteRepository = cliente;
        }
        public IActionResult Index(int? pagina,string pesquisa)
        {
            return View(_clienteRepository.GeneratePagination(pagina,pesquisa));
        }
        [HttpGet]
        [ValidateRequest]
        public IActionResult AtivarDesativar(int id)
        {
            Models.Cliente cliente=_clienteRepository.ObterCliente(id);
            if (cliente.Status == "A") cliente.Status = "D";
            else cliente.Status = "A";
            _clienteRepository.Atualizar(cliente);
            TempData["MSG_S"] = "Status alterado com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}