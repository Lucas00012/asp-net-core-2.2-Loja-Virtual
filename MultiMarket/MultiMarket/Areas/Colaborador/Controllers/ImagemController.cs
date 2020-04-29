using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiMarket.Libraries.Arquivo;
using MultiMarket.Repositories.Contracts;

namespace MultiMarket.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ImagemController : Controller
    {
        private IImagemRepository _imagemRepository;
        public ImagemController(IImagemRepository imagemRepository)
        {
            _imagemRepository = imagemRepository;
        }
        //IActionResult --> INTERFACE DA CLASSE ActionResult
        //TANTO FAZ USAR UMA OU OUTRA !!!!! MAS POR CONVENÇÃO UTILIZAMOS SEMPRE A INTERFACE PARA REFERENCIAR AS CLASSES

        [HttpPost]
        public IActionResult Armazenar(IFormFile file)
        {
            var Caminho=GerenciadorArquivo.CadastrarImagensProduto(file);
            if (Caminho.Length > 0)
            {
                return Ok(new { caminho=Caminho}); //--> ISSO VOLTA UM OBJETO JSON QUE O JAVASCRIPT CONSEGUE LER
            }
            //VOLTA O STATUS HTTP 500 ---> ERRO NO SERVIDOR
            return new StatusCodeResult(500);
        }
        public IActionResult Deletar(string caminho)
        {
            if (GerenciadorArquivo.ExcluirImagensProduto(caminho))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}