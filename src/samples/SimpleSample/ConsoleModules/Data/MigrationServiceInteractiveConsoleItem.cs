using FluiTec.AppFx.Data.Dynamic.Configuration;

namespace SimpleSample.ConsoleModules.Data
{
    /// <summary>   A migration service interactive console item. </summary>
    public class MigrationServiceInteractiveConsoleItem : BaseDataServiceInteractiveConsoleItem 
    {
        /// <summary>   Default constructor. </summary>
        public MigrationServiceInteractiveConsoleItem(DynamicDataOptions options) : base("Migrations", "Apply migrations to the database", options)
        {
            
        }
    }
}