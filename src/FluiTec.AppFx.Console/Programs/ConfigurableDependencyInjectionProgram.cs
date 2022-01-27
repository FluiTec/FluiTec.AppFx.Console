using System;
using FluiTec.AppFx.Console.Helpers;
using FluiTec.AppFx.Console.Programs.EventsArguments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console.Programs
{
    /// <summary>
    ///     A configurable dependency injection program.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public abstract class ConfigurableDependencyInjectionProgram : DependencyInjectionProgram
    {
        /// <summary>
        ///     Event queue for all listeners interested in ConfigurationBuilderCreated events.
        /// </summary>
        public event EventHandler<ConfigurationBuilderCreatedEventArgs> ConfigurationBuilderCreated;

        /// <summary>
        ///     Event queue for all listeners interested in ConfigurationCreated events.
        /// </summary>
        public event EventHandler<ConfigurationCreatedEventArgs> ConfigurationCreated;

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <returns>
        ///     The configuration.
        /// </returns>
        protected virtual IConfigurationRoot GetConfiguration()
        {
            var path = DirectoryHelper.GetApplicationRoot();

            var builder = new ConfigurationBuilder()
                .SetBasePath(path);
            builder = Configure(builder);
            OnConfigurationBuilderCreated(builder);

            var conf = builder.Build();
            OnConfigurationCreated(conf);

            return conf;
        }

        /// <summary>
        ///     Configures the given configuration builder.
        /// </summary>
        /// <param name="configurationBuilder"> The configuration builder. </param>
        /// <returns>
        ///     An IConfigurationBuilder.
        /// </returns>
        protected abstract IConfigurationBuilder Configure(IConfigurationBuilder configurationBuilder);

        /// <summary>
        ///     Configure services.
        /// </summary>
        /// <param name="services"> The services. </param>
        /// <returns>
        ///     A ServiceCollection.
        /// </returns>
        protected override ServiceCollection ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(GetConfiguration());
            return services;
        }

        /// <summary>
        ///     Executes the 'configuration builder created' action.
        /// </summary>
        /// <param name="configurationBuilder"> The configuration builder. </param>
        protected virtual void OnConfigurationBuilderCreated(IConfigurationBuilder configurationBuilder)
        {
            ConfigurationBuilderCreated?.Invoke(this, new ConfigurationBuilderCreatedEventArgs(configurationBuilder));
        }

        /// <summary>
        ///     Executes the 'configuration created' action.
        /// </summary>
        /// <param name="configurationRoot">    The configuration root. </param>
        protected virtual void OnConfigurationCreated(IConfigurationRoot configurationRoot)
        {
            ConfigurationCreated?.Invoke(this, new ConfigurationCreatedEventArgs(configurationRoot));
        }
    }
}