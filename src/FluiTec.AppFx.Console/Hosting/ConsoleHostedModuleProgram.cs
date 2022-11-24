using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;
using FluiTec.AppFx.Console.Modularization.WindowItems.DefaultItems;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Console.Hosting;

/// <summary>   A console hosted module program. </summary>
public abstract class ConsoleHostedModuleProgram : ConsoleHostedProgram
{
    /// <summary>   Specialized constructor for use only by derived class. </summary>
    /// <param name="logger">       The logger. </param>
    /// <param name="lifetime">     The lifetime. </param>
    /// <param name="commands">     The commands. </param>
    /// <param name="menus">        The menus. </param>
    /// <param name="menuItems">    The menu items. </param>
    /// <param name="moduleItems">  The module items. </param>
    protected ConsoleHostedModuleProgram(ILogger<ConsoleHostedProgram> logger, IHostApplicationLifetime lifetime,
        IEnumerable<IConsoleCommand> commands, IEnumerable<IInteractiveConsoleMenu> menus,
        IEnumerable<IWindowMenuItem> menuItems, IEnumerable<IWindowModuleItem> moduleItems)
        : base(logger, lifetime)
    {
        Commands = commands;
        Menus = menus;
        MenuItems = menuItems;
        ModuleItems = moduleItems;
    }

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public abstract string Name { get; }

    /// <summary>   Gets the commands. </summary>
    /// <value> The commands. </value>
    public IEnumerable<IConsoleCommand> Commands { get; }

    /// <summary>   Gets the menus. </summary>
    /// <value> The menus. </value>
    public IEnumerable<IInteractiveConsoleMenu> Menus { get; }

    /// <summary>   Gets the menu items. </summary>
    /// <value> The menu items. </value>
    protected IEnumerable<IWindowMenuItem> MenuItems { get; }

    /// <summary>   Gets the module items. </summary>
    /// <value> The module items. </value>
    protected IEnumerable<IWindowModuleItem> ModuleItems { get; }

    /// <summary>   Runs the given arguments. </summary>
    /// <param name="args"> The arguments. </param>
    public override void Run(string[] args)
    {
        var cmd = CreateRunModeCommand(args);
        var runModeArgs = GetRunModeArguments(cmd, args);
        cmd.Invoke(runModeArgs);
    }

    /// <summary>
    ///     Handles the error described by e.
    /// </summary>
    /// <param name="e">    An Exception to process. </param>
    protected override void HandleError(Exception e)
    {
        base.HandleError(e);
        if (ConsoleMode is ConsoleMode.Run or ConsoleMode.Command) return;

        System.Console.WriteLine("Press <Enter> to quit.");
        System.Console.ReadLine();
    }

    /// <summary>   Creates run mode command. </summary>
    /// <param name="args"> The arguments. </param>
    /// <returns>   The new run mode command. </returns>
    protected virtual Command CreateRunModeCommand(string[] args)
    {
        var rootCmd = new RootCommand(Name);

        var commandCmd = new Command("--command", "Switch to enable command processing");
        commandCmd.AddAlias("-c");
        commandCmd.SetHandler(() =>
        {
            ConsoleMode = ConsoleMode.Command;
            CreateRootCommand().Invoke(GetNormalArguments(rootCmd, args));
        });

        var interactiveCmd = new Command("--interactive", "Switch to enable interactive mode");
        interactiveCmd.AddAlias("-i");
        interactiveCmd.SetHandler(() =>
        {
            ConsoleMode = ConsoleMode.Interactive;
            new InteractiveConsoleApplication(Name, Menus).Run();
        });

        var windowedCmd = new Command("--windowed", "Switch to enable windowed mode");
        windowedCmd.AddAlias("-w");
        windowedCmd.SetHandler(() =>
        {
            ConsoleMode = ConsoleMode.Window;
            new WindowedConsoleApplication(Name, ModuleItems, MenuItems).Run();
        });

        rootCmd.AddCommand(commandCmd);
        rootCmd.AddCommand(interactiveCmd);
        rootCmd.AddCommand(windowedCmd);

        return rootCmd;
    }

    /// <summary>   Gets run mode arguments. </summary>
    /// <param name="runModeCommand">   The run mode command. </param>
    /// <param name="args">             The arguments. </param>
    /// <returns>   An array of string. </returns>
    protected virtual string[] GetRunModeArguments(Command runModeCommand, string[] args)
    {
        var aliases = runModeCommand.Children.Where(c => c is Command).Cast<Command>().SelectMany(c => c.Aliases);
        return args.Where(a => aliases.Contains(a)).ToArray();
    }

    /// <summary>   Gets normal arguments. </summary>
    /// <param name="runModeCommand">   The run mode command. </param>
    /// <param name="args">             The arguments. </param>
    /// <returns>   An array of string. </returns>
    protected virtual string[] GetNormalArguments(Command runModeCommand, string[] args)
    {
        var aliases = runModeCommand.Children.Where(c => c is Command).Cast<Command>().SelectMany(c => c.Aliases);
        return args.Where(a => !aliases.Contains(a)).ToArray();
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