using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using System.Reflection;
using COVID19Tracker.Core.Contracts;
using COVID19Tracker.Core.Repositories;
using COVID19Tracker.Core.Query;
using COVID19Tracker.Core.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace COVID19Tracker.Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer(x =>
            {
                x.IssuerUri = "none";
            }).AddInMemoryIdentityResources(Config.GetIdentityResources)
              .AddInMemoryApiResources(Config.GetApiResources)
              .AddInMemoryApiScopes(Config.GetApiScopes)
              .AddInMemoryClients(Config.GetClients)
              .AddDeveloperSigningCredential()
              .AddAppUserStore();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddSingleton<IMongoClient>(c => {
            //    var ConnectionString = Configuration["DatabaseSettings:ConnectionString"];
            //    return new MongoClient(ConnectionString);
            //});
            //services.AddScoped(c =>
            //    c.GetService<IMongoClient>().StartSession());
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IRequestHandler<GetUserByEmailAndPasswordQuery, bool>, GetUserByEmailAndPasswordQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();
            app.UseIdentityServer();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
