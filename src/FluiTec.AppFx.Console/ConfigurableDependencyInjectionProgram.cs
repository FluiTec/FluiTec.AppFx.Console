using FluiTec.AppFx.Console.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console
{
    /// <summary>
    /// A configurable dependency injection program.
    /// </summary>
    public abstract class ConfigurableDependencyInjectionProgram : DependencyInjectionProgram
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        ///
        /// <returns>
        /// The configuration.
        /// </returns>
        protected virtual IConfigurationRoot GetConfiguration()
        {
            var path = DirectoryHelper.GetApplicationRoot();

            var builder = new ConfigurationBuilder()
                .SetBasePath(path);

            return Configure(builder).Build();
        }

        /// <summary>
        /// Configures the given configuration builder.
        /// </summary>
        ///
        /// <param name="configurationBuilder"> The configuration builder. </param>
        ///
        /// <returns>
        /// An IConfigurationBuilder.
        /// </returns>
        protected abstract IConfigurationBuilder Configure(IConfigurationBuilder configurationBuilder);

        /// <summary>
        /// Configure services.
        /// </summary>
        ///
        /// <param name="services"> The services. </param>
        ///
        /// <returns>
        /// A ServiceCollection.
        /// </returns>
        protected override ServiceCollection ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(GetConfiguration());
            return services;
        }
    }
}