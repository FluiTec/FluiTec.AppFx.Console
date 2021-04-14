using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.Items;
using FluiTec.AppFx.Console.Services;
using Microsoft.Extensions.DependencyInjection;
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

        /// <summary>   Gets the presenter. </summary>
        /// <value> The presenter. </value>
        public IInteractiveConsolePresenter Presenter { get; private set; }
        
        /// <summary>   Gets or sets the console modules. </summary>
        /// <value> The console modules. </value>
        public IEnumerable<IInteractiveConsoleItem> ConsoleModules { get; private set; }

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
            Presenter = HostServices.GetService<IInteractiveConsolePresenter>() ?? new DefaultConsolePresenter(appplicationName);

            ConsoleModules = HostServices.GetServices<IInteractiveConsoleItem>();
            var interactiveConsoleItems = ConsoleModules.ToList();
            foreach (var module in interactiveConsoleItems)
                module.Host = this;

            Presenter.Welcome();
            Presenter.Help();
            Presenter.Present(interactiveConsoleItems);
        }

        /// <summary>   Initializes this  from the given host. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="host"> The host. </param>
        /// <returns>   An InteractiveConsoleHost. </returns>
        public static InteractiveConsoleHost FromHost(IHost host)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            return new InteractiveConsoleHost(host.Services);
        }
    }
}
