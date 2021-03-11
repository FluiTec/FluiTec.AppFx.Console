using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using FluiTec.AppFx.Console.Settings;
using FluiTec.AppFx.Options.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleSample
{
    /// <summary>   A program. </summary>
    internal class Program
    {
        /// <summary>   Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        private static void Main(string[] args)
        {
            var services = InitializeServices(ConfigureServices);
            var settings = services.GetRequiredService<ConsoleSettings>();
        }

        /// <summary>   Configure services. </summary>
        /// <param name="services"> The services. </param>
        /// <param name="manager">  The manager. </param>
        private static void ConfigureServices(ServiceCollection services, ValidatingConfigurationManager manager)
        {
            manager.ConfigureValidator(new ConsoleSettingsValidator());
            services.Configure<ConsoleSettings>(manager);
        }

        #region Helpers
        
        /// <summary>   Gets application root. </summary>
        /// <exception cref="InvalidOperationException">    Thrown when the requested operation is
        ///                                                 invalid. </exception>
        /// <returns>   The application root. </returns>
        private static string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
                var appRoot = appPathMatcher.Match(exePath ?? throw new InvalidOperationException()).Value;
                return appRoot;
            }
            else
            {
                var appPathMatcher = new Regex(@"(?<!file)\/+[\S\s]*?(?=\/+bin)");
                var appRoot = appPathMatcher.Match(exePath ?? throw new InvalidOperationException()).Value;
                return appRoot;
            }
        }

        /// <summary>   Gets configuration root. </summary>
        /// <returns>   The configuration root. </returns>
        private static IConfigurationRoot GetConfigurationRoot()
        {
            var path = GetApplicationRoot();
            Console.WriteLine($"BasePath: {path}");
            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", false, true).Build();
            return config;
        }

        /// <summary>   Initializes the services. </summary>
        /// <param name="configureServices">    The configure services. </param>
        /// <returns>   An IServiceProvider. </returns>
        private static IServiceProvider InitializeServices(Action<ServiceCollection, ValidatingConfigurationManager> configureServices)
        {
            var manager = new ConsoleReportingConfigurationManager(GetConfigurationRoot());
            var services = new ServiceCollection();
            
            configureServices(services, manager);

            return services.BuildServiceProvider();
        }

        #endregion
    }
}
