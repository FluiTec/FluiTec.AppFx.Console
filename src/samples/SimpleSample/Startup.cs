using System;
using System.Linq;
using FluiTec.AppFx.Console;
using FluiTec.AppFx.Console.Configuration;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Data.Dynamic.Configuration;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Options.Managers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleSample.Data;
using SimpleSample.Data.LiteDb;
using SimpleSample.Data.Mssql;
using SimpleSample.Data.Mysql;
using SimpleSample.Data.Pgsql;

namespace SimpleSample
{
    /// <summary>   A startup. </summary>
    public class Startup
    {
        #region Properties

        /// <summary>	Gets the configuration. </summary>
        /// <value>	The configuration. </value>
        public IConfigurationRoot Configuration { get; }

        /// <summary>   Gets the manager for configuration. </summary>
        /// <value> The configuration manager. </value>
        public ConfigurationManager ConfigurationManager { get; }

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
                .AddJsonFile("appsettings.secret.json", false, true)
                .AddSaveableJsonFile("appsettings.conf.json", false, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            ConfigurationManager = new ConsoleReportingConfigurationManager(Configuration);
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
            services.ConfigureDynamicDataProvider(ConfigurationManager,
                new Func<DynamicDataOptions, IServiceProvider, ITestDataService>((options, provider) =>
                    {
                        return options.Provider switch
                        {
                            DataProvider.LiteDb => new LiteDbTestDataService(
                                provider.GetRequiredService<LiteDbServiceOptions>(),
                                provider.GetService<ILoggerFactory>()),
                            DataProvider.Mssql => new MssqlTestDataService(
                                provider.GetRequiredService<MssqlDapperServiceOptions>(),
                                provider.GetService<ILoggerFactory>()),
                            DataProvider.Pgsql => new PgsqlTestDataService(
                                provider.GetRequiredService<PgsqlDapperServiceOptions>(),
                                provider.GetService<ILoggerFactory>()),
                            DataProvider.Mysql => new MysqlTestDataService(
                                provider.GetRequiredService<MysqlDapperServiceOptions>(),
                                provider.GetService<ILoggerFactory>()),
                            _ => throw new NotImplementedException()
                        };
                    }
                )
            );
        }

        /// <summary>   Configure CLI. </summary>
        /// <param name="services"> The services. </param>
        private void ConfigureCli(IServiceCollection services)
        {
            ConsoleHost.Configure(Configuration, services);
            ConsoleHost.ConfigureModule(services, provider => new OptionsConsoleModule(provider.GetRequiredService<IConfigurationProvider>()));
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
