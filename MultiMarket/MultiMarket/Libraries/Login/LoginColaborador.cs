using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiMarket.Libraries.Sessao;
using MultiMarket.Models;
using Newtonsoft.Json;
namespace MultiMarket.Libraries.Login
{
    public class LoginColaborador
    {
        private string Key = "Login.Colaborador";
        private Sessao.Sessao _sessao;
        public LoginColaborador(Sessao.Sessao sessao)
        {
            _sessao = sessao;

        }
        public void CriarLogin(Colaborador colaborador)
        {
            string JsonColaborador = JsonConvert.SerializeObject(colaborador);
            _sessao.Cadastrar(Key, JsonColaborador);
        }
        public Colaborador BuscaSessaoColaborador()
        {
            string JsonColaborador = _sessao.Consultar(Key);
            if (JsonColaborador != null)
                return JsonConvert.DeserializeObject<Colaborador>(JsonColaborador);
            return null;
        }
        public void Logout()
        {
            _sessao.Remover(Key);
        }
    }
}
