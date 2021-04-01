using System;

namespace FluiTec.AppFx.Console.Menu
{
    /// <summary>   A quit menu item. </summary>
    public class QuitMenuItem : BaseMenuItem
    {
        /// <summary>   Constructor. </summary>
        /// <param name="host">     The host. </param>
        /// <param name="parent">   The parent. </param>
        public QuitMenuItem(InteractiveConsoleHost host, IConsoleMenuItem parent) : base(host)
        {
            Parent = parent;
            Name = "Quit";
            Description = "Quit the application";

            DefaultColor = ConsoleColor.Red;
        }

        /// <summary>   Executes the select action. </summary>
        public override void OnSelect()
        {
            Host.ActiveItem = null;
            base.OnSelect();
        }
    }
}