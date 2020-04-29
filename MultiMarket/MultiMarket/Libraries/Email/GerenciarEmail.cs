using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MultiMarket.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace MultiMarket.Libraries.Email
{
    public class GerenciarEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _conf;
        private IHttpContextAccessor _httpContextAccessor;
        public GerenciarEmail(SmtpClient smtpClient,IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {
            _smtp = smtpClient;
            _conf = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public void SendEmailContato(Contactar Dados)
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(_conf.GetValue<string>("Email:Username"));
            Msg.To.Add("lucaseduardoormond@gmail.com");
            Msg.Subject = "MultiMarket";
            Msg.Body = string.Format("Mensagem automática de validação \n{0}\n{1}\n{2}\n",Dados.Nome,Dados.Email,Dados.Mensagem);

            _smtp.Send(Msg);

        }
        public void SendEmailColaborador(Colaborador colaborador)
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(_conf.GetValue<string>("Email:Username"));
            Msg.To.Add(colaborador.Email);
            Msg.Subject = "MultiMarket - Colaborador - Nova senha";
            Msg.Body = string.Format(
                "<h1>Colaborador - MultiMarket<h1>"+
                "<h2>Olá {0}! </h2>" +
                "<p>A solicitação foi atendida com sucesso</p>" +
                "<p>Sua nova senha é: {1}</p>" +
                "<p> *Esta é uma mensagem gerada automaticamente*</p>"+
                "<h3>Equipe MultiMarket</h3>",colaborador.Nome,colaborador.Senha
            );
            Msg.IsBodyHtml = true;

            _smtp.Send(Msg);

        }
        public void SendEmailRecuperarSenha(dynamic objeto,DadosRecuperacaoSenha dados,bool cliente=true)
        {
            string URL = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host+"/"+(cliente?"cliente":"colaborador")+"/recuperarsenha/"+dados.Chave.ToString();

            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(_conf.GetValue<string>("Email:Username"));
            Msg.To.Add(objeto.Email);
            Msg.Subject = "MultiMarket - Nova senha";
            Msg.Body = string.Format(
                "<div style='text-align:center'>"+
                "<h1>Recuperar senha - MultiMarket<h1>" +
                "<h2>Olá {0}! </h2>" +
                "<p>A solicitação foi atendida com sucesso</p>" +
                "<a href='{1}'>Clique aqui</a> para criar uma nova senha" +
                "<p>*Esta é uma mensagem gerada automaticamente*</p>" +
                "<h3>Equipe MultiMarket</h3>"+
                "</div>", objeto.Nome, URL
            );
            Msg.IsBodyHtml = true;

            _smtp.Send(Msg);
        }
    }
}
