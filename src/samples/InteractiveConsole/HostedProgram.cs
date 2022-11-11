using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InteractiveConsole;

/// <summary>
/// Hosted program.
/// </summary>
public class HostedProgram : BaseHostedInteractiveProgram
{
    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public override string Name => "InteractiveConsole";

    /// <summary>   Constructor. </summary>
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    /// <param name="menus">    The menus. </param>
    public HostedProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime, IEnumerable<IConsoleMenu> menus)
        : base(logger, lifetime, menus)
    {
    }
}