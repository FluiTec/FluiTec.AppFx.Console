using System.Collections.Generic;

namespace FluiTec.AppFx.Console.Menu
{
    /// <summary>   A root menu item. </summary>
    public class RootMenuItem : BaseMenuItem
    {
        /// <summary>   Constructor. </summary>
        /// <param name="name">         The name. </param>
        /// <param name="description">  The description. </param>
        /// <param name="host">         The host. </param>
        /// <param name="modules">      The modules. </param>
        public RootMenuItem(string name, string description, InteractiveConsoleHost host, IEnumerable<IConsoleModule> modules) : base(host, modules)
        {
            Name = name;
            Description = description;
        }
    }
}