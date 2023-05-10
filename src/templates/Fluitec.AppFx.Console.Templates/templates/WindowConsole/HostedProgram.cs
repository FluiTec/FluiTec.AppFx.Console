using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fluitec.AppFx.Console.Templates.templates.WindowConsole;

/// <summary>
///     Hosted program.
/// </summary>
public class HostedProgram : ConsoleHostedWindowProgram
{
    /// <summary>   Constructor. </summary>
    /// <param name="logger">       The logger. </param>
    /// <param name="lifetime">     The lifetime. </param>
    /// <param name="menuItems">    The menu items. </param>
    /// <param name="moduleItems">  The module items. </param>
    public HostedProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime,
        IEnumerable<IWindowMenuItem> menuItems, IEnumerable<IWindowModuleItem> moduleItems)
        : base(logger, lifetime, menuItems, moduleItems)
    {
    }

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public override string Name => "WindowConsole";
}