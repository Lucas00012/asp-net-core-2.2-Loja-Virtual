using AutoMapper;
using Microsoft.Extensions.Configuration;
using MultiMarket.Database;
using MultiMarket.Libraries.Login;
using MultiMarket.Libraries.Pagination;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class EnderecoEntregaRepository:IEnderecoEntregaRepository
    {
        private MultiMarketContext _banco;
        private IConfiguration _configuration;
        private LoginCliente _loginCliente;
        private IMapper _mapper;
        public EnderecoEntregaRepository(MultiMarketContext banco, IConfiguration configuration,LoginCliente loginCliente,IMapper mapper)
        {
            _banco = banco;
            _configuration = configuration;
            _loginCliente = loginCliente;
            _mapper = mapper;
        }

        public void Cadastrar(EnderecoEntrega endereco)
        {
            _banco.EnderecosEntrega.Add(endereco);
            _banco.SaveChanges();
        }

        public int ContarRegistros()
        {
            return _banco.EnderecosEntrega.Count();
        }

        public void Atualizar(EnderecoEntrega endereco)
        {
            _banco.EnderecosEntrega.Update(endereco);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            EnderecoEntrega endereco= ObterEndereco(Id);
            _banco.EnderecosEntrega.Remove(endereco);
            _banco.SaveChanges();
        }

        public EnderecoEntrega ObterEndereco(Expression<Func<EnderecoEntrega,bool>> expression)
        {
            return _banco.EnderecosEntrega.Where(expression).FirstOrDefault();
        }

        public PaginationEngine<EnderecoEntrega> GeneratePagination(int? pagina, string pesquisa)
        {
            return new PaginationEngine<EnderecoEntrega>(pagina, _configuration.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosEnderecos(pesquisa));
        }

        public EnderecoEntrega ObterEndereco(int Id)
        {
            return _banco.EnderecosEntrega.Find(Id);
        }

        public List<EnderecoEntrega> ObterTodosEnderecos()
        {
            Cliente cliente = _loginCliente.BuscaClienteSessao();
            return _banco.EnderecosEntrega.Where(a=>a.ClienteId==cliente.Id).ToList();
        }

        public List<EnderecoEntrega> ObterTodosEnderecos(string pesquisa)
        {
            Cliente cliente = _loginCliente.BuscaClienteSessao();
            EnderecoEntrega endereco = new EnderecoEntrega();
            endereco = _mapper.Map<EnderecoEntrega>(cliente);

            IQueryable<EnderecoEntrega> query = _banco.EnderecosEntrega;
            if (string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(a => a.ClienteId == cliente.Id);
            }
            else
            {
                query = query.Where(a => a.Nome.Contains(pesquisa.Trim()) && a.ClienteId == cliente.Id);
                if (!cliente.Nome.Contains(pesquisa.Trim())) endereco = null;
            }
            List<EnderecoEntrega> lista = new List<EnderecoEntrega>();
            if (endereco != null)
                lista.Add(endereco);
            List<EnderecoEntrega> listaDB = query.ToList();
            foreach(var enderecoDB in listaDB)
                lista.Add(enderecoDB);
            return lista;
        }
    }
}
