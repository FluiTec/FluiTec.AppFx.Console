using System.CommandLine;

namespace FluiTec.AppFx.Console.Modularization;

/// <summary>   Interface for console command. </summary>
public interface IConsoleCommand
{
    /// <summary>   Configure command. </summary>
    /// <returns>   A Command. </returns>
    Command ConfigureCommand();
}