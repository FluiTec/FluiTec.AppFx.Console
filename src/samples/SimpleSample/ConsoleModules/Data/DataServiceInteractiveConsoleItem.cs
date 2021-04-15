using FluiTec.AppFx.Console.Items;
using FluiTec.AppFx.Data.Dynamic.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleSample.ConsoleModules.Data
{
    /// <summary>   A data service interactive console item. </summary>
    public class DataServiceInteractiveConsoleItem : ServiceInteractiveConsoleItem
    {
        /// <summary>   Default constructor. </summary>
        public DataServiceInteractiveConsoleItem() : base("Data", "Change data related settings")
        {

        }

        /// <summary>   Executes the picked action. </summary>
        /// <remarks>
        ///     Will be triggered upon getting the item selected. Will trigger auto-pick, when item has
        ///     children.
        /// </remarks>
        public override void OnPicked()
        {
            var options = Host.HostServices.GetService<DynamicDataOptions>();

            if (options != null)
            {
                Children.Clear();
                Children.Add(new ConfigureDataServiceInteractiveConsoleItem(options));
                Children.Add(new MigrationServiceInteractiveConsoleItem(options));
            }

            base.OnPicked();
        }
    }
}