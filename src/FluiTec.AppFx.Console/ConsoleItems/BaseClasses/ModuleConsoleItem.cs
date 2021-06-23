namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A module console item. </summary>
    public abstract class ModuleConsoleItem : SelectConsoleItem
    {
        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public override string Name { get; protected set; }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected ModuleConsoleItem()
        {

        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <param name="name"> The name. </param>
        protected ModuleConsoleItem(string name)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Name = name;
        }
    }
}