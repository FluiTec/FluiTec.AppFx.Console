using FluiTec.AppFx.Console;
using FluiTec.AppFx.Console.Module;
using FluiTec.AppFx.Options.Helpers;
using FluiTec.AppFx.Options.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace SimpleSample
{
    /// <summary>   A program. </summary>
    internal class Program
    {
        /// <summary>   Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        private static void Main(string[] args)
        {
            new InteractiveConsoleHost(GetConfigurationRoot(), ConfigureServices)
                .RunInteractive();
        }

        /// <summary>   Configure services. </summary>
        /// <param name="services"> The services. </param>
        /// <param name="manager">  The manager. </param>
        private static void ConfigureServices(IServiceCollection services, ValidatingConfigurationManager manager)
        {
            services.AddTransient<IConsoleModule>(provider => new ConsoleModule
            {
                Name = "Data", 
                Description = "Data-Module",
                HelpText = "Allows to interact directly with the data-module."
            });

            services.AddTransient<IConsoleModule>(provider => new ConsoleModule
            {
                Name = "Identity", 
                Description = "Identity-Module", 
                HelpText = "Allows to interact directly with the identity-module."
            });
        }

        #region Helpers

        /// <summary>   Gets configuration root. </summary>
        /// <returns>   The configuration root. </returns>
        private static IConfigurationRoot GetConfigurationRoot()
        {
            var path = DirectoryHelper.GetApplicationRoot();
            var config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", false, true).Build();
            return config;
        }

        #endregion
    }
}
