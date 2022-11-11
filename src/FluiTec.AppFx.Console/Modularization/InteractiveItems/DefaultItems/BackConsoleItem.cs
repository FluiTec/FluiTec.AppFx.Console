using FluiTec.AppFx.Console.Modularization.InteractiveItems.Interfaces;

namespace FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems
{
    /// <summary>   A back console item. </summary>
    public class BackConsoleItem : IInteractiveConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name => "Back to parent item";

        /// <summary>   Gets the name of the display. </summary>
        /// <value> The name of the display. </value>
        public string DisplayName => Name;

        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        public IInteractiveConsoleItem Parent { get; private set; }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public void Display(IInteractiveConsoleItem parent)
        {
            Parent = parent?.Parent;
            Parent?.Display(null);
        }
    }
}