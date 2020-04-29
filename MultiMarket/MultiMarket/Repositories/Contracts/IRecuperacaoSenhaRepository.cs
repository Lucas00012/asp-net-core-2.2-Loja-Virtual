using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories.Contracts
{
    public interface IRecuperacaoSenhaRepository
    {
        void Atualizar(DadosRecuperacaoSenha dados);
        void Excluir(int id);
        void Cadastrar(DadosRecuperacaoSenha dados);
        DadosRecuperacaoSenha ObterRegistro(Expression<Func<DadosRecuperacaoSenha, bool>> expression);
        List<DadosRecuperacaoSenha> ObterRegistros(Expression<Func<DadosRecuperacaoSenha, bool>> expression);


    }
}
