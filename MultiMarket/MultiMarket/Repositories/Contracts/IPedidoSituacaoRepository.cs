using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Repositories.Contracts
{
    public interface IPedidoSituacaoRepository
    {
        void Cadastrar(PedidoSituacao pedidoSituacao);
        void Atualizar(PedidoSituacao pedidoSituacao);
        void Excluir(int Id);

        PedidoSituacao ObterPedidoSituacao(int Id);
    }
}
