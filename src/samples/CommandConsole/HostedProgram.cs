using FluiTec.AppFx.Console.Hosting;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CommandConsole;

/// <summary>
///     Hosted program.
/// </summary>
public class HostedProgram : ConsoleHostedCommandProgram
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    public HostedProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime,
        IEnumerable<IConsoleCommand> commands)
        : base(logger, lifetime, commands)
    {
    }

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public override string Name => "CommandConsole";
}