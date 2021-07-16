namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A back console item. </summary>
    public class BackConsoleItem : IConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; } = "Back to parent item";

        /// <summary>   Gets the name of the display. </summary>
        /// <value> The name of the display. </value>
        public string DisplayName => Name;

        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        public IConsoleItem Parent { get; private set; }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public void Display(IConsoleItem parent)
        {
            Parent = parent.Parent;
            Parent.Display(null);
        }
    }
}