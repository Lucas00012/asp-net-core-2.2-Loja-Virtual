using MultiMarket.Database;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiMarket.Libraries.Pagination;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace MultiMarket.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private MultiMarketContext _banco;
        private IConfiguration _conf;
        public ClienteRepository(MultiMarketContext banco,IConfiguration configuration)
        {
            _conf = configuration;
            _banco = banco;
        }
        public void Atualizar(Cliente cliente)
        {
            _banco.Clientes.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            cliente.Status = "A";
            _banco.Clientes.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Cliente cliente = ObterCliente(Id);
            _banco.Clientes.Remove(cliente);
        }
        public Cliente Login(string Email, string Senha)
        {
           return _banco.Clientes.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
        }

        public Cliente ObterCliente(int Id)
        {
           return _banco.Clientes.Find(Id);
        }
        public Cliente ObterCliente(Expression<Func<Cliente,bool>> expression)
        {
            return _banco.Clientes.Where(expression).FirstOrDefault();
        }
        public List<Cliente> ObterTodosClientes()
        {
            return _banco.Clientes.ToList();
        }
        public List<Cliente> ObterTodosClientes(int? pagina,string pesquisa)
        {
            int IntPage = pagina ?? 1;
            if (string.IsNullOrEmpty(pesquisa))
                return _banco.Clientes.ToList();
            return _banco.Clientes.Where(a => a.Email.Contains(pesquisa.Trim()) || a.Nome.Contains(pesquisa.Trim())).ToList();
        }
        public PaginationEngine<Cliente> GeneratePagination(int? pagina,string pesquisa)
        {
             return new PaginationEngine<Cliente>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosClientes(pagina,pesquisa));
        }
        public int ContarRegistros()
        {
            return _banco.Clientes.Count();
        }
        //Permite executar comandos sql
        //_banco.Clientes.FromSql("select * from Cliente where Nome='Lucas'").ToList();
    }
}
