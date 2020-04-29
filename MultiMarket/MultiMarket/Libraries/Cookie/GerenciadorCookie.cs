using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MultiMarket.Libraries.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Cookie
{
    public class GerenciadorCookie
    {
        private IHttpContextAccessor _context;
        private IConfiguration _conf;
        public GerenciadorCookie(IHttpContextAccessor context,IConfiguration configuration)
        {
            _context = context;
            _conf = configuration;
        }
        public void Cadastrar(string Key, string valor)
        {
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            options.IsEssential = true;

            var ValorCrypt = StringCipher.Encrypt(valor, _conf.GetValue<string>("CryptKey"));

            _context.HttpContext.Response.Cookies.Append(Key, ValorCrypt, options);
        }
        public void Excluir(string Key)
        {
            if (Existe(Key))
                _context.HttpContext.Response.Cookies.Delete(Key);
        }
        public void Atualizar(string Key, string valor)
        {
            if (Existe(Key))
                Excluir(Key);
            Cadastrar(Key, valor);
        }
        public string Consultar(string Key,bool Crypt=true)
        {
            var Valor = _context.HttpContext.Request.Cookies[Key];
            if(Crypt)
                Valor = StringCipher.Decrypt(Valor, _conf.GetValue<string>("CryptKey"));
            return Valor;
        }
        public bool Existe(string Key)
        {
            if (_context.HttpContext.Request.Cookies[Key] == null) return false;
            return true;
        }
        public void ExcluirTodos()
        {
            var Cookies = _context.HttpContext.Request.Cookies.ToList();
            foreach(var cookie in Cookies)
            {
                Excluir(cookie.Key);
            }
        }
    }
}
