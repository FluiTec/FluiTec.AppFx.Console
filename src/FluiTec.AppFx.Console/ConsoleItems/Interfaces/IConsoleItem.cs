namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   Interface for console item. </summary>
    public interface IConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        IConsoleItem Parent { get; set; }

        /// <summary>   Displays this.  </summary>
        public void Display();
    }
}