using System;
using FluiTec.AppFx.Console.ConsoleItems;
using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console
{
    /// <summary>   An interactive console host. </summary>
    public class InteractiveConsoleHost
    {
        #region Properties

        /// <summary>   Gets the host services. </summary>
        /// <value> The host services. </value>
        public IServiceProvider HostServices { get; }

        #endregion
        
        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="hostServices"> The host services. </param>
        public InteractiveConsoleHost(IServiceProvider hostServices)
        {
            HostServices = hostServices ?? throw new ArgumentNullException(nameof(hostServices));
        }

        /// <summary>   Executes the console-application interactively. </summary>
        /// <param name="appplicationName"> Name of the appplication. </param>
        public void RunInteractive(string appplicationName)
        {
            var consoleApplication = new ConsoleApplication(appplicationName);
            consoleApplication.Display();
        }

        /// <summary>   Initializes this  from the given host. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="host">     The host. </param>
        /// <returns>   An InteractiveConsoleHost. </returns>
        public static InteractiveConsoleHost FromHost(IHost host)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));
            return new InteractiveConsoleHost(host.Services);
        }
    }
}
