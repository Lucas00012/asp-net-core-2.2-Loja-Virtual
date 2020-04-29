using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Email;
using MultiMarket.Libraries.Filtros;
using MultiMarket.Libraries.Texto;
using MultiMarket.Models;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao("G")]
    public class ColaboradoresController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;
        private GerenciarEmail _email;
        private IRecuperacaoSenhaRepository _recuperacaoSenhaRepository;
        public ColaboradoresController(IRecuperacaoSenhaRepository recuperacaoSenhaRepository, IColaboradorRepository colaboradorRepository,GerenciarEmail gerenciarEmail)
        {
            _email = gerenciarEmail;
            _colaboradorRepository = colaboradorRepository;
            _recuperacaoSenhaRepository = recuperacaoSenhaRepository;
        }
        public IActionResult Index(int? pagina,string pesquisa)
        {
            return View(_colaboradorRepository.GeneratePagination(pagina,pesquisa));
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar([FromForm]Models.Colaborador colaborador)
        {
            //IGNORA VALIDACAO DE Senha e ConfirmacaoSenha
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmacaoSenha");
            if (ModelState.IsValid) {
                try {
                    colaborador.Tipo = "C";
                    colaborador.Senha = KeyGenerator.GetUniqueKey(8);
                    _email.SendEmailColaborador(colaborador);
                    _colaboradorRepository.Cadastrar(colaborador);
                    TempData["MSG_S"] = "Colaborador cadastrado com sucesso!";
                    return new RedirectResult(nameof(Cadastrar));
                }
                catch
                {
                    TempData["MSG_E"] = "Erro inesperado. Tente novamente mais tarde";
                }
                return View();
            }
            
            return View();
        }
        [HttpGet]
        [ValidateRequest]
        public IActionResult GerarSenha(int id)
        {
            try { 
                var colaborador=_colaboradorRepository.ObterColaborador(id);
                colaborador.Senha = KeyGenerator.GetUniqueKey(8);
                _email.SendEmailColaborador(colaborador);
                _colaboradorRepository.AtualizarSenha(colaborador);
                TempData["MSG_S"] = "Senha gerada com sucesso!";
            }
            catch
            {
                TempData["MSG_E"] = "Erro inesperado. Tente novamente mais tarde!";
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            return View(_colaboradorRepository.ObterColaborador(id));
        }
        [HttpPost]
        public IActionResult Atualizar([FromForm]Models.Colaborador colaborador)
        {
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmacaoSenha");
            if (ModelState.IsValid)
            {
                _colaboradorRepository.Atualizar(colaborador);
                TempData["MSG_S"] = "Registro atualizado com sucesso!";
            }
            return RedirectToAction(nameof(Atualizar));
        }
        [HttpGet]
        [ValidateRequest]
        public IActionResult Excluir(int id)
        {
            TempData["MSG_S"] = "Registro excluído com sucesso!";
            _colaboradorRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}