using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register group of services with extension methods

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ASP.NET Core controllers use the Routing middleware to match the URLs of incoming requests and map them to actions.Routes templates:
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Set up conventional route
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapControllerRoute(name: "identity", pattern: "{controller}/{action}**");
                //endpoints.MapControllerRoute(name: "identity", pattern: "{controller=identity}/**");
                //endpoints.MapControllerRoute(name: "identity", pattern: "{controller=identity}/**");
                //endpoints.MapControllerRoute(name: "identity", pattern: "{controller=identity}/**");
                //endpoints.MapControllerRoute(name: "identity", pattern: "{controller=identity}/**");
            });
        }
    }
}
