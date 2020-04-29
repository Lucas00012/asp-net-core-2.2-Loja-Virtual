using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Repositories.Contracts
{
    public interface IImagemRepository
    {
        void Cadastrar(Imagem imagem);
        void Excluir(int Id);
        void Atualizar(Imagem imagem);
        Imagem ObterImagem(int Id);
        List<Imagem> ObterTodasImagens(int Id);
        void ExcluirImagens(int Id);
        void CadastrarImagens(List<Imagem> imagens);

    }
}
