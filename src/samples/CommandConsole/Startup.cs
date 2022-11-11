using System.CommandLine;
using CommandConsole.Commands;
using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace commandconsole;

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
        services.AddTransient<IConsoleCommand, GreetCommand>();
    }
}