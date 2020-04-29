using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        Produto ObterProduto(int Id);
        void DevolverEstoque(Pedido pedido);
        List<Produto> ObterTodosProdutos();
        void Atualizar(Produto produto);
        void Cadastrar(Produto produto);
        void Excluir(int Id);
        List<Produto> ObterProdutos(Expression<Func<Produto, bool>> expression);
        List<Produto> ObterTodosProdutos(int? pagina, string pesquisa, string ordem, List<Categoria> categorias);
        List<Produto> ObterTodosProdutos(int? pagina, string pesquisa,string ordem);
        List<Produto> ObterTodosProdutos(int? pagina, string pesquisa);
        PaginationEngine<Produto> GeneratePagination(int? pagina, string pesquisa, string ordem, List<Categoria> categorias);
        PaginationEngine<Produto> GeneratePagination(int? pagina,string pesquisa,string ordem);
        PaginationEngine<Produto> GeneratePagination(int? pagina, string pesquisa);
        Produto ObterProduto(Expression<Func<Produto, bool>> expression);
        int ContarRegistros();
    }
}
