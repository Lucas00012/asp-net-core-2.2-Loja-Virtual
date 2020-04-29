using Microsoft.EntityFrameworkCore;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Database
{
    public class MultiMarketContext:DbContext
    {
        public MultiMarketContext(DbContextOptions <MultiMarketContext> Options):base(Options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imagem> ImagensProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DadosRecuperacaoSenha> RecuperacaoSenhas { get; set; }
        public DbSet<PedidoSituacao> PedidosSituacao { get; set; }
    }
}
