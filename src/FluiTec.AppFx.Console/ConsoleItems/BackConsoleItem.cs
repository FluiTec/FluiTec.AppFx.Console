using System;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A back console item. </summary>
    public class BackConsoleItem : IConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; } = "Back to parent item";
        
        /// <summary>   Gets the parent. </summary>
        /// <value> The parent. </value>
        public IConsoleItem Parent { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="parent">   The parent. </param>
        public BackConsoleItem(IConsoleItem parent)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>   Displays this. </summary>
        public void Display()
        {
            Parent.Display();
        }
    }
}