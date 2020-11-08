/*
 * the Startup class configures the request pipeline of the application, dependency injection and how all requests are handled.
 */
using Data.EF;
using Data.Entities;
using Domain.IServices;
using Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ProjectDbContext>().AddDefaultTokenProviders();

            //register group of services with extension methods
            services.AddDbContext<ProjectDbContext>(_ => _.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), _=>_.MigrationsAssembly("source_api.Data.EF")));

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddCors();//***

            //configure Dependency Injection for services
            services.AddScoped<IUserService<Guid>, UserService>();
            services.AddScoped<EFRepository<User, Guid>, EFRepository<User, Guid>>();
            services.AddTransient<DbInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbInitializer dbInitializer)
        {
            //ASP.NET Core controllers use the Routing middleware to match the URLs of incoming requests and map them to actions.Routes templates:
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }

            // generated swagger json and swagger ui middleware
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Sign-up and Verification API"));

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(_ => _.MapControllers());

            dbInitializer.Seed().Wait();
        }
    }
}
