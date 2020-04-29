using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiMarket.Database;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        //PEGAR VALOR DENTRO DO APP SETINGS
        //_configuration.GetValue<int>("RegistroPorPagina");
        private IConfiguration _conf;
        private MultiMarketContext _banco;
        private List<Categoria> _todasCategorias;
        public CategoriaRepository(MultiMarketContext banco,IConfiguration configuration)
        {
            _banco = banco;
            _conf=configuration;
            _todasCategorias = ObterTodasCategoriasNoTracking();
        }
        public void Atualizar(Categoria categoria)
        {
            _banco.Categorias.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Categorias.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Categoria categoria = ObterCategoria(Id);
            _banco.Categorias.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int Id)
        {
            return _banco.Categorias.Find(Id);
        }

        public List<Categoria> ObterTodasCategorias(int? pagina,string pesquisa)
        {
            int paginaConvertido = pagina??1;

            int skip = paginaConvertido * _conf.GetValue<int>("RegistroPorPagina") - _conf.GetValue<int>("RegistroPorPagina");
            if (string.IsNullOrEmpty(pesquisa))
                return _banco.Categorias.Include(a=>a.CategoriaPai).ToList();
            return _banco.Categorias.Include(a => a.CategoriaPai).Where(a=>a.Nome.Contains(pesquisa.Trim())).ToList();
        }
        public int ContarRegistros()
        {
            return _banco.Categorias.Count();
        }
        public PaginationEngine<Categoria> GeneratePagination(int? PageIndex,string pesquisa)
        {
            return new PaginationEngine<Categoria>(PageIndex, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodasCategorias(PageIndex,pesquisa));
        }

        public List<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias.ToList();
        }
        public List<Categoria> ObterTodasCategoriasNoTracking()
        {
            return _banco.Categorias.AsNoTracking().ToList();
        }
        public Categoria ObterCategoria(Expression<Func<Categoria, bool>> expression)
        {
            return _banco.Categorias.Where(expression).FirstOrDefault();
        }
        public Categoria ObterCategoriaNoTracking(Expression<Func<Categoria, bool>> expression)
        {
            return _banco.Categorias.AsNoTracking().Where(expression).FirstOrDefault();
        }

        private List<Categoria> CategoriasSlug=new List<Categoria>();
        public List<Categoria> VerificarCategoriasSlug(Categoria categoriaPai)
        {
            if (CategoriasSlug.Where(a => a.Id == categoriaPai.Id).Count() == 0) CategoriasSlug.Add(categoriaPai);
            if (_todasCategorias.Where(a => a.CategoriaPaiId == categoriaPai.Id).Count() == 0) return CategoriasSlug;
            List<Categoria> categorias = _todasCategorias.Where(a => a.CategoriaPaiId == categoriaPai.Id).ToList();
            CategoriasSlug.AddRange(categorias);
            foreach (Categoria categoria in categorias)
            {
                VerificarCategoriasSlug(categoria);
            }
            return CategoriasSlug;
        }

        public List<Categoria> ObterCategorias(Expression<Func<Categoria, bool>> expression)
        {
            return _banco.Categorias.Where(expression).ToList();
        }
    }
}
