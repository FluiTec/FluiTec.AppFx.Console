using System;
using FluiTec.AppFx.Console.Items;
using FluiTec.AppFx.Console.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleSample.ConsoleModules;

namespace SimpleSample
{
    /// <summary>   A startup. </summary>
    public class Startup
    {
        #region Properties

        /// <summary>	Gets the configuration. </summary>
        /// <value>	The configuration. </value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>Gets the environment.</summary>
        /// <value>The environment.</value>
        public IWebHostEnvironment Environment { get; }

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="environment">  The environment. </param>
        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.secret.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        #endregion

        #region Services

        /// <summary>   Configure options. </summary>
        /// <param name="services"> The services. </param>
        private void ConfigureOptions(IServiceCollection services)
        {

        }

        /// <summary>   Configure ASP net core. </summary>
        /// <param name="services"> The services. </param>
        private void ConfigureAspNetCore(IServiceCollection services)
        {

        }

        /// <summary>   Configure CLI. </summary>
        /// <param name="services"> The services. </param>
        private void ConfigureCli(IServiceCollection services)
        {
            services.AddSingleton<IInteractiveConsoleItem>(new DataServiceInteractiveConsoleItem());
            services.AddSingleton<IInteractiveConsoleItem>(
                new ServiceInteractiveConsoleItem("Authentication", "Change authentication related settings"));
            services.AddSingleton<IInteractiveConsoleItem>(
                new ServiceInteractiveConsoleItem("Authorization", "Change authorization related settings"));
            services.AddSingleton<IInteractiveConsoleItem>(
                new ServiceInteractiveConsoleItem("Security", "Change security related settings"));
        }

        #endregion

        #region AspNetCore

        /// <summary>   Configure services. </summary>
        /// <param name="services"> The services. </param>
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOptions(services);
            ConfigureAspNetCore(services);
            ConfigureCli(services);
        }
        
        /// <summary>   Configures. </summary>
        /// <param name="app">          The application. </param>
        /// <param name="env">          The environment. </param>
        /// <param name="appLifetime">  The application lifetime. </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        #endregion
    }
}
