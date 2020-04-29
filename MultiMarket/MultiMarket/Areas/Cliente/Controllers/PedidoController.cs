using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Login;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    [ClienteAutorizacao]
    public class PedidoController : Controller
    {
        private LoginCliente _loginCliente;
        private IPedidoRepository _pedidoRepository;
        public PedidoController(LoginCliente loginCliente,IPedidoRepository pedidoRepository)
        {
            _loginCliente = loginCliente;
            _pedidoRepository = pedidoRepository;
        }
        public IActionResult Index(int? pagina)
        {
            Models.Cliente cliente = _loginCliente.BuscaClienteSessao();
            PaginationEngine<Pedido> pedidos = _pedidoRepository.GeneratePagination(pagina, a => a.ClienteId == cliente.Id);
            return View(pedidos);
        }
        public IActionResult Visualizar(int id)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            Models.Cliente cliente = _loginCliente.BuscaClienteSessao();
            if (cliente.Id != pedido.ClienteId)
            {
                return new ForbidResult();
            }
            return View(pedido);
        }
    }
}