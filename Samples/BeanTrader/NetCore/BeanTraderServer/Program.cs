using Serilog;
using System.Security.Cryptography.X509Certificates;
using CoreWCF.Security;
using CoreWCF.Configuration;

namespace BeanTraderServer
{
    class Program
    {
        async static Task Main(string[] args)
        {
            ConfigureLogging();
            var builder = WebApplication.CreateBuilder(args);

            // Set NetTcp port
            builder.WebHost.UseNetTcp(8090);

            builder.Services.AddServiceModelServices();
            builder.Services.AddServiceModelConfigurationManagerFile("wcf.config");

            var app = builder.Build();

            app.UseServiceModel(ConfigureServiceModel);

            await app.StartAsync();
            Log.Information("Bean Trader Service listening");
            WaitForExitSignal();
            Log.Information("Shutting down...");
            await app.StopAsync();

            if (app == null)
            {

            }
        }

        private static void ConfigureServiceModel(IServiceBuilder serviceBuilder)
        {
            var certPath = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "BeanTrader.pfx");

            serviceBuilder.ConfigureServiceHostBase<BeanTrader>(beanTraderServiceHost =>
            {
                beanTraderServiceHost.Credentials.ServiceCertificate.Certificate = new X509Certificate2(certPath, "password");
                beanTraderServiceHost.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            });
        }

        private static void WaitForExitSignal()
        {
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Logging initialized");
        }
    }
}
