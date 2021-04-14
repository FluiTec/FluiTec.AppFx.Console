namespace FluiTec.AppFx.Console.Items
{
    /// <summary>   An exit interactive console item. </summary>
    public class ExitInteractiveConsoleItem : BaseInteractiveConsoleItem
    {
        /// <summary>   Default constructor. </summary>
        public ExitInteractiveConsoleItem() : base("Exit", "Exit the application")
        {
        }

        /// <summary>   Executes the picked action. </summary>
        /// <remarks>
        ///     Will be triggered upon getting the item selected. Will trigger auto-pick, when item has
        ///     children.
        /// </remarks>
        public override void OnPicked()
        {
            // ignore
        }
    }
}