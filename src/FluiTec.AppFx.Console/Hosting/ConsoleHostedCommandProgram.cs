using System.Collections.Generic;
using System.CommandLine;
using FluiTec.AppFx.Console.Modularization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Console.Hosting;

/// <summary>   A console hosted command program. </summary>
public abstract class ConsoleHostedCommandProgram : ConsoleHostedProgram
{
    /// <summary>   Constructor. </summary>
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    /// <param name="commands"> The commands. </param>
    protected ConsoleHostedCommandProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime,
        IEnumerable<IConsoleCommand> commands)
        : base(logger, lifetime)
    {
        Commands = commands;
    }

    /// <summary>   Gets the console mode. </summary>
    /// <value> The console mode. </value>
    public override ConsoleMode ConsoleMode => ConsoleMode.Command;

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public abstract string Name { get; }

    /// <summary>   Gets the commands. </summary>
    /// <value> The commands. </value>
    public IEnumerable<IConsoleCommand> Commands { get; }

    /// <summary>   Runs the given arguments. </summary>
    /// <param name="args"> The arguments. </param>
    public override void Run(string[] args)
    {
        CreateRootCommand().Invoke(args);
    }

    /// <summary>   Creates root command. </summary>
    /// <returns>   The new root command. </returns>
    protected virtual Command CreateRootCommand()
    {
        var rootCmd = new RootCommand(Name);

        foreach (var cmd in Commands)
            rootCmd.Add(cmd.ConfigureCommand());

        return rootCmd;
    }
}