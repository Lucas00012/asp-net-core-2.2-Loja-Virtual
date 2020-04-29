using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Json;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Repositories.Contracts;
using Newtonsoft.Json;

namespace MultiMarket.Controllers
{
    [ClienteAutorizacao]
    public class PedidoController : Controller
    {
        private IPedidoRepository _pedidoRepository;
        private LoginCliente _loginCliente;
        public PedidoController(IPedidoRepository pedidoRepository, LoginCliente loginCliente)
        {
            _pedidoRepository = pedidoRepository;
            _loginCliente = loginCliente;
        }
        public IActionResult Index(int id)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            if (pedido.ClienteId != _loginCliente.BuscaClienteSessao().Id)
            {
                return new ForbidResult();
            }
            ViewBag.Transacao = JsonConvert.DeserializeObject<TransacaoPagarMe>(pedido.DadosTransaction);
            ViewBag.Produtos = JsonConvert.DeserializeObject<List<ProdutoItem>>(pedido.DadosProdutos, new JsonSerializerSettings()
            {
                ContractResolver = new UndoJsonIgnore<List<ProdutoItem>>()
            });
            return View(pedido);
        }
    }
}