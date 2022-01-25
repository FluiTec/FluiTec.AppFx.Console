using System;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console.Programs.EventsArguments
{
    /// <summary>
    /// Additional information for service provider created events.
    /// </summary>
    public class ServiceProviderCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the service provider.
        /// </summary>
        ///
        /// <value>
        /// The service provider.
        /// </value>
        public ServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="serviceProvider">  The service provider. </param>
        public ServiceProviderCreatedEventArgs(ServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            throw new NotImplementedException();
        }
    }
}