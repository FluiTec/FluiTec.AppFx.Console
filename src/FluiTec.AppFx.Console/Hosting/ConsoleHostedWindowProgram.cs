using System;
using System.Collections.Generic;
using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.WindowItems.DefaultItems;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Console.Hosting;

/// <summary>
///     A console hosted window program.
/// </summary>
public abstract class ConsoleHostedWindowProgram : ConsoleHostedProgram
{
    /// <summary>   Specialized constructor for use only by derived class. </summary>
    /// <param name="logger">       The logger. </param>
    /// <param name="lifetime">     The lifetime. </param>
    /// <param name="menuItems">    The menu items. </param>
    /// <param name="moduleItems">  The module items. </param>
    protected ConsoleHostedWindowProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime,
        IEnumerable<IWindowMenuItem> menuItems, IEnumerable<IWindowModuleItem> moduleItems) : base(logger, lifetime)
    {
        MenuItems = menuItems;
        ModuleItems = moduleItems;
    }

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public abstract string Name { get; }

    /// <summary>   Gets the console mode. </summary>
    /// <value> The console mode. </value>
    public override ConsoleMode ConsoleMode => ConsoleMode.Window;

    /// <summary>   Gets the menu items. </summary>
    /// <value> The menu items. </value>
    protected IEnumerable<IWindowMenuItem> MenuItems { get; }

    /// <summary>   Gets the module items. </summary>
    /// <value> The module items. </value>
    protected IEnumerable<IWindowModuleItem> ModuleItems { get; }

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
        new WindowedConsoleApplication(Name, ModuleItems, MenuItems).Run();
    }
}