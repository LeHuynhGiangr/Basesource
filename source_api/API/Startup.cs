/*
 * the Startup class configures the request pipeline of the application, dependency injection and how all requests are handled.
 */
using Data.EF;
using Data.Entities;
using Domain.IServices;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
            //services.AddHttpClient();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            //services.AddIdentity<User, Role>()
            //    .AddEntityFrameworkStores<ProjectDbContext>().AddDefaultTokenProviders();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
            services.AddAuthentication(_ =>
            {
                _.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                _.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(_ =>
            {
                _.RequireHttpsMetadata = false;
                _.SaveToken = true;
                _.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("S#$33ab654te^#^$KD%^64")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //register group of services with extension methods
            services.AddDbContext<ProjectDbContext>(_ => _.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), _ => _.MigrationsAssembly("source_api.Data.EF")));

            //services.AddControllers();

            //services.AddSwaggerGen();

            services.AddCors();//***

            //configure Dependency Injection for services
            services.AddScoped<EFRepository<User, Guid>, EFRepository<User, Guid>>();
            services.AddScoped<EFRepository<Post, Guid>, EFRepository<Post, Guid>>();
            services.AddScoped<EFRepository<Trip, Guid>, EFRepository<Trip, Guid>>();
            services.AddScoped<EFRepository<UserMedia, Guid>, EFRepository<UserMedia, Guid>>();
            services.AddScoped<IUserService<Guid>, UserService>();
            services.AddScoped<IPostService<Guid>, PostService>();
            services.AddScoped<ITripService<Guid>, TripService>();
            services.AddScoped<IMediaService<Guid>, MediaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ASP.NET Core controllers use the Routing middleware to match the URLs of incoming requests and map them to actions.Routes templates:
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // generated swagger json and swagger ui middleware
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Sign-up and Verification API"));

            //app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            //try using websocket
            app.UseWebSockets(new WebSocketOptions { 
                KeepAliveInterval=TimeSpan.FromSeconds(120),//How frequently to send "ping" frames to the client to ensure proxies keep the connection open. The default is two minutes.
                ReceiveBufferSize= 1024*4 // 1024 byte * 4 = 4kb
            });

            app.Use(async (context, next) => {
                if (context.Request.Path == "/ws")// websocket only accepts request for /ws
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        using (System.Net.WebSockets.WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())//using webSocket:WebSocket to send and receive messages
                        {

                            await new WebSocketHelpers.SendReceiveHandler().Echo(context, webSocket);//main handling
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });

            app.UseEndpoints(_ => _.MapControllers());
        }
    }
}
/*
 * 
 * https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-3.1
 * https://stackoverflow.com/questions/3297048/403-forbidden-vs-401-unauthorized-http-responses
 * problems: WWW-Authenticate, cofiguring authentication schema in asp.net core
 * 
 * websocket -> ref:https://docs.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-3.1
 */
