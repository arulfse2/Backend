using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using System.Reflection;
using COVID19Tracker.Core.Services;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.AspNetCore.Http;
using IdentityServer4.Models;
using System.Security.Claims;
using System.Collections.Generic;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using System;

namespace COVID19Tracker.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
        }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var cert = new X509Certificate2(Path.Combine(_environment.ContentRootPath, "covid19authserver.pfx"), "");
            var userConfig = Configuration.GetSection("DatabaseSettings:UserConfig");
            services.Configure<UserConfig>(userConfig);
            services.AddIdentityServer()
                   .AddInMemoryIdentityResources(ServerConfig.Resources)
                   .AddInMemoryApiResources(ServerConfig.Apis)
                   .AddInMemoryApiScopes(ServerConfig.Scopes)
                   .AddInMemoryClients(ServerConfig.Clients)
                   //.AddTestUsers(ServerConfig.GetUsers)
                   .AddDeveloperSigningCredential()
                   .AddAppUserStore();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddOptions();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AnyOrigin", builder =>
            //    {
            //        builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod();
            //    });
            //});
            services.AddCors(m => m.AddPolicy("localhost", o =>
                o.WithOrigins("http://localhost:6001", "https://localhost:6001")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("localhost");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
