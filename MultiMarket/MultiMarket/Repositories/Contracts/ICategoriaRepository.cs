using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public interface ICategoriaRepository
    {
        void Cadastrar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Excluir(int Id);
        Categoria ObterCategoria(int Id);
        Categoria ObterCategoria(Expression<Func<Categoria, bool>> expression);
        List<Categoria> ObterCategorias(Expression<Func<Categoria, bool>> expression);
        Categoria ObterCategoriaNoTracking(Expression<Func<Categoria, bool>> expression);
        List<Categoria> ObterTodasCategorias(int? pagina,string pesquisa);
        List<Categoria> ObterTodasCategorias();
        int ContarRegistros();
        PaginationEngine<Categoria> GeneratePagination(int? PageIndex,string pesquisa);
        List<Categoria> VerificarCategoriasSlug(Categoria categoriaPai);
    }
}
