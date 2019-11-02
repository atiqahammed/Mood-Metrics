﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.HttpOverrides;

namespace LogMicroService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()

                      .AddJsonOptions(options => {
                           // handle loops correctly
                           options.SerializerSettings.ReferenceLoopHandling =
                                     Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                           // use standard name conversion of properties
                           options.SerializerSettings.ContractResolver =
                                     new CamelCasePropertyNamesContractResolver();

                           // include $id property in the output
                           options.SerializerSettings.PreserveReferencesHandling =
                                     PreserveReferencesHandling.Objects;
                       });


            services.Configure<IISOptions>(options => {

                options.ForwardWindowsAuthentication = false;

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();



            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                 ForwardedHeaders.XForwardedProto
            });


            app.UseMvc();




            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });




        }
    }
}
