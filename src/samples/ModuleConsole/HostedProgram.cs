using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ModuleConsole;

/// <summary>
/// Hosted program.
/// </summary>
public class HostedProgram : BaseHostedModuleProgram
{
    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public override string Name => "ModuleConsole";

    /// <summary>   Constructor. </summary>
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    /// <param name="commands"> The commands. </param>
    /// <param name="menus">    The menus. </param>
    public HostedProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime, IEnumerable<IConsoleCommand> commands, IEnumerable<IConsoleMenu> menus) 
        : base(logger, lifetime, commands, menus)
    {
    }
}