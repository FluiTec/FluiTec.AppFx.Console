namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   An exit console item. </summary>
    public class ExitConsoleItem : ConsoleItem
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ExitConsoleItem() : base("Quit application")
        {
        }

        /// <summary>   Displays this. </summary>
        public override void Display(IConsoleItem? parent)
        {
            Presenter.PresentHeader(Name);
        }
    }
}