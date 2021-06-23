namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console item. </summary>
    public abstract class ConsoleItem : IConsoleItem
    {
        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public abstract string Name { get; protected set; }

        /// <summary>   Displays this. </summary>
        public abstract void Display();
    }
}