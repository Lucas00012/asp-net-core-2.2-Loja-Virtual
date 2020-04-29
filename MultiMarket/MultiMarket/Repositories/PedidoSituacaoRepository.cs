using MultiMarket.Database;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class PedidoSituacaoRepository : IPedidoSituacaoRepository
    {
        private MultiMarketContext _banco;

        public PedidoSituacaoRepository(MultiMarketContext banco)
        {
            _banco = banco;
        }
        public void Atualizar(PedidoSituacao pedidoSituacao)
        {
            _banco.PedidosSituacao.Update(pedidoSituacao);
            _banco.SaveChanges();
        }

        public void Cadastrar(PedidoSituacao pedidoSituacao)
        {
            _banco.PedidosSituacao.Add(pedidoSituacao);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            PedidoSituacao pedidoSituacao = ObterPedidoSituacao(Id);
            _banco.PedidosSituacao.Remove(pedidoSituacao);
            _banco.SaveChanges();
        }

        public PedidoSituacao ObterPedidoSituacao(int Id)
        {
            return _banco.PedidosSituacao.Find(Id);
        }
    }
}
