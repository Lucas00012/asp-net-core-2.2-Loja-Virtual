using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiMarket.Database;
using MultiMarket.Libraries.Json;
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
    public class ProdutoRepository : IProdutoRepository
    {
        private MultiMarketContext _banco;
        private IConfiguration _conf;
        public ProdutoRepository(MultiMarketContext banco,IConfiguration configuration)
        {
            _conf = configuration;
            _banco = banco;
        }
        public void Atualizar(Produto produto)
        {
            _banco.Produtos.Update(produto);
            //_banco.Entry(produto).Property(x => x.Id).IsModified = false;
            _banco.SaveChanges();
        }
        public void Cadastrar(Produto produto)
        {
            _banco.Produtos.Add(produto);
            _banco.SaveChanges();
        }
        public void DevolverEstoque(Pedido pedido)
        {
            List<ProdutoItem> produtos = JsonConvert.DeserializeObject<List<ProdutoItem>>(pedido.DadosProdutos, new JsonSerializerSettings { ContractResolver = new UndoJsonIgnore<List<ProdutoItem>>() });
            foreach (var produto in produtos)
            {
                var produtoDB = ObterProduto(produto.Id);
                produto.Quantidade += produto.QuantidadeCarrinhoProduto;
                Atualizar(produtoDB);
            }
        }
        public int ContarRegistros()
        {
            return _banco.Produtos.Count();
        }

        public void Excluir(int Id)
        {
           Produto produto=_banco.Produtos.Find(Id);
            _banco.Produtos.Remove(produto);
            _banco.SaveChanges();
        }
        public PaginationEngine<Produto> GeneratePagination(int? pagina,string pesquisa,string ordem)
        {
            return new PaginationEngine<Produto>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosProdutos(pagina,pesquisa,ordem));
        }
        public PaginationEngine<Produto> GeneratePagination(int? pagina,string pesquisa)
        {
            return new PaginationEngine<Produto>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosProdutos(pagina, pesquisa));
        }

        public Produto ObterProduto(int Id)
        {
            return _banco.Produtos.Include(a=>a.ImagemProduto).Where(a=>a.Id==Id).First();
        }

        public List<Produto> ObterTodosProdutos()
        {
            return _banco.Produtos.ToList();
        }
        public List<Produto> ObterTodosProdutos(int? pagina, string pesquisa,string ordem)
        {
            int IntPagina = pagina ?? 1;
            IQueryable<Produto> database = _banco.Produtos.Include(a => a.Categoria).Include(a => a.ImagemProduto).AsQueryable();
            if (!string.IsNullOrEmpty(pesquisa))
                database = database.Where(a => a.Nome.Contains(pesquisa.Trim()));
            if (!string.IsNullOrEmpty(ordem))
                if (ordem == ">P")
                    database = database.OrderByDescending(a => a.Valor);
                else if (ordem == "<P")
                    database = database.OrderBy(a => a.Valor);
                else if (ordem == "N")
                    database = database.OrderBy(a => a.Nome);
            return database.ToList();
        }
        public List<Produto> ObterTodosProdutos(int? pagina,string pesquisa)
        {
            int IntPagina = pagina ?? 1;
            if (string.IsNullOrEmpty(pesquisa)) 
                return _banco.Produtos.Include(a=>a.Categoria).ToList();
            return _banco.Produtos.Include(a => a.Categoria).Include(a => a.ImagemProduto).Where(a => a.Nome.Contains(pesquisa.Trim())).ToList();


        }
        public Produto ObterProduto(Expression<Func<Produto, bool>> expression)
        {
            return _banco.Produtos.Include(a=>a.ImagemProduto).Include(a=>a.Categoria).Where(expression).FirstOrDefault();
        }

        public List<Produto> ObterTodosProdutos(int? pagina, string pesquisa, string ordem, List<Categoria> categorias)
        {
            int IntPagina = pagina ?? 1;
            IQueryable<Produto> database = _banco.Produtos.Include(a => a.ImagemProduto).AsQueryable();
            if (!string.IsNullOrEmpty(pesquisa))
                database = database.Where(a => a.Nome.Contains(pesquisa.Trim()));
            if (categorias != null && categorias.Count() > 0)
                database = database.Where(a => categorias.Any(b=>b.Id==a.CategoriaId));
            if (!string.IsNullOrEmpty(ordem))
                if (ordem == ">P")
                    database = database.OrderByDescending(a => a.Valor);
                else if (ordem == "<P")
                    database = database.OrderBy(a => a.Valor);
                else if (ordem == "N")
                    database = database.OrderBy(a => a.Nome);
            return database.ToList();
        }

        public PaginationEngine<Produto> GeneratePagination(int? pagina, string pesquisa, string ordem, List<Categoria> categorias)
        {
            return new PaginationEngine<Produto>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosProdutos(pagina, pesquisa, ordem, categorias));
        }

        public List<Produto> ObterProdutos(Expression<Func<Produto, bool>> expression)
        {
            return _banco.Produtos.Where(expression).ToList();
        }
    }
}
