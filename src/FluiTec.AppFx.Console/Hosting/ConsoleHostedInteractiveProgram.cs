using System;
using System.Collections.Generic;
using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Console.Hosting;

/// <summary>   A console hosted interactive program. </summary>
public abstract class ConsoleHostedInteractiveProgram : ConsoleHostedProgram
{
    /// <summary>   Constructor. </summary>
    /// <param name="logger">   The logger. </param>
    /// <param name="lifetime"> The lifetime. </param>
    /// <param name="menus">    The menus. </param>
    protected ConsoleHostedInteractiveProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime,
        IEnumerable<IInteractiveConsoleMenu> menus)
        : base(logger, lifetime)
    {
        Menus = menus;
    }

    /// <summary>   Gets the console mode. </summary>
    /// <value> The console mode. </value>
    public override ConsoleMode ConsoleMode => ConsoleMode.Interactive;

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public abstract string Name { get; }

    /// <summary>   Gets the menus. </summary>
    /// <value> The menus. </value>
    public IEnumerable<IInteractiveConsoleMenu> Menus { get; }

    /// <summary>
    ///     Handles the error described by e.
    /// </summary>
    /// <param name="e">    An Exception to process. </param>
    protected override void HandleError(Exception e)
    {
        base.HandleError(e);
        System.Console.WriteLine("Press <Enter> to quit.");
        System.Console.ReadLine();
    }

    /// <summary>   Runs the given arguments. </summary>
    /// <param name="args"> The arguments. </param>
    public override void Run(string[] args)
    {
        var app = new InteractiveConsoleApplication(Name, Menus);
        app.Run();
    }
}