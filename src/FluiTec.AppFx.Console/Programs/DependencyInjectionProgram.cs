using System;
using FluiTec.AppFx.Console.Programs.EventsArguments;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console.Programs
{
    /// <summary>
    /// A dependency injection program.
    /// </summary>
    public abstract class DependencyInjectionProgram
    {
        /// <summary>
        /// Event queue for all listeners interested in ServiceProviderCreated events.
        /// </summary>
        public event EventHandler<ServiceProviderCreatedEventArgs> ServiceProviderCreated;

        /// <summary>
        /// Event queue for all listeners interested in ServicesConfigured events.
        /// </summary>
        public event EventHandler<ServicesConfiguredEventArgs> ServicesConfigured; 

        /// <summary>
        /// Gets service provider.
        /// </summary>
        ///
        /// <returns>
        /// The service provider.
        /// </returns>
        protected virtual ServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services = ConfigureServices(services);
            OnServicesConfigured(services);

            var serviceProvider = services.BuildServiceProvider();
            OnServiceProviderCreated(serviceProvider);

            return serviceProvider;
        }

        /// <summary>
        /// Configure services.
        /// </summary>
        ///
        /// <param name="services"> The services. </param>
        ///
        /// <returns>
        /// A ServiceCollection.
        /// </returns>
        protected abstract ServiceCollection ConfigureServices(ServiceCollection services);

        /// <summary>
        /// Executes the 'service provider created' action.
        /// </summary>
        ///
        /// <param name="serviceProvider">  The service provider. </param>
        protected virtual void OnServiceProviderCreated(ServiceProvider serviceProvider)
        {
            ServiceProviderCreated?.Invoke(this, new ServiceProviderCreatedEventArgs(serviceProvider));
        }

        /// <summary>
        /// Executes the 'services configured' action.
        /// </summary>
        ///
        /// <param name="services"> The services. </param>
        protected virtual void OnServicesConfigured(ServiceCollection services)
        {
            ServicesConfigured?.Invoke(this, new ServicesConfiguredEventArgs(services));
        }
    }
}