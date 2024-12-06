
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeanTraderServer
{
   public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string pathToXml = @"corewcf_ported.config";
            services.AddServiceModelServices();
            services.AddServiceModelConfigurationManagerFile(pathToXml);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseServiceModel();
        }
    }
}
