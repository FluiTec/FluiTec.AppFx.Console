using FluiTec.AppFx.Console.ConsoleItems;

namespace SimpleSample
{
    /// <summary>   A connection strings console item. </summary>
    public class ConnectionStringsConsoleItem : SelectConsoleItem
    {
        /// <summary>   Gets the module. </summary>
        /// <value> The module. </value>
        public DynamicDataConsoleModule Module { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="module">   The module. </param>
        public ConnectionStringsConsoleItem(DynamicDataConsoleModule module) : base("ConnectionStrings")
        {
            Module = module;
        }
    }
}