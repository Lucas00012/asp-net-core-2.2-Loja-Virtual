using MultiMarket.Libraries.Cookie;
using MultiMarket.Models.Correios;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using MultiMarket.Libraries.Texto;

namespace MultiMarket.Libraries.Frete
{
    public class CookieValorPrazoFrete
    {
        private string Key = "Carrinho.ValorPrazoFrete";
        private GerenciadorCookie _cookie;
        public CookieValorPrazoFrete(GerenciadorCookie cookie)
        {
            _cookie = cookie;
        }
        public void Cadastrar(Models.Correios.Frete frete)
        {
            var lista = Consultar();
            if (lista.Count() > 0)
            {
                var elemento = lista.Where(a => a.CEP == frete.CEP).FirstOrDefault();
                if (elemento == null)
                    lista.Add(frete);
                else
                {
                    elemento.CarrinhoId = frete.CarrinhoId;
                    elemento.Valores = frete.Valores;
                }
            }
            else
            {
                lista.Add(frete);
            }
            Salvar(lista);
        }
        public List<Models.Correios.Frete> Consultar()
        {
            if (_cookie.Existe(Key))
            {
                List<Models.Correios.Frete> lista = JsonConvert.DeserializeObject<List<Models.Correios.Frete>>(_cookie.Consultar(Key));
                return lista;
            }
            return new List<Models.Correios.Frete>();
        }
        public void Salvar(List<Models.Correios.Frete> fretes)
        {
            string JsonLista = JsonConvert.SerializeObject(fretes);
            _cookie.Cadastrar(Key, JsonLista);
        }

        public void RemoverTodos()
        {
            _cookie.Excluir(Key);
        }
        public void RemoverFrete(Models.Correios.Frete frete)
        {
            var lista = Consultar();
            var item = lista.Where(a => a.CEP == frete.CEP).FirstOrDefault();
            if (item != null)
            {
                lista.Remove(item);
                Salvar(lista);
            }
        }
    }
}
