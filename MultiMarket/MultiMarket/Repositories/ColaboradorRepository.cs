using Microsoft.EntityFrameworkCore;
using MultiMarket.Database;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace MultiMarket.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private MultiMarketContext _banco;
        private IConfiguration _conf;
        public ColaboradorRepository(MultiMarketContext banco,IConfiguration configuration) 
        {
            _conf = configuration;
            _banco = banco;
        }
        public void Atualizar(Colaborador colaborador)
        {
            _banco.Colaboradores.Update(colaborador);

            //NÃO MUDA A PROPRIEDADE NO BANCO DE DADOS
            //OBS: SINALIZAR DEPOIS DE DAR UPDATE
            _banco.Entry(colaborador).Property(x => x.Id).IsModified = false;
            _banco.Entry(colaborador).Property(x => x.Tipo).IsModified = false;
            _banco.Entry(colaborador).Property(x => x.Senha).IsModified = false;
            _banco.SaveChanges();
        }
        public void AtualizarSenha(Colaborador colaborador)
        {
            _banco.Colaboradores.Update(colaborador);
            _banco.Entry(colaborador).Property(x => x.Id).IsModified = false;
            _banco.Entry(colaborador).Property(x => x.Tipo).IsModified = false;
            _banco.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Colaboradores.Add(colaborador);
            _banco.SaveChanges();
        }

        public int ContarRegistros()
        {
            return _banco.Colaboradores.Count();
        }

        public void Excluir(int Id)
        {
            Colaborador colaborador = ObterColaborador(Id);
            _banco.Colaboradores.Remove(colaborador);
            _banco.SaveChanges();
        }

        public PaginationEngine<Colaborador> GeneratePagination(int? pagina,string pesquisa)
        {
            return new PaginationEngine<Colaborador>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosColaboradores(pagina,pesquisa));
        }

        public Colaborador Login(string Email, string Senha)
        {
            return _banco.Colaboradores.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public List<Colaborador> ObterTodosColaboradores()
        {
            return _banco.Colaboradores.Where(a=>a.Tipo!="G").ToList();
        }

        public List<Colaborador> ObterTodosColaboradores(int? pagina,string pesquisa)
        {
            int paginaInt = pagina ?? 1;
            if(string.IsNullOrEmpty(pesquisa))
                return _banco.Colaboradores.Where(a => a.Tipo != "G").ToList();
            return _banco.Colaboradores.Where(a => a.Tipo != "G" && a.Nome.Contains(pesquisa.Trim())).ToList();
        }
        public List<Colaborador> ObterColaboradoresEmail(string Email)
        {
            //EVITA TRACKEAR O OBJETO
            return _banco.Colaboradores.Where(a => a.Email == Email).AsNoTracking().ToList();
        }

        public Colaborador ObterColaborador(Expression<Func<Colaborador, bool>> expression)
        {
            return _banco.Colaboradores.Where(expression).FirstOrDefault();
        }
    }
}
