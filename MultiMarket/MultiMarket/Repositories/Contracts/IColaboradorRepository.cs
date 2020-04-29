using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public interface IColaboradorRepository
    {
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void AtualizarSenha(Colaborador colaborador);
        void Excluir(int Id);
        Colaborador ObterColaborador(int Id);
        List<Colaborador> ObterTodosColaboradores();
        List<Colaborador> ObterTodosColaboradores(int? pagina,string pesquisa);
        PaginationEngine<Colaborador> GeneratePagination(int? pagina,string pesquisa);
        int ContarRegistros();
        Colaborador Login(string Email,string Senha);
        Colaborador ObterColaborador(Expression<Func<Colaborador, bool>> expression);
        List<Colaborador> ObterColaboradoresEmail(string Email);
    }
}
