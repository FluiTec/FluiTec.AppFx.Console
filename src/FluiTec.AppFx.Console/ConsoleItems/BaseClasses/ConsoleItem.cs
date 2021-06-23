using FluiTec.AppFx.Console.Presentation;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console item. </summary>
    public abstract class ConsoleItem : IConsoleItem
    {
        /// <summary>   Gets the presenter. </summary>
        /// <value> The presenter. </value>
        protected IConsolePresenter Presenter { get; } = ConsoleApplicationSettings.Instance.Presenter;

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public abstract string Name { get; protected set; }

        /// <summary>   Displays this. </summary>
        public abstract void Display();
    }
}