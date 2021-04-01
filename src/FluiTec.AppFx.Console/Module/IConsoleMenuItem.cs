using System.Collections.Generic;

namespace FluiTec.AppFx.Console.Module
{
    /// <summary>   Interface for console menu item. </summary>
    public interface IConsoleMenuItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; set; }

        /// <summary>   Gets the description. </summary>
        /// <value> The description. </value>
        public string Description { get; set; }

        /// <summary>   Gets the help text. </summary>
        /// <value> The help text. </value>
        public string HelpText { get; set; }

        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        IConsoleMenuItem Parent { get; set; }

        /// <summary>   Gets a value indicating whether this  has parent. </summary>
        /// <value> True if this  has parent, false if not. </value>
        bool HasParent { get; }

        /// <summary>   Gets or sets the children. </summary>
        /// <value> The children. </value>
        IEnumerable<IConsoleMenuItem> Children { get; set; }

        /// <summary>   Gets a value indicating whether this  has children. </summary>
        /// <value> True if this  has children, false if not. </value>
        bool HasChildren { get; }
    }
}