using System;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A module console item. </summary>
    public abstract class ModuleConsoleItem : SelectConsoleItem
    {
        private ConsoleApplication _application;

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <param name="name">         The name. </param>
        protected ModuleConsoleItem(string name)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public override string Name { get; protected set; }

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
    }
}