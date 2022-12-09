/*
 * Ora esatta.
 *
 * #### Documentazione Il servizio Ora esatta ritorna l'ora del server in formato RFC5424 (syslog).  `2018-12-30T12:23:32Z`  ##### Sottosezioni E' possibile utilizzare - con criterio - delle sottosezioni.  #### Note  Il servizio non richiede autenticazione, ma va' usato rispettando gli header di throttling esposti in conformita' alle Linee Guida del Modello di interoperabilita'.  #### Informazioni tecniche ed esempi  Esempio:  ``` http http://localhost:8443/datetime/v1/echo {   'datetime': '2018-12-30T12:23:32Z' } ``` 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: filippo.derrigo@gmail.com
 */
using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using CoreSK.Filters;
using Core_SK.Filters;

namespace CoreSK
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnv;

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc(options =>
                {
                    options.InputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
                    options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                })
                .AddXmlSerializerFormatters();


            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new OpenApiInfo
                    {
                        Version = "1.0.0",
                        Title = "Ora esatta.",
                        Description = "Ora esatta. (ASP.NET Core 7)",
                        Contact = new OpenApiContact()
                        {
                            Name = "Filippo D'Errigo",
                            Url = new Uri("https://www.linkedin.com/in/filippo-d-errigo-095b416b/"),
                            Email = "filippo.derrigo@gmail.com"
                        },
                        TermsOfService = new Uri("http://swagger.io/terms/")
                    });
                    c.CustomSchemaIds(type => type.FullName);
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Sets the base property in the Swagger document generated like x-summary and server section
                    c.DocumentFilter<BaseFilter>("https://localhost:5001", "/datetime/v1", "Descrizione Server");

                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>("/datetime/v1");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();

                    //Set Response content Myme Type  in the Swagger document generated
                    // Use [SwaggerResponseMimeType] in Actions instead of [SwaggerResponse]
                    c.OperationFilter<SwaggerResponseMimeTypeOperationFilter>();
                    
                    //Set Response Header   in the Swagger document generated
                    c.OperationFilter<SwaggerResponseHeaderFilter>();
                });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Ora esatta.");
            });

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }
        }
    }
}
