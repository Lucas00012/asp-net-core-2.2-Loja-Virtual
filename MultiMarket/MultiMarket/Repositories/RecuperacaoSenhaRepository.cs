using MultiMarket.Database;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class RecuperacaoSenhaRepository : IRecuperacaoSenhaRepository
    {
        private MultiMarketContext _banco;
        public RecuperacaoSenhaRepository(MultiMarketContext banco)
        {
            _banco = banco;
        }
        public void Atualizar(DadosRecuperacaoSenha dados)
        {
            _banco.RecuperacaoSenhas.Update(dados);
            _banco.SaveChanges();
        }

        public void Cadastrar(DadosRecuperacaoSenha dados)
        {
            _banco.RecuperacaoSenhas.Add(dados);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            DadosRecuperacaoSenha dados = ObterRegistro(a => a.Id == id);
            _banco.RecuperacaoSenhas.Remove(dados);
            _banco.SaveChanges();
        }

        public DadosRecuperacaoSenha ObterRegistro(Expression<Func<DadosRecuperacaoSenha, bool>> expression)
        {
            return _banco.RecuperacaoSenhas.Where(expression).FirstOrDefault();
        }

        public List<DadosRecuperacaoSenha> ObterRegistros(Expression<Func<DadosRecuperacaoSenha, bool>> expression)
        {
            return _banco.RecuperacaoSenhas.Where(expression).ToList();
        }
    }
}
