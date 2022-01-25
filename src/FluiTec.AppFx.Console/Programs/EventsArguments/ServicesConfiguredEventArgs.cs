using System;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console.Programs.EventsArguments
{
    /// <summary>
    /// Additional information for services configured events.
    /// </summary>
    public class ServicesConfiguredEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        ///
        /// <value>
        /// The services.
        /// </value>
        public ServiceCollection Services { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="services"> The services. </param>
        public ServicesConfiguredEventArgs(ServiceCollection services)
        {
            Services = services;
        }
    }
}