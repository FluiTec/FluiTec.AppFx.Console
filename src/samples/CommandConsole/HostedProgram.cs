using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace commandconsole;

/// <summary>
/// Hosted program.
/// </summary>
public class HostedProgram : BaseHostedCommandProgram
{
    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public override string Name => "CommandConsole";

    /// <summary>
    /// Constructor.
    /// </summary>
    ///
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    public HostedProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime, IEnumerable<IConsoleCommand> commands)
        : base(logger, lifetime, commands)
    {
    }
}