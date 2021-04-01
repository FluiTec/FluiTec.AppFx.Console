namespace FluiTec.AppFx.Console.Menu
{
    /// <summary>   A back menu item. </summary>
    public class BackMenuItem : BaseMenuItem
    {
        /// <summary>   Constructor. </summary>
        /// <param name="host">     The host. </param>
        /// <param name="parent">   The parent. </param>
        public BackMenuItem(InteractiveConsoleHost host, IConsoleMenuItem parent) : base(host)
        {
            Parent = parent;
            Name = "Back";
            Description = "Move back to the parent item";
        }

        /// <summary>   Executes the select action. </summary>
        public override void OnSelect()
        {
            Host.ActiveItem = Parent;
            base.OnSelect();
        }
    }
}