using System.CommandLine;
using FluiTec.AppFx.Console.Modularization;

namespace CommandConsole.Commands;

/// <summary>   A greet command. </summary>
public class GreetCommand : IConsoleCommand
{
    /// <summary>   Configure command. </summary>
    /// <returns>   A Command. </returns>
    public Command ConfigureCommand()
    {
        var nameArgument = new Argument<string>("name", "Name of the person to greet");
        var cmd = new Command("--greet", "Greet");
        cmd.AddArgument(nameArgument);
        cmd.SetHandler(nameValue =>
        {
            Console.WriteLine($"Hello {nameValue}!");
        }, nameArgument);
        return cmd;
    }
}