using MultiMarket.Database;
using MultiMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiMarket.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private MultiMarketContext _banco;

        //PARA INJETAR ALGUMA CLASSE, É NECESSÁRIO UM CONSTRUTOR. ELE CUIDOU DE INSTANCIAR A CLASSE
        //E FAZER AS COISAS NECESSARIAS PARA SER UTILIZADA 
        public NewsletterRepository(MultiMarketContext banco)
        {
            _banco = banco;
        }
        public void Atualizar(NewsletterEmail newsletter)
        {
            _banco.NewsletterEmails.Update(newsletter);
            _banco.SaveChanges();
        }

        public void Cadastrar(NewsletterEmail newsletter)
        {
            _banco.NewsletterEmails.Add(newsletter);
            _banco.SaveChanges();
        }

        public int ContarRegistros()
        {
            return _banco.NewsletterEmails.Count();
        }

        public void Excluir(int Id)
        {
            NewsletterEmail newsletter = ObterNewsletter(Id);
            _banco.NewsletterEmails.Remove(newsletter);
        }

        public NewsletterEmail ObterNewsletter(int Id)
        {
            return _banco.NewsletterEmails.Find(Id);
        }

        public List<NewsletterEmail> ObterTodasNewsletters()
        {
            return _banco.NewsletterEmails.ToList();
        }
        public NewsletterEmail VerificarNewsletter(NewsletterEmail newsletter)
        {
            return _banco.NewsletterEmails.Where(m => m.Email == newsletter.Email).FirstOrDefault();
        }
    }
}
