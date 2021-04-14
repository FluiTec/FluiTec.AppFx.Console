using System.Collections.Generic;

namespace FluiTec.AppFx.Console.Items
{
    /// <summary>   A back interactive console item. </summary>
    public class BackInteractiveConsoleItem : BaseInteractiveConsoleItem
    {
        private readonly IEnumerable<IInteractiveConsoleItem> _parentSelection;

        /// <summary>   Default constructor. </summary>
        /// <param name="parentSelection">  The parent selection. </param>
        public BackInteractiveConsoleItem(IEnumerable<IInteractiveConsoleItem> parentSelection) : base("Back", "Move back to parent selection")
        {
            _parentSelection = parentSelection;
        }

        /// <summary>   Executes the picked action. </summary>
        /// <remarks>
        ///     Will be triggered upon getting the item selected. Will trigger auto-pick, when item has
        ///     children.
        /// </remarks>
        public override void OnPicked()
        {
            Host.Presenter.Pick(_parentSelection);
        }
    }
}