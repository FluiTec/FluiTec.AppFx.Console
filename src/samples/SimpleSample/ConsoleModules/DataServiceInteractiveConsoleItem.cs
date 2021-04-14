using FluiTec.AppFx.Console.Items;

namespace SimpleSample.ConsoleModules
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
            var host = Host;
            base.OnPicked();
        }
    }
}