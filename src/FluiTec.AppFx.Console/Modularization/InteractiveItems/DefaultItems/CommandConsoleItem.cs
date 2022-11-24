using FluiTec.AppFx.Console.Modularization.InteractiveItems.BaseItems;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.Interfaces;

namespace FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;

/// <summary>   A command item. </summary>
public class CommandConsoleItem : ConsoleItem
{
    /// <summary>   Constructor. </summary>
    /// <param name="name"> The name. </param>
    public CommandConsoleItem(string name) : base(name)
    {
    }

    /// <summary>   Displays this. </summary>
    /// <param name="parent">   The parent. </param>
    public override void Display(IInteractiveConsoleItem parent)
    {
        Parent = parent?.Parent;
        Parent?.Display(null);
    }
}