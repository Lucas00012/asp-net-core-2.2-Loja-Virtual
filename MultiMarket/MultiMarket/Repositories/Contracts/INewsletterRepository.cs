using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public interface INewsletterRepository
    {
        void Cadastrar(NewsletterEmail newsletter);
        void Atualizar(NewsletterEmail newsletter);
        void Excluir(int Id);
        int ContarRegistros();
        NewsletterEmail ObterNewsletter(int Id);
        NewsletterEmail VerificarNewsletter(NewsletterEmail newsletter);
        List<NewsletterEmail> ObterTodasNewsletters();
    }
}
