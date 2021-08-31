using System;
using FluiTec.AppFx.Console.ConsoleItems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console
{
    /// <summary>   An console host. </summary>
    public class ConsoleHost
    {
        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="hostServices"> The host services. </param>
        public ConsoleHost(IServiceProvider hostServices)
        {
            HostServices = hostServices ?? throw new ArgumentNullException(nameof(hostServices));
        }

        #endregion

        #region Properties

        /// <summary>   Gets the host services. </summary>
        /// <value> The host services. </value>
        public IServiceProvider HostServices { get; }

        #endregion

        #region Methods

        /// <summary>   Executes the console-application. </summary>
        /// <param name="applicationName">  Name of the application. </param>
        /// <param name="args">             Console arguments. </param>
        public int Run(string applicationName, string[] args)
        {
            var consoleApplication = new ConsoleApplication(applicationName, HostServices, args);
            return consoleApplication.Run();
        }

        /// <summary>   Executes the console-application interactively. </summary>
        /// <param name="applicationName"> Name of the application. </param>
        /// <param name="args">            Console arguments</param>
        public void RunInteractive(string applicationName, string[] args)
        {
            var consoleApplication = new ConsoleApplication(applicationName, HostServices, args);
            consoleApplication.RunInteractive();
        }

        /// <summary>   Initializes this  from the given host. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="host">     The host. </param>
        /// <returns>   An InteractiveConsoleHost. </returns>
        public static ConsoleHost FromHost(IHost host)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            return new ConsoleHost(host.Services);
        }

        /// <summary>   Configures. </summary>
        /// <param name="config">   The configuration. </param>
        /// <param name="services"> The services. </param>
        public static void Configure(IConfigurationRoot config, IServiceCollection services)
        {
            services.AddSingleton(services);
            services.AddSingleton(config);
        }

        /// <summary>   Configure module. </summary>
        /// <typeparam name="TModuleType">  Type of the module type. </typeparam>
        /// <param name="services">                 The services. </param>
        /// <param name="implementationFactory">    The implementation factory. </param>
        public static void ConfigureModule<TModuleType>(IServiceCollection services,
            Func<IServiceProvider, TModuleType> implementationFactory)
        {
            services.AddSingleton(typeof(ModuleConsoleItem), provider => implementationFactory(provider));
        }

        #endregion
    }
}