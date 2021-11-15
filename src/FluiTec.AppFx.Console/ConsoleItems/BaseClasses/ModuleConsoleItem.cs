using System;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A module console item. </summary>
    public abstract class ModuleConsoleItem : SelectConsoleItem
    {
        private ConsoleApplication _application = null!;

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <param name="name">         The name. </param>
        protected ModuleConsoleItem(string name) : base(name)
        {
        }

        /// <summary>   Gets or sets the application. </summary>
        /// <value> The application. </value>
        public ConsoleApplication Application
        {
            get => _application;
            protected internal set
            {
                _application = value;
                Initialize();
            }
        }

        /// <summary>   Initializes this.  </summary>
        protected abstract void Initialize();

        /// <summary>
        /// Configure command.
        /// </summary>
        ///
        /// <returns>
        /// A System.CommandLine.Command.
        /// </returns>
        public abstract System.CommandLine.Command ConfigureCommand();
    }
}