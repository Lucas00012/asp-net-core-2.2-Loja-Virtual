using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiMarket.Database;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using MultiMarket.Models.ProdutoAgregador;
using MultiMarket.Repositories.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private MultiMarketContext _banco;
        private IConfiguration _conf;
        public PedidoRepository(MultiMarketContext banco, IConfiguration conf)
        {
            _banco = banco;
            _conf = conf;

        }

        public void Atualizar(Pedido pedido)
        {
            _banco.Pedidos.Update(pedido);
            _banco.SaveChanges();
        }

        public void Cadastrar(Pedido pedido)
        {
            _banco.Pedidos.Add(pedido);
            _banco.SaveChanges();
        }

        public int ContarRegistros()
        {
            return _banco.Pedidos.Count();
        }
        public decimal TotalVendas()
        {
            return _banco.Pedidos.Sum(a => a.ValorTotal);
        }

        public PaginationEngine<Pedido> GeneratePagination(int? pagina,Expression<Func<Pedido,bool>> expression=null,string pesquisa=null)
        {
            return new PaginationEngine<Pedido>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterPedidos(expression,pesquisa));
        }

        public Pedido ObterPedido(int Id)
        {
            return _banco.Pedidos.Include(a=>a.PedidoSituacoes).Where(a=>a.Id==Id).First();
        }
        public List<Pedido> ObterPedidos(Expression<Func<Pedido,bool>> expression=null,string pesquisa=null)
        {
            IQueryable<Pedido> Query = _banco.Pedidos.Include(a => a.PedidoSituacoes).Include(a=>a.Cliente);
            if (expression != null)
                Query = Query.Where(expression);
            if(pesquisa!=null)
                Query = Query.Where(a => a.Cliente.CPF.Replace("-","").Replace(".","").Contains(pesquisa.Trim()) || (a.Id.ToString()+a.TransactionId).Contains(pesquisa.Trim()));
            return Query.ToList();
        }

        public List<Pedido> ObterPedidosPorSituacao(string situacao)
        {
            return _banco.Pedidos.Include(a=>a.PedidoSituacoes).Where(a => a.Situacao == situacao).ToList();
        }
        public decimal[] PorcentagemBoletoCartao()
        {
            decimal[] res = new decimal[2];
            int total = ContarRegistros();
            res[0] = (decimal)_banco.Pedidos.Where(a=>a.FormaPagamento==TipoPagamentoConstant.BOLETO).Count()/total;
            res[1]= (decimal)_banco.Pedidos.Where(a => a.FormaPagamento == TipoPagamentoConstant.CARTAO_CREDITO).Count()/total;
            return res;
        }
    }
}
