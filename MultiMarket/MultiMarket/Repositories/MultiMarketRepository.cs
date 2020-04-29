using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MultiMarket.Database;
using MultiMarket.Libraries.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class MultiMarketRepository<T> where T:class
    {
        private MultiMarketContext _banco;
        private IConfiguration _configuration;
        DbSet<T> dbSet;
        public MultiMarketRepository(MultiMarketContext banco,IConfiguration configuration)
        {
            _banco = banco;
            dbSet = _banco.Set<T>();
            _configuration = configuration;
        }
        public List<T> GetAll(Expression<Func<T,bool>> expression = null)
        {
            if (expression != null) return dbSet.Where(expression).ToList();
            return dbSet.ToList();
        }
        public List<T> GetAll(int? page)
        {
            int Page = page ?? 1;
            return dbSet.Skip((Page-1)* _configuration.GetValue<int>("RegistroPorPagina")).Take(_configuration.GetValue<int>("RegistroPorPagina")).ToList();
        }
        public PaginationEngine<T> GetPagination(int? page)
        {
            return new PaginationEngine<T>(page, _configuration.GetValue<int>("RegistroPorPagina"),CountRegister(), GetAll(page));
        }
        public int CountRegister()
        {
            return dbSet.Count();
        }
    }
}
