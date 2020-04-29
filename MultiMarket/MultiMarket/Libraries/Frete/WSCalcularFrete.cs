using Microsoft.Extensions.Configuration;
using MultiMarket.Models.Correios;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Frete
{
    public class WSCalcularFrete
    {
        private IConfiguration _conf;
        private CalcPrecoPrazoWSSoap _WSCorreios;
        public WSCalcularFrete(IConfiguration configuration, CalcPrecoPrazoWSSoap WSCorreios)
        {
            _conf = configuration;
            _WSCorreios = WSCorreios;
        }
        public async Task<ValorPrazoFrete> CalcularFrete(string cepDestino,string tipoFrete,List<Pacote> pacotes)
        {
            List<ValorPrazoFrete> ValorPacotesPorFrete = new List<ValorPrazoFrete>();
            foreach(var pacote in pacotes)
            {
                var resultado = await (CalcularValorPrazoFrete(cepDestino, tipoFrete, pacote));

                if(resultado!=null)
                ValorPacotesPorFrete.Add(resultado);
            }
            if (ValorPacotesPorFrete.Count() > 0)
            {
                ValorPrazoFrete ValorDosFretes = ValorPacotesPorFrete.GroupBy(a => a.TipoFrete).Select(list => new ValorPrazoFrete
                {
                    TipoFrete = list.First().TipoFrete,
                    Valor = list.Sum(c => c.Valor),
                    Prazo = list.Max(c => c.Prazo),
                }).ToList().First();
                return ValorDosFretes;
            }
            return null;

        }
        private async Task<ValorPrazoFrete> CalcularValorPrazoFrete(string cepDestino,string tipoFrete,Pacote pacote)
        {
            var CepOrigem=_conf.GetValue<string>("WSCorreios:CepOrigem");
            var MaoPropria=_conf.GetValue<string>("WSCorreios:MaoPropria");
            var AvisoRecebimento=_conf.GetValue<string>("WSCorreios:AvisoRecebimento");

            decimal comprimento= pacote.Comprimento ?? 0;
            decimal largura= pacote.Largura ?? 0;
            decimal altura= pacote.Altura ?? 0;

            var diametro = Math.Max(Math.Max(comprimento, largura), altura);

            cResultado resultado=await _WSCorreios.CalcPrecoPrazoAsync("","",tipoFrete,CepOrigem,cepDestino,pacote.Peso.ToString(),1,comprimento,altura,largura,diametro,MaoPropria,0,AvisoRecebimento);
            if (resultado.Servicos[0].Erro == "0")
            {
                return new ValorPrazoFrete()
                {
                    TipoFrete = tipoFrete,
                    Prazo = int.Parse(resultado.Servicos[0].PrazoEntrega),
                    Valor = double.Parse(resultado.Servicos[0].Valor.Replace(".", "")),
                };
            }
            else if (resultado.Servicos[0].Erro == "008" || resultado.Servicos[0].Erro == "-888")
            {
                return null;
            }
            else
            {
                throw new Exception("Erro: " + resultado.Servicos[0].MsgErro);
            }
        
        }
    }
}
