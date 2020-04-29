using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MultiMarket.Libraries.BugFix;
using Serilog;
using Serilog.Events;

namespace MultiMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CurrentDirectoryHelpers.SetCurrentDirectory();
            string CaminhoLog= Path.Combine(Directory.GetCurrentDirectory(),"Logs.txt");

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .Enrich.FromLogContext()
            .WriteTo.File(CaminhoLog)
            .CreateLogger();

            try
            {
                Log.Information("---- INICIANDO SERVIDOR ----");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "---- SERVIDOR PAROU INESPERADAMENTE ----");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
