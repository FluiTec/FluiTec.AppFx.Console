using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console
{
    /// <summary>
    /// A dependency injection program.
    /// </summary>
    public abstract class DependencyInjectionProgram
    {
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

            return ConfigureServices(services).BuildServiceProvider();
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
    }
}