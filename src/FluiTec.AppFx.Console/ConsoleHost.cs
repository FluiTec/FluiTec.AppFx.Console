using System;
using FluiTec.AppFx.Console.ConsoleItems;
using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console
{
    /// <summary>   An console host. </summary>
    public class ConsoleHost
    {
        #region Properties

        /// <summary>   Gets the host services. </summary>
        /// <value> The host services. </value>
        public IServiceProvider HostServices { get; }

        #endregion
        
        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="hostServices"> The host services. </param>
        public ConsoleHost(IServiceProvider hostServices)
        {
            HostServices = hostServices ?? throw new ArgumentNullException(nameof(hostServices));
        }

        #endregion

        #region Methods

        /// <summary>   Executes the console-application. </summary>
        /// <param name="applicationName">  Name of the application. </param>
        /// <param name="args">             Console arguments. </param>
        public void Run(string applicationName, string[] args)
        {
            var consoleApplication = new ConsoleApplication(applicationName, args);
            consoleApplication.Run();
        }

        /// <summary>   Executes the console-application interactively. </summary>
        /// <param name="applicationName"> Name of the application. </param>
        /// <param name="args">            Console arguments</param>
        public void RunInteractive(string applicationName, string[] args)
        {
            var consoleApplication = new ConsoleApplication(applicationName, args);
            consoleApplication.RunInteractive();
        }


        
        /// <summary>   Initializes this  from the given host. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="host">     The host. </param>
        /// <returns>   An InteractiveConsoleHost. </returns>
        public static ConsoleHost FromHost(IHost host)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            return new ConsoleHost(host.Services);
        }

        #endregion
    }
}
