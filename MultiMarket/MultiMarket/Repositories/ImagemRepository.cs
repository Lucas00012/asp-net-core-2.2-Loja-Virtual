using MultiMarket.Database;
using MultiMarket.Models;
using MultiMarket.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class ImagemRepository : IImagemRepository
    {
        private MultiMarketContext _banco;
        public ImagemRepository(MultiMarketContext banco)
        {
            _banco = banco;
        }
        public void Atualizar(Imagem imagem)
        {
            _banco.ImagensProdutos.Update(imagem);
            _banco.SaveChanges();
        }

        public void Cadastrar(Imagem imagem)
        {
            _banco.ImagensProdutos.Add(imagem);
            _banco.SaveChanges();
        }
        public void CadastrarImagens(List<Imagem> imagens) 
        {
            if (imagens.Count > 0)
            {
                foreach (Imagem imagem in imagens)
                {
                    _banco.ImagensProdutos.Add(imagem);
                }
                _banco.SaveChanges();
            }
        }

        public void Excluir(int Id)
        {
            Imagem imagem = ObterImagem(Id);
            _banco.ImagensProdutos.Remove(imagem);
            _banco.SaveChanges();
        }

        public Imagem ObterImagem(int Id)
        {
            return _banco.ImagensProdutos.Find(Id);
        }
        public List<Imagem> ObterTodasImagens(int Id)
        {
            List<Imagem> imagens= _banco.ImagensProdutos.Where(a => a.ProdutoId == Id).ToList();
            return imagens;
        }
        public void ExcluirImagens(int Id)
        {
            List<Imagem> imagens = ObterTodasImagens(Id);
            foreach(Imagem imagem in imagens)
            {
                _banco.ImagensProdutos.Remove(imagem);
            }
            _banco.SaveChanges();
        }
    }
}
