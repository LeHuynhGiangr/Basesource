/*
 * the program class is console app that is the main entry point to start the application, it configures and launches the web api host and web server using
 * and instance of IHostBuilder
 */
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder = webBuilder.UseUrls("http://localhost:4000");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
