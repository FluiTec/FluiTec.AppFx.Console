using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using InteractiveConsole.Menus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InteractiveConsole;

/// <summary>
/// A startup.
/// </summary>
public class Startup : DefaultStartup
{
    /// <summary>
    /// Configure services.
    /// </summary>
    ///
    /// <param name="context">  The context. </param>
    /// <param name="services"> The services. </param>
    public override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<HostedProgram>();
        services.AddTransient<IConsoleMenu, NameMenu>();
    }
}