using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Sessao
{
    public class Sessao
    {
        private IHttpContextAccessor _sessao;
        public Sessao(IHttpContextAccessor sessao)
        {
            _sessao = sessao;
        }
        public void Cadastrar(string Key,string Valor)
        {
            _sessao.HttpContext.Session.SetString(Key, Valor);
        }
        public void Atualizar(string Key,string Valor)
        {
            if(Existe(Key)) _sessao.HttpContext.Session.Remove(Key);
            _sessao.HttpContext.Session.SetString(Key, Valor);
        }
        public void Remover(string Key)
        {
            _sessao.HttpContext.Session.Remove(Key);
        }
        public bool Existe(string Key)
        {
            if (_sessao.HttpContext.Session.GetString(Key)==null) return false;
            return true;
        }
        public string Consultar(string Key)
        {
            return _sessao.HttpContext.Session.GetString(Key);
        }
        public void RemoverTodos()
        {
            _sessao.HttpContext.Session.Clear();
        }
    }
}
