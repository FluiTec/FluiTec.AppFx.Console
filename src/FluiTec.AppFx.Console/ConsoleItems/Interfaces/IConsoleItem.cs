namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   Interface for console item. </summary>
    public interface IConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>   Displays this.  </summary>
        public void Display();
    }
}