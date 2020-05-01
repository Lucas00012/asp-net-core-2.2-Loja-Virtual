using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using MultiMarket.Database;
using MultiMarket.Repositories;
using MultiMarket.Repositories.Contracts;
using MultiMarket.Libraries.Sessao;
using MultiMarket.Libraries.Login;
using System.Net.Mail;
using System.Net;
using MultiMarket.Libraries.Email;
using MultiMarket.Libraries.Middleware;
using Microsoft.Extensions.FileProviders;
using MultiMarket.Libraries.BugFix;
using System.IO;
using MultiMarket.Libraries.Cookie;
using MultiMarket.Libraries.CarrinhoCompra;
using AutoMapper;
using MultiMarket.Libraries.AutoMapper;
using ServiceReference1;
using MultiMarket.Libraries.Frete;
using MultiMarket.Libraries.Pagamento;
using System.ServiceModel;
using Newtonsoft.Json;
using Coravel;
using MultiMarket.Libraries.Scheduler.Invocable;

namespace MultiMarket
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options=>options.Cookie.IsEssential=true);

            services.AddScoped<SmtpClient>(options =>
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Configuration.GetValue<string>("Email:ServerSMTP");
                smtp.Port = Configuration.GetValue<int>("Email:ServerPort");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Configuration.GetValue<string>("Email:Username"), Configuration.GetValue<string>("Email:Password"));
                smtp.EnableSsl = true;

                return smtp;
            });
            services.AddScoped<CalcPrecoPrazoWSSoap>(options =>
            {
                CalcPrecoPrazoWSSoapClient WScorreios = new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);
                WScorreios.InnerChannel.OperationTimeout = new TimeSpan(0, 3, 0);
                return WScorreios;
            });
            services.AddScoped<GerenciarEmail>();
            services.AddAutoMapper(config=>config.AddProfile<MappingProfile>(),typeof(Startup));

            services.AddHttpContextAccessor();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<LoginColaborador>();
            services.AddScoped<LoginCliente>();
            services.AddScoped<GerenciadorCookie>();
            services.AddScoped<CarrinhoCompra>();
            services.AddScoped<CookieValorPrazoFrete>();
            services.AddScoped<WSCalcularFrete>();
            services.AddScoped<WSCalcularPacote>();
            services.AddScoped<GerenciarPagarMe>();

            services.AddScoped<IEnderecoEntregaRepository, EnderecoEntregaRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IPedidoRepository,PedidoRepository>();
            services.AddScoped<IPedidoSituacaoRepository, PedidoSituacaoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IRecuperacaoSenhaRepository, RecuperacaoSenhaRepository>();
            services.AddScoped<Sessao>();
            services.AddTransient<PedidoPagamentoInvocable>();
            services.AddTransient<PedidoEntregaInvocable>();
            services.AddTransient<PedidoFinalizadoInvocable>();
            services.AddTransient<PedidoDevolucaoInvocable>();
            services.AddScheduler();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<MultiMarketContext>(options=>
                options.UseSqlServer(Configuration.GetValue<string>("Database:Connection"),sql=>sql.CommandTimeout(360)));

            services.AddMvc(options =>
            {
                options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "Valor inválido para o campo");
                options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((y, x) => "Valor inválido para o campo");
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Valor inválido para o campo");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Erro/Erro{0}");
                app.UseExceptionHandler("/Erro/Erro500");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();
            app.UseMvc(routes =>
            {
             routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //SCHEDULER - CORAVEL
            app.ApplicationServices.UseScheduler(scheduler =>
            {
                scheduler.Schedule<PedidoPagamentoInvocable>().EveryTenSeconds();
                scheduler.Schedule<PedidoEntregaInvocable>().EveryTenSeconds();
                scheduler.Schedule<PedidoFinalizadoInvocable>().EveryTenSeconds();
                scheduler.Schedule<PedidoDevolucaoInvocable>().EveryTenSeconds();
            });
        }
    }
}
