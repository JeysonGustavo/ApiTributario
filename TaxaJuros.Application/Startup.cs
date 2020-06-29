using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaxaJuros.Manager.Managers.TaxaJuros;
using TaxaJuros.Manager.Providers.TaxaJuros;
using TaxaJuros.Provider.TaxaJuros;

namespace TaxaJuros.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Taxa Juros",
                    Description = "Softplan - Jeyson Gomes",
                    Contact = new OpenApiContact
                    {
                        Name = "Jeyson Gomes",
                        Email = string.Empty,
                        Url = new Uri("https://br.linkedin.com/in/jeyson-gomes-888ab671"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //var securitySchema = new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer",
                //    Reference = new OpenApiReference
                //    {
                //        Type = ReferenceType.SecurityScheme,
                //        Id = "Bearer"
                //    }
                //};
                //c.AddSecurityDefinition("Bearer", securitySchema);

                //var securityRequirement = new OpenApiSecurityRequirement();
                //securityRequirement.Add(securitySchema, new[] { "Bearer" });
                //c.AddSecurityRequirement(securityRequirement);
            });
            #endregion

            #region Services Transient

            #region Managers
            services.AddTransient<ITaxaJurosManager, TaxaJurosManager>();
            #endregion

            #region Providers
            services.AddTransient<ITaxaJurosProvider, TaxaJurosProvider>();
            #endregion

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("../swagger/v1/swagger.json", "APITaxaJuros");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
