using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console.Hosting
{
    /// <summary>
    /// A default startup.
    /// </summary>
    public abstract class DefaultStartup : IStartup
    {
        /// <summary>
        /// Configures the given builder.
        /// </summary>
        ///
        /// <param name="context">  The context. </param>
        /// <param name="builder">  The builder. </param>
        public virtual void Configure(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile("appsettings.secret.json", true, true);
        }

        /// <summary>
        /// Configure services.
        /// </summary>
        ///
        /// <param name="context">  The context. </param>
        /// <param name="services"> The services. </param>
        public abstract void ConfigureServices(HostBuilderContext context, IServiceCollection services);
    }
}