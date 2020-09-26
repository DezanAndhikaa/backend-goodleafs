using System;
using System.IO;
using Api.Common;
using Application;
using Application.Common.Interface;
using Application.Common.Models;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Persistence;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

namespace Api {
    public class Startup {
        private IServiceCollection _services;

        public Startup (IConfiguration configuration, ILoggerFactory loggerFactory) {
            Configuration = configuration;
            Utils.ApplicationLogging.LoggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddControllers ();

            services.AddPersistence (Configuration);

            services.AddApplication ();

            services.AddMvcCore (options => {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add (new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute (typeof (object), (int) System.Net.HttpStatusCode.Unauthorized));
                    options.Filters.Add (new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute (typeof (object), (int) System.Net.HttpStatusCode.Forbidden));
                    options.Filters.Add (new Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute (typeof (object), (int) System.Net.HttpStatusCode.InternalServerError));
                })
                .AddJsonOptions (o => o.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddNewtonsoftJson (options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver ();
                })
                .AddFluentValidation (fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<IAppDbContext> ();
                });

            services.AddLogging (loggingBuilder => loggingBuilder.AddSerilog (dispose: true));

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new OpenApiInfo {
                    Title = "Administrator Goodleafs",
                        Description = "Web API For Goodleafs Administrator or Back Office",
                        Version = "Version 1.0",
                        Contact = new OpenApiContact {
                            Name = "Dezan Andhika",
                                Email = "dezanandhika@outlook.com",
                                Url = new Uri ("https://dezan.codingin.id"),
                        },
                });
            });

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseRouting ();

            app.UseStaticFiles (new StaticFileOptions {
                FileProvider = new PhysicalFileProvider (
                        Path.Combine (env.ContentRootPath, "Resources")),
                    RequestPath = "/Resources"
            });

            app.UseCors (options => options.AllowAnyOrigin ());

            // app.UseCustomExceptionHandler ();

            app.UseSwagger ();

            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Backoffice Goodleafs API");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}