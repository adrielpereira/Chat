using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebChatQJW.Core
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
            .UseKestrel()
            .ConfigureAppConfiguration((WebHostBuilderContext, ConfigurationBuilder) =>
            {
                ConfigurationBuilder
                        .AddJsonFile("appsettings.json", optional: true);
                ConfigurationBuilder.AddEnvironmentVariables();
            })
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();

            host.Run();
        }
    }
}
