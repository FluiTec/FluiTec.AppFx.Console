using System.Collections.Generic;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.Interfaces;
using Spectre.Console;

namespace FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;

/// <summary>   An interactive console application. </summary>
public class InteractiveConsoleApplication : SelectConsoleItem
{
    /// <summary>   Constructor. </summary>
    /// <param name="name">     The name. </param>
    /// <param name="menus">    The menus. </param>
    public InteractiveConsoleApplication(string name, IEnumerable<IInteractiveConsoleMenu> menus) : base(name)
    {
        Items.AddRange(menus);
    }

    /// <summary>   Runs this object. </summary>
    public void Run()
    {
        Display(this);
    }

    /// <summary>   Displays this. </summary>
    public override void Display(IInteractiveConsoleItem? parent)
    {
        AnsiConsole.Clear();
        base.Display(parent);
    }

    /// <summary>   Enumerates create default items in this collection. </summary>
    /// <returns>
    ///     An enumerator that allows foreach to be used to process create default items in this
    ///     collection.
    /// </returns>
    protected override IEnumerable<IInteractiveConsoleItem> CreateDefaultItems()
    {
        return new IInteractiveConsoleItem[] { new ExitConsoleItem() };
    }
}