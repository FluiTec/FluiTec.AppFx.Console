using System;
using FluiTec.AppFx.Console.Presentation;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console item. </summary>
    public abstract class ConsoleItem : IConsoleItem
    {
        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected ConsoleItem()
        {
        }

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
        public IConsoleItem Parent { get; protected set; }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public virtual void Display(IConsoleItem parent)
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

    /// <summary>   An editable console item. </summary>
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    public abstract class EditableConsoleItem<T> : ConsoleItem
    {
        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public virtual T Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected EditableConsoleItem()
        {
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="name"> The name. </param>
        protected EditableConsoleItem(string name) : base(name)
        {

        }

        /// <summary>   Gets the value. </summary>
        /// <returns>   The value. </returns>
        protected abstract T GetValue();

        /// <summary>   Sets a value. </summary>
        /// <param name="value">    The value. </param>
        protected abstract void SetValue(T value);
    }
}