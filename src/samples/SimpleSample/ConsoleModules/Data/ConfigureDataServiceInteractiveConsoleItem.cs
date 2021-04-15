using FluiTec.AppFx.Data.Dynamic.Configuration;

namespace SimpleSample.ConsoleModules.Data
{
    /// <summary>   A configure data service interactive console item. </summary>
    public class ConfigureDataServiceInteractiveConsoleItem : BaseDataServiceInteractiveConsoleItem
    {
        /// <summary>   Constructor. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public ConfigureDataServiceInteractiveConsoleItem(DynamicDataOptions options) : base("Options",
            "View and change configuration", options)
        {

        }
    }
}