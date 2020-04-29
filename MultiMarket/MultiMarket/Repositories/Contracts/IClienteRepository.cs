using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiMarket.Libraries.Pagination;
using System.Linq.Expressions;

namespace MultiMarket.Repositories
{
    public interface IClienteRepository
    {
        Cliente Login(string Email, String Senha);
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int Id);
        Cliente ObterCliente(int Id);
        Cliente ObterCliente(Expression<Func<Cliente, bool>> expression);
        List<Cliente> ObterTodosClientes();
        List<Cliente> ObterTodosClientes(int? pagina,string pesquisa);
        PaginationEngine<Cliente> GeneratePagination(int? pagina,string pesquisa);
        int ContarRegistros();
    }
}
