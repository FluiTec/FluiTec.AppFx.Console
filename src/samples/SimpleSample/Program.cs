using System;
using FluiTec.AppFx.Console.Controls;
using FluiTec.AppFx.Options.Helpers;
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
            //var settings = services.GetRequiredService<ConsoleSettings>();
            
            TestMenu();
        }

        /// <summary>   Configure services. </summary>
        /// <param name="services"> The services. </param>
        /// <param name="manager">  The manager. </param>
        private static void ConfigureServices(ServiceCollection services, ValidatingConfigurationManager manager)
        {
            //manager.ConfigureValidator(new ConsoleSettingsValidator());
            //services.Configure<ConsoleSettings>(manager);
        }

        private static void TestMenu()
        {
            var menu = new SelectMenu<string> {Items = {
                new SelectMenuItem<string>("Data", "Data", "Open Data-Configuration"),
                new SelectMenuItem<string>("Identity", "Identity", "Open Identity-Configuration"),
                new SelectMenuItem<string>("Localization", "Localization", "Open Localization-Configuration")
            }};
            var item = menu.SelectItem();
        }

        #region Helpers

        /// <summary>   Gets configuration root. </summary>
        /// <returns>   The configuration root. </returns>
        private static IConfigurationRoot GetConfigurationRoot()
        {
            var path = DirectoryHelper.GetApplicationRoot();
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
