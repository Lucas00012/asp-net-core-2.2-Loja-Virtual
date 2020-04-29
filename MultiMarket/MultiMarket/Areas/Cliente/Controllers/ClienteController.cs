using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Email;
using MultiMarket.Libraries.Login;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class ClienteController : Controller
    {
        private LoginCliente _loginCliente;
        private IClienteRepository _clienteRepository;
        private IMapper _mapper;
        private IRecuperacaoSenhaRepository _recuperacaoSenhaRepository;
        private GerenciarEmail _gerenciarEmail;
        public ClienteController(GerenciarEmail gerenciarEmail,IRecuperacaoSenhaRepository recuperacaoSenhaRepository,LoginCliente loginCliente,IClienteRepository clienteRepository,IMapper mapper)
        {
            _loginCliente = loginCliente;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _recuperacaoSenhaRepository = recuperacaoSenhaRepository;
            _gerenciarEmail = gerenciarEmail;
        }
        [HttpGet]
        public IActionResult AtualizarDados()
        {
            Models.Cliente cliente = _loginCliente.BuscaClienteSessao();
            Models.Cliente clienteDB = _clienteRepository.ObterCliente(cliente.Id);
            return View(clienteDB);
        }
        [HttpPost]
        public IActionResult AtualizarDados(Models.Cliente cliente)
        {
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmacaoSenha");
            ModelState.Remove("Status");
            if (ModelState.IsValid)
            {
                Models.Cliente clienteDB = _clienteRepository.ObterCliente(_loginCliente.BuscaClienteSessao().Id);
                TempData["MSG_S"] = "Dados atualizados com sucesso!";

                clienteDB = _mapper.Map<Models.Cliente, Models.Cliente>(cliente,clienteDB);
                _clienteRepository.Atualizar(clienteDB);
                return RedirectToAction(nameof(AtualizarDados));
            }
            return View();
        }
        [HttpGet]
        public IActionResult RecuperarSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RecuperarSenha([FromForm]Models.Cliente cliente)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Nascimento");
            ModelState.Remove("Sexo");
            ModelState.Remove("CPF");
            ModelState.Remove("Telefone");
            ModelState.Remove("CEP");
            ModelState.Remove("Rua");
            ModelState.Remove("Cidade");
            ModelState.Remove("Bairro");
            ModelState.Remove("Numero");
            ModelState.Remove("Estado");
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmacaoSenha");
            if (ModelState.IsValid)
            {
                Models.Cliente clienteDB = _clienteRepository.ObterCliente(a => a.Email == cliente.Email);
                if (clienteDB != null)
                {
                    try
                    {
                        DadosRecuperacaoSenha dados = new DadosRecuperacaoSenha();
                        dados.ClienteId = clienteDB.Id;
                        dados.Data = DateTime.Now;
                        int verificador = CriarVerificador(clienteDB.Id);
                        dados.Chave = (verificador * 1000000 + new Random().Next(100000, 999999)) * 10 + clienteDB.Id % 10;
                        _gerenciarEmail.SendEmailRecuperarSenha(clienteDB, dados);
                        _recuperacaoSenhaRepository.Cadastrar(dados);
                        TempData["MSG_S"] = "E-mail enviado! Confira sua caixa de entrada";
                        return Redirect("/cliente/home/login");
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
        [Route("/cliente/RecuperarSenha/{Chave}")]
        public IActionResult SalvarNovaSenha(int Chave)
        {
            DadosRecuperacaoSenha dados= _recuperacaoSenhaRepository.ObterRegistro(a => a.Chave == Chave);
            if (dados == null || dados.Data.AddDays(1)<DateTime.Now) return new StatusCodeResult(400);
            return View();
        }
        [HttpPost]
        [Route("/cliente/RecuperarSenha/{Chave}")]
        public IActionResult SalvarNovaSenha([FromForm]Models.Cliente cliente,int Chave)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Nascimento");
            ModelState.Remove("Sexo");
            ModelState.Remove("CPF");
            ModelState.Remove("Telefone");
            ModelState.Remove("Email");
            ModelState.Remove("CEP");
            ModelState.Remove("Rua");
            ModelState.Remove("Cidade");
            ModelState.Remove("Bairro");
            ModelState.Remove("Numero");
            ModelState.Remove("Estado");
            if (ModelState.IsValid)
            {
                DadosRecuperacaoSenha dados = _recuperacaoSenhaRepository.ObterRegistro(a => a.Chave == Chave);
                Models.Cliente clienteDB = _clienteRepository.ObterCliente((int)dados.ClienteId);
                clienteDB.Senha = cliente.Senha;
                _recuperacaoSenhaRepository.Excluir(dados.Id);
                _clienteRepository.Atualizar(clienteDB);
                TempData["MSG_S"] = "A nova senha foi salva com sucesso!";
                return Redirect("/cliente/home/login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AtualizarSenha()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AtualizarSenha([FromForm]Models.Cliente cliente)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Nascimento");
            ModelState.Remove("Sexo");
            ModelState.Remove("CPF");
            ModelState.Remove("Telefone");
            ModelState.Remove("Email");
            ModelState.Remove("CEP");
            ModelState.Remove("Rua");
            ModelState.Remove("Cidade");
            ModelState.Remove("Bairro");
            ModelState.Remove("Numero");
            ModelState.Remove("Estado");
            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "Senha atualizada com sucesso!";
                Models.Cliente clienteDB = _clienteRepository.ObterCliente( _loginCliente.BuscaClienteSessao().Id);
                clienteDB.Senha = cliente.Senha;
                _clienteRepository.Atualizar(clienteDB);
                return Redirect("/cliente/home/painel");
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
            return mediaDigitos+qtdDigitos ;
        }
    }
}