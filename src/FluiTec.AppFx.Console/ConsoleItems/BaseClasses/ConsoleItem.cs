using System;
using FluiTec.AppFx.Console.Presentation;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console item. </summary>
    public abstract class ConsoleItem : IConsoleItem
    {
        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="name"> The name. </param>
        protected ConsoleItem(string name)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>   Gets the presenter. </summary>
        /// <value> The presenter. </value>
        protected IConsolePresenter Presenter { get; } = ConsoleApplicationSettings.Instance.Presenter;

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        public virtual string Name { get; protected set; }

        /// <summary>   Gets the name of the display. </summary>
        /// <value> The name of the display. </value>
        public virtual string DisplayName => Name;

        /// <summary>   Gets the parent. </summary>
        /// <value> The parent. </value>
        public IConsoleItem? Parent { get; protected set; }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public virtual void Display(IConsoleItem? parent)
        {
            if (parent != null)
                Parent = parent;
        }

        /// <summary>   Returns a string that represents the current object. </summary>
        /// <returns>   A string that represents the current object. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}