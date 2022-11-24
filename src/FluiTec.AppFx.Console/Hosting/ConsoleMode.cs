namespace FluiTec.AppFx.Console.Hosting;

public enum ConsoleMode
{
    /// <summary>   Simple console-app without additional help. </summary>
    Run = 0,

    /// <summary>   Console-app using System.CommandLine. </summary>
    Command = 1,

    /// <summary>   Console-app using Spectre.Console. Simplified modularization. </summary>
    Interactive = 2,

    /// <summary>   Console-app using gui-cs Terminal-Gui. Advanced modularization. </summary>
    Window = 3
}