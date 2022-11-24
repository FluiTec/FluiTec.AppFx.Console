using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.WindowItems.DefaultItems;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Terminal.Gui;

namespace WindowConsole;

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

        services.AddTransient<IWindowMenuItem, FileWindowMenuItem>();
        services.AddTransient<IWindowMenuItem, QuitWindowMenuItem>();
        services.AddTransient<IWindowModuleItem, Test>();
    }
}

public class Test : IWindowModuleItem
{
    public string Name => "Test-Module";

    public View GetView()
    {
        return new Button("Test");
    }

    public override string ToString()
    {
        return Name;
    }
}