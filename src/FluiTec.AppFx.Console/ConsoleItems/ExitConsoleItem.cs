namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   An exit console item. </summary>
    public class ExitConsoleItem : ConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public sealed override string Name { get; protected set; }

        public ExitConsoleItem()
        {
            Name = "Quit application";
        }

        /// <summary>   Displays this. </summary>
        public override void Display(IConsoleItem parent)
        {
            Presenter.PresentHeader(Name);
        }
    }
}