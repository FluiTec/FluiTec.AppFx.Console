using System;
using FluiTec.AppFx.Console.Presentation;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console item. </summary>
    public abstract class ConsoleItem : IConsoleItem
    {
        /// <summary>   Gets or sets the parent. </summary>
        /// <value> The parent. </value>
        public IConsoleItem Parent { get; set; }

        /// <summary>   Gets the presenter. </summary>
        /// <value> The presenter. </value>
        protected IConsolePresenter Presenter { get; } = ConsoleApplicationSettings.Instance.Presenter;

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public virtual string Name { get; protected set; }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected ConsoleItem()
        {
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="name"> The name. </param>
        protected ConsoleItem(string name)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <param name="parent">   The parent. </param>
        protected ConsoleItem(IConsoleItem parent)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="name">     The name. </param>
        /// <param name="parent">   The parent. </param>
        protected ConsoleItem(string name, IConsoleItem parent)
        {
            // ReSharper disable VirtualMemberCallInConstructor
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            // ReSharper enable VirtualMemberCallInConstructor
        }

        /// <summary>   Displays this. </summary>
        public abstract void Display();
    }
}