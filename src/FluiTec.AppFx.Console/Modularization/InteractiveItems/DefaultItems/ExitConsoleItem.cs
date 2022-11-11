using FluiTec.AppFx.Console.Modularization.InteractiveItems.BaseItems;
using Spectre.Console;

namespace FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems
{
    /// <summary>   An exit console item. </summary>
    public class ExitConsoleItem : ConsoleItem
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        public ExitConsoleItem() : base("Quit application")
        {
        }

        /// <summary>   Displays this. </summary>
        public override void Display(IInteractiveConsoleItem parent)
        {
            AnsiConsole.Markup($"[gold3]{Name}[/]");
        }
    }
}