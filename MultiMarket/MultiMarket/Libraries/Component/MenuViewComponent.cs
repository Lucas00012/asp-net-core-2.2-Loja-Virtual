using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MultiMarket.Models;
using MultiMarket.Repositories;

namespace MultiMarket.Libraries.Component
{
    public class MenuViewComponent : ViewComponent
    {
        private ICategoriaRepository _categoriaRepository;
        public MenuViewComponent(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        //PODE RECEBER PARAMETROS
        //SEU RETORNO DEVE SER CRIADO NA PASTA Shared->Components->Nome(No caso Menu)
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Categoria> categorias = _categoriaRepository.ObterTodasCategorias();
            return View(categorias);
        }
    }
}
