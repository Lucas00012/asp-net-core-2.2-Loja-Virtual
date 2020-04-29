using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MultiMarket.Models
{
    public class PedidoSituacaoConstant
    {
        public const string AGUARDANDO_PAGAMENTO="AGUARDANDO PAGAMENTO";
        public const string PAGAMENTO_APROVADO = "PAGAMENTO APROVADO";
        public const string PAGAMENTO_NAO_REALIZADO = "PAGAMENTO NÃO REALIZADO";
        public const string NF_EMITIDA = "NF EMITIDA";
        public const string EM_TRANSPORTE = "EM TRANSPORTE";
        public const string ENTREGUE = "ENTREGUE";

        public const string DEVOLVER = "DEVOLVER (EM TRANSPORTE)";
        public const string DEVOLVER_ENTREGUE = "DEVOLVER (ENTREGUE)";
        public const string DEVOLUCAO_ACEITA = "DEVOLUÇÃO ACEITA";
        public const string DEVOLUCAO_REJEITADA = "DEVOLUÇÃO REJEITADA";
        public const string DEVOLVER_ESTORNO = "DEVOLVER (ESTORNADO)";



        public const string FINALIZADO = "FINALIZADO";
        public const string EM_CANCELAMENTO = "EM CANCELAMENTO";
        public const string EM_ANALISE = "EM ANÁLISE";
        public const string ESTORNO = "ESTORNADO";
        public const string PAGAMENTO_REJEITADO = "PAGAMENTO REJEITADO";

        public static string ObterNome(string campo)
        {
            foreach(FieldInfo constant in typeof(PedidoSituacaoConstant).GetFields())
            {
                if ((string)constant.GetValue(null) == campo)
                    return constant.Name;
            }
            return "";
        }
    }
}
