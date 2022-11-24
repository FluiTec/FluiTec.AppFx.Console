using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console.Hosting;

/// <summary>
///     Interface for startup.
/// </summary>
public interface IStartup
{
    /// <summary>
    ///     Configures the given builder.
    /// </summary>
    /// <param name="context">  The context. </param>
    /// <param name="builder">  The builder. </param>
    void Configure(HostBuilderContext context, IConfigurationBuilder builder);

    /// <summary>
    ///     Configure services.
    /// </summary>
    /// <param name="context">  The context. </param>
    /// <param name="services"> The services. </param>
    void ConfigureServices(HostBuilderContext context, IServiceCollection services);
}