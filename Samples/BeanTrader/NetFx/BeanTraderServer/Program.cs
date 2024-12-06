
using CoreWCF.Configuration;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


namespace BeanTraderServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
      //All Ports set are default.
			IWebHost host = CreateWebHostBuilder(args).Build();
      host.Run();
		}

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
				 .UseKestrel(options => { 
        options.Listen(address: IPAddress.Loopback, 8888, listenOptions =>
        {
            listenOptions.UseHttps(httpsOptions =>
            {
#if NET472
                httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
#endif // NET472
            });
        });})
.UseNetTcp(8000)				 .UseStartup<Startup>();
	}
}
