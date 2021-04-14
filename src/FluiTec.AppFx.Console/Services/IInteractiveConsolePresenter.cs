using System.Collections.Generic;
using FluiTec.AppFx.Console.Items;

namespace FluiTec.AppFx.Console.Services
{
    /// <summary>   Interface for interactive console presenter. </summary>
    public interface IInteractiveConsolePresenter
    {
        /// <summary>   Prints the welcome message.  </summary>
        void Welcome();

        /// <summary>   Prints the help message.  </summary>
        void Help();

        /// <summary>   Presents the given console-items. </summary>
        /// <param name="items">    The console-items. </param>
        void Present(IEnumerable<IInteractiveConsoleItem> items);

        /// <summary>   Picks the given items. </summary>
        /// <param name="items">    The console-items. </param>
        void Pick(IEnumerable<IInteractiveConsoleItem> items);
    }
}