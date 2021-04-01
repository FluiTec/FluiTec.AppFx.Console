namespace FluiTec.AppFx.Console.Menu
{
    /// <summary>   A console module. </summary>
    public class ConsoleModule : BaseMenuItem, IConsoleModule
    {
        /// <summary>   Constructor. </summary>
        /// <param name="host"> The host. </param>
        public ConsoleModule(InteractiveConsoleHost host) : base(host)
        {
            
        }
    }
}