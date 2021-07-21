namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   An exit console item. </summary>
    public class ExitConsoleItem : ConsoleItem
    {
        public ExitConsoleItem()
        {
            Name = "Quit application";
        }

        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public sealed override string Name { get; protected set; }

        /// <summary>   Displays this. </summary>
        public override void Display(IConsoleItem parent)
        {
            Presenter.PresentHeader(Name);
        }
    }
}