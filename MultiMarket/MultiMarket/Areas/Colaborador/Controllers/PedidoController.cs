using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Json;
using MultiMarket.Libraries.Pagamento;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Models.ViewModel;
using MultiMarket.Repositories.Contracts;
using Newtonsoft.Json;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [ColaboradorAutorizacao]
    [Area("Colaborador")]
    public class PedidoController : Controller
    {
        private IPedidoRepository _pedidoRepository;
        private IProdutoRepository _produtoRepository;
        private IPedidoSituacaoRepository _pedidoSituacaoRepository;
        private IMapper _mapper;
        private GerenciarPagarMe _gerenciarPagarMe;

        public PedidoController(IPedidoRepository pedidoRepository,IPedidoSituacaoRepository pedidoSituacaoRepository,IMapper mapper,GerenciarPagarMe gerenciarPagarMe,IProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoSituacaoRepository = pedidoSituacaoRepository;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _gerenciarPagarMe = gerenciarPagarMe;
        }
        public IActionResult Index(int? pagina,string pesquisa)
        {
            PaginationEngine<Pedido> pagination= _pedidoRepository.GeneratePagination(pagina,null,pesquisa);
            return View(pagination);
        }
        public IActionResult Visualizar(int id)
        {
            Pedido pedido= _pedidoRepository.ObterPedido(id);
            PedidoVisualizacaoViewModel viewModel = new PedidoVisualizacaoViewModel() { pedido = pedido };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult NFE(int id,[FromForm]PedidoVisualizacaoViewModel viewModel)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            ValidarFormulario("NFE");
            if (ModelState.IsValid)
            {
                pedido.Situacao = PedidoSituacaoConstant.NF_EMITIDA;
                pedido.NFE = viewModel.NFE;

                _pedidoRepository.Atualizar(pedido);
                SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.NF_EMITIDA);

                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });
            }
            ViewBag.MODAL_ID = "#modalNFE";
            viewModel.pedido = pedido;
            return View("Visualizar", viewModel);
        }
        [HttpPost]
        public IActionResult CodRastreamento(int id, [FromForm]PedidoVisualizacaoViewModel viewModel)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            ValidarFormulario("CodRastreamento");
            if (ModelState.IsValid)
            {
                pedido.Situacao = PedidoSituacaoConstant.EM_TRANSPORTE;
                pedido.FreteCodRastreamento = viewModel.CodRastreamento;

                _pedidoRepository.Atualizar(pedido);
                SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.EM_TRANSPORTE);

                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });

            }
            ViewBag.MODAL_ID = "#modalCodRastreamento";
            viewModel.pedido = pedido;
            return View("Visualizar", viewModel);
        }
        public IActionResult CancelarCartaoCompra(int id,[FromForm]PedidoVisualizacaoViewModel viewModel )
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            ValidarFormulario("estornoCartao");
            if (ModelState.IsValid)
            {
                if(pedido.FormaPagamento!=TipoPagamentoConstant.CARTAO_CREDITO) return new BadRequestResult();
                pedido.Situacao = PedidoSituacaoConstant.ESTORNO;

                _gerenciarPagarMe.EstornoCartao(pedido.TransactionId);
                _pedidoRepository.Atualizar(pedido);
                SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.ESTORNO, viewModel.estornoCartao);
                _produtoRepository.DevolverEstoque(pedido);

                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });
            }
            ViewBag.MODAL_ID = "#modalCartao";
            viewModel.pedido = pedido;
            return View("Visualizar",viewModel);
        }
        public IActionResult CancelarBoletoCompra(int id,[FromForm]PedidoVisualizacaoViewModel viewModel )
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            ValidarFormulario("estornoBoleto");
            if (ModelState.IsValid)
            {
                if (pedido.FormaPagamento != TipoPagamentoConstant.BOLETO) return new BadRequestResult();
                pedido.Situacao = PedidoSituacaoConstant.ESTORNO;

                if(_gerenciarPagarMe.EstornoBoleto(pedido.TransactionId, viewModel.estornoBoleto))
                {
                    _pedidoRepository.Atualizar(pedido);
                    SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.ESTORNO, viewModel.estornoBoleto);
                    _produtoRepository.DevolverEstoque(pedido);
                }
                else TempData["MSG_E"] = "Erro na comunicação com o servidor. Tente novamente";
                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });
            }
            ViewBag.MODAL_ID = "#modalBoleto";
            viewModel.pedido = pedido;
            return View("Visualizar", viewModel);
        }
        public IActionResult DevolucaoPedido(int id, [FromForm]PedidoVisualizacaoViewModel viewModel)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            ValidarFormulario("Devolucao");
            if (ModelState.IsValid)
            {
                if (pedido.Situacao != PedidoSituacaoConstant.ENTREGUE) return new BadRequestResult();
                pedido.Situacao = PedidoSituacaoConstant.DEVOLVER;

                SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.DEVOLVER, viewModel.Devolucao);
                _pedidoRepository.Atualizar(pedido);

                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });
            }
            ViewBag.MODAL_ID = "#modalDevolver";
            viewModel.pedido = pedido;
            return View("Visualizar", viewModel);
        }
        public IActionResult RejeitarDevolucao(int id, [FromForm]PedidoVisualizacaoViewModel viewModel)
        {
            ValidarFormulario("RejeitarDevolucao");
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            if (ModelState.IsValid)
            {
                if (pedido.Situacao != PedidoSituacaoConstant.DEVOLVER_ENTREGUE) return new BadRequestResult();
                pedido.Situacao = PedidoSituacaoConstant.DEVOLUCAO_REJEITADA;

                SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.DEVOLUCAO_REJEITADA, viewModel.RejeitarDevolucao);
                _pedidoRepository.Atualizar(pedido);

                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });
            }
            ViewBag.MODAL_ID = "#modalRejeitar";
            viewModel.pedido = pedido;
            return View("Visualizar", viewModel);
        }
        public IActionResult AprovarDevolucaoCartao(int id)
        {
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            if (pedido.Situacao != PedidoSituacaoConstant.DEVOLVER_ENTREGUE) return new BadRequestResult();
            pedido.Situacao = PedidoSituacaoConstant.DEVOLUCAO_ACEITA;

            _gerenciarPagarMe.EstornoCartao(pedido.TransactionId);
            SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.DEVOLVER_ESTORNO);
            _produtoRepository.DevolverEstoque(pedido);
            _pedidoRepository.Atualizar(pedido);

            return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });
        }
        public IActionResult AprovarDevolucaoBoleto(int id, [FromForm]PedidoVisualizacaoViewModel viewModel)
        {
            ValidarFormulario("estornoBoleto");
            Pedido pedido = _pedidoRepository.ObterPedido(id);
            if (ModelState.IsValid)
            {
                if (pedido.Situacao != PedidoSituacaoConstant.DEVOLVER_ENTREGUE) return new BadRequestResult();
                pedido.Situacao = PedidoSituacaoConstant.DEVOLUCAO_ACEITA;

                if(_gerenciarPagarMe.EstornoBoleto(pedido.TransactionId, viewModel.estornoBoleto))
                {
                    _produtoRepository.DevolverEstoque(pedido);
                    _pedidoRepository.Atualizar(pedido);
                    SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.DEVOLUCAO_ACEITA,viewModel.estornoBoleto);
                    SalvarPedidoSituacao(pedido, PedidoSituacaoConstant.DEVOLVER_ESTORNO);
                }
                else TempData["MSG_E"] = "Erro na comunicação com o servidor. Tente novamente";
                return RedirectToAction("Visualizar", "Pedido", new { area = "colaborador", id = id });

            }
            ViewBag.MODAL_ID = "#modalBoletoDevolucao";
            viewModel.pedido = pedido;
            return View("Visualizar",viewModel);
        }
        private void ValidarFormulario(string formulario,params string[] formulariosRemover)
        {
            var campos = new PedidoVisualizacaoViewModel().GetType().GetProperties();
            foreach(var campo in campos)
            {
                if (campo.Name != formulario) ModelState.Remove(campo.Name);
            }
            foreach(string formularioRemover in formulariosRemover)
            {
                ModelState.Remove(formularioRemover);
            }
        }
        private void SalvarPedidoSituacao(Pedido pedido,string situacao,object objeto = null)
        {
            PedidoSituacao pedidoSituacao = _mapper.Map<Pedido,PedidoSituacao>(pedido);
            pedidoSituacao.Situacao = situacao;
            if (objeto != null) pedidoSituacao.Dados = JsonConvert.SerializeObject(objeto);
            _pedidoSituacaoRepository.Cadastrar(pedidoSituacao);
        }
    }
}