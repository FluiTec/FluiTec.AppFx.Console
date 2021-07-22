using FluiTec.AppFx.Console.ConsoleItems;
using FluiTec.AppFx.Data.DataServices;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleSample
{
    /// <summary>   A dynamic data console module. </summary>
    public class DynamicDataConsoleModule : ModuleConsoleItem
    {
        /// <summary>   Default constructor. </summary>
        public DynamicDataConsoleModule() : base("Data")
        {
        }

        /// <summary>   Initializes this. </summary>
        protected override void Initialize()
        {
            var dataServices = Application.HostServices.GetRequiredService<IDataService>();
        }
    }
}