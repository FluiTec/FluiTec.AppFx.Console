using System.Collections.Generic;

namespace FluiTec.AppFx.Console.Items
{
    /// <summary>   Interface for interactive console item. </summary>
    public interface IInteractiveConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        string Name { get; }

        /// <summary>   Gets the description. </summary>
        /// <value> The description. </value>
        string Description { get; }

        /// <summary>   Gets or sets the host. </summary>
        /// <value> The host. </value>
        InteractiveConsoleHost Host { get; set; }

        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        IInteractiveConsoleItem Parent { get; set; }

        /// <summary>   Gets a value indicating whether this  has parent. </summary>
        /// <value> True if this  has parent, false if not. </value>
        bool HasParent { get; }

        /// <summary>   Gets the children. </summary>
        /// <value> The children. </value>
        IList<IInteractiveConsoleItem> Children { get; }

        /// <summary>   Gets a value indicating whether this  has children. </summary>
        /// <value> True if this  has children, false if not. </value>
        bool HasChildren { get; }

        /// <summary>   Executes the picked action. </summary>
        /// <remarks>
        /// Will be triggered upon getting the item selected.
        /// </remarks>
        void OnPicked();
    }
}