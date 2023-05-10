using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.WindowItems.DefaultItems;
using Fluitec.AppFx.Console.Templates.templates.ModuleConsole.Commands;
using Fluitec.AppFx.Console.Templates.templates.ModuleConsole.Menus;
using Fluitec.AppFx.Console.Templates.templates.ModuleConsole.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fluitec.AppFx.Console.Templates.templates.ModuleConsole;

/// <summary>
///     A startup.
/// </summary>
public class Startup : DefaultStartup
{
    /// <summary>
    ///     Configure services.
    /// </summary>
    /// <param name="context">  The context. </param>
    /// <param name="services"> The services. </param>
    public override void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddHostedService<HostedProgram>();

        // command
        services.AddTransient<IConsoleCommand, GreetCommand>();

        // interactive
        services.AddTransient<IInteractiveConsoleMenu, NameMenu>();

        // windowed
        services.AddTransient<IWindowMenuItem, FileWindowMenuItem>();
        services.AddTransient<IWindowMenuItem, QuitWindowMenuItem>();
        services.AddTransient<IWindowModuleItem, TestModule>();
    }
}