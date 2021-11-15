namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   Interface for console item. </summary>
    public interface IConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>   Gets the name of the display. </summary>
        /// <value> The name of the display. </value>
        string DisplayName { get; }

        /// <summary>   Gets the parent. </summary>
        /// <value> The parent. </value>
        IConsoleItem? Parent { get; }

        /// <summary>   Displays this.  </summary>
        public void Display(IConsoleItem? parent);
    }
}