using FluiTec.AppFx.Console.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SimpleConsole;

/// <summary>
/// Hosted program.
/// </summary>
public class HostedProgram : BaseHostedProgram
{
    /// <summary>
    /// Constructor.
    /// </summary>
    ///
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    public HostedProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime)
        : base(logger, lifetime)
    {
    }

    /// <summary>
    /// Runs the given arguments.
    /// </summary>
    ///
    /// <param name="args"> The arguments. </param>
    public override void Run(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}