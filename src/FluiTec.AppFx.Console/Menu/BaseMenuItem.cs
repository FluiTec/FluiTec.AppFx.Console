using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.Extensions;

namespace FluiTec.AppFx.Console.Menu
{
    public abstract class BaseMenuItem : IConsoleMenuItem
    {
        /// <summary>   Gets the host. </summary>
        /// <value> The host. </value>
        public InteractiveConsoleHost Host { get; }

        /// <summary>   Gets or sets the default color. </summary>
        /// <value> The default color. </value>
        public ConsoleColor DefaultColor { get; protected set; }

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
        public IConsoleMenuItem Parent { get; set; }

        /// <summary>   Gets a value indicating whether this  has parent. </summary>
        /// <value> True if this  has parent, false if not. </value>
        public bool HasParent => Parent != null;

        /// <summary>   Gets or sets the children. </summary>
        /// <value> The children. </value>
        public IEnumerable<IConsoleMenuItem> Children { get; set; }

        /// <summary>   Gets a value indicating whether this  has children. </summary>
        /// <value> True if this  has children, false if not. </value>
        public bool HasChildren => Children.Any();

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected BaseMenuItem(InteractiveConsoleHost host)
        {
            Host = host;
            Children = new List<IConsoleMenuItem>();
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <param name="host">     The host. </param>
        /// <param name="children"> The children. </param>
        protected BaseMenuItem(InteractiveConsoleHost host, IEnumerable<IConsoleMenuItem> children)
        {
            Host = host;
            Children = new List<IConsoleMenuItem>(children ?? Array.Empty<IConsoleMenuItem>());
            foreach (var child in Children)
                child.Parent = this;
        }

        /// <summary>   Executes the select action. </summary>
        public virtual void OnSelect()
        {
            ConsoleExtension.WriteLine($">>{Name}", DefaultColor);
        }
    }
}