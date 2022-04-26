using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace COVID19Tracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //X509Certificate2 cert = new X509Certificate2(Path.Combine(_webHostEnvironment.ContentRootPath, "covid19authserver.pfx"), "");
            //services.AddDataProtection()
            //    .SetApplicationName("ResourceServer")
            //    .ProtectKeysWithCertificate(cert);
            var policy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            }).AddIdentityServerAuthentication(options =>
                   {
                       options.Authority = Configuration["IdentityServer:Authority"];
                       options.ApiName = "covidtrackerapi";
                       options.ApiSecret = Configuration["IdentityServer:ClientSecret"];
                       options.RequireHttpsMetadata = true;
                   });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("PublicSecure", policyUser =>
                {
                    policyUser.RequireClaim("client_id", Configuration["IdentityServer:ClientId"]);
                });
                options.AddPolicy("UserSecure", policy =>
                policy.RequireClaim("role", "user"));

                options.AddPolicy("AdminSecure", policy =>
                policy.RequireClaim("role", "admin"));
            });
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddApiVersioning();
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddSwaggerGen(c =>
            {
                var apiinfo = new OpenApiInfo
                {
                    Title = "COVID19 Tracker API",
                    Version = "v1",
                    Description = "COVID19 Tracker API",
                    Contact = new OpenApiContact
                    { Name = "Arulprakash", Email = "arulprakash.s@cognizant.com" },
                    License = new OpenApiLicense()
                    {
                        Name = "GNU"
                    }
                };

                OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
                {
                    Name = "Resource Owner Password flow",
                    Scheme = IdentityServerAuthenticationDefaults.AuthenticationScheme,
                    Description = "Specify the user name and password.",
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri(Configuration["IdentityServer:TokenUrl"]),
                            Scopes = new Dictionary<string, string>
                            {
                                {"covidtrackerapi", "full access"}
                            }
                        }
                    }
                };
                c.AddSecurityDefinition("oauth2", securityDefinition);
                c.OperationFilter<SecureEndpointAuthRequirementFilter>();
                c.SwaggerDoc("v1", apiinfo);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("corsGlobalPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "COVID19 Tracker API V1");
                c.RoutePrefix = "";
                c.OAuthClientId(Configuration["IdentityServer:ClientId"]);
                c.OAuthClientSecret(Configuration["IdentityServer:ClientSecret"]);
                c.OAuthUsername("user");
                c.OAuthScopes(new string[] { "covidtrackerapi" });
                c.OAuthAppName("COVID19 Tracker API - Swagger");
            });
        }
    }
}
