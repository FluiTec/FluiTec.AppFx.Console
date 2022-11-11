namespace FluiTec.AppFx.Console.Modularization
{
    /// <summary>   Interface for interactive console item. </summary>
    public interface IInteractiveConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>   Gets the name of the display. </summary>
        /// <value> The name of the display. </value>
        string DisplayName { get; }

        /// <summary>   Gets the parent. </summary>
        /// <value> The parent. </value>
        IInteractiveConsoleItem Parent { get; }

        /// <summary>   Displays the given parent. </summary>
        /// <param name="parent">   The parent. </param>
        void Display(IInteractiveConsoleItem parent);
    }
}