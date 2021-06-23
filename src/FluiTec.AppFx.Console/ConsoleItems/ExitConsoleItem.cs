namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   An exit console item. </summary>
    public class ExitConsoleItem : IConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; } = "Quit application";

        /// <summary>   Displays this. </summary>
        public void Display()
        {
            // ignore and don't give control back
        }
    }
}