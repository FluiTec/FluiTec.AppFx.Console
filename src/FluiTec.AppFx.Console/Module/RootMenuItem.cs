using System.Collections.Generic;

namespace FluiTec.AppFx.Console.Module
{
    /// <summary>   A root menu item. </summary>
    public class RootMenuItem : BaseMenuItem
    {
        /// <summary>   Constructor. </summary>
        /// <param name="name">         The name. </param>
        /// <param name="description">  The description. </param>
        /// <param name="modules">      The modules. </param>
        public RootMenuItem(string name, string description, IEnumerable<IConsoleModule> modules) : base(modules)
        {
            Name = name;
            Description = description;
        }
    }
}