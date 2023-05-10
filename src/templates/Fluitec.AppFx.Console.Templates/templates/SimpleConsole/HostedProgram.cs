using FluiTec.AppFx.Console.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fluitec.AppFx.Console.Templates.templates.SimpleConsole;

/// <summary>
///     Hosted program.
/// </summary>
public class HostedProgram : ConsoleHostedProgram
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    public HostedProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime)
        : base(logger, lifetime)
    {
    }

    /// <summary>
    ///     Runs the given arguments.
    /// </summary>
    /// <param name="args"> The arguments. </param>
    public override void Run(string[] args)
    {
        System.Console.WriteLine("Hello World!");
    }
}