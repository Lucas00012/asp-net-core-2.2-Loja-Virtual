using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories.Contracts
{
    public interface IEnderecoEntregaRepository
    {
        EnderecoEntrega ObterEndereco(int Id);
        EnderecoEntrega ObterEndereco(Expression<Func<EnderecoEntrega, bool>> expression);
        List<EnderecoEntrega> ObterTodosEnderecos();
        void Atualizar(EnderecoEntrega endereco);
        List<EnderecoEntrega> ObterTodosEnderecos(string pesquisa);
        PaginationEngine<EnderecoEntrega> GeneratePagination(int? pagina, string pesquisa);
        void Cadastrar(EnderecoEntrega endereco);
        int ContarRegistros();
        void Excluir(int Id);
    }
}
