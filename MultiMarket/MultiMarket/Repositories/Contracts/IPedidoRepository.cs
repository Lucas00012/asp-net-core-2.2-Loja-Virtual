using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories.Contracts
{
    public interface IPedidoRepository
    {
        void Cadastrar(Pedido pedido);
        decimal TotalVendas();
        decimal[] PorcentagemBoletoCartao();
        List<Pedido> ObterPedidos(Expression<Func<Pedido, bool>> expression = null,string pesquisa=null);
        void Atualizar(Pedido pedido);
        int ContarRegistros();
        Pedido ObterPedido(int Id);
        PaginationEngine<Pedido> GeneratePagination(int? pagina, Expression<Func<Pedido, bool>> expression = null,string pesquisa=null);
        List<Pedido> ObterPedidosPorSituacao(string situacao);
    }
}
