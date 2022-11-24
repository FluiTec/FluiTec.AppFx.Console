using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console.Hosting;

/// <summary>
///     An extensions.
/// </summary>
public static class HostExtensions
{
    /// <summary>
    ///     A HostBuilder extension method that use startup.
    /// </summary>
    /// <typeparam name="TStartup"> Type of the startup. </typeparam>
    /// <param name="builder">  The builder to act on. </param>
    /// <param name="startup">  The startup. </param>
    public static IHostBuilder UseStartup<TStartup>(this IHostBuilder builder, TStartup startup)
        where TStartup : IStartup
    {
        builder.ConfigureServices(startup.ConfigureServices);
        builder.ConfigureAppConfiguration(startup.Configure);
        return builder;
    }
}