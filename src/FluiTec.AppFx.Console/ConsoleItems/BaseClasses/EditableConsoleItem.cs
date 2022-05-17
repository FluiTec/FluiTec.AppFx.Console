using System;
using Spectre.Console;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   An editable console item. </summary>
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    // ReSharper disable once UnusedMember.Global
    public abstract class EditableConsoleItem<T> : ConsoleItem
    {
        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="name"> The name. </param>
        protected EditableConsoleItem(string name) : base(name)
        {
        }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public virtual T Value
        {
            get => GetValue();
            set
            {
                var currentValue = GetValue();
                if ((value == null && currentValue != null) || (currentValue == null && value != null))
                {
                    AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new value")} is \"{value}\"");
                    SetValue(value);
                    AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new value")} was saved");
                }
                else
                {
                    AnsiConsole.MarkupLine(
                        $"The new value {Presenter.HighlightText("equals")} the current value - no changes saved");
                }
            }
        }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public override void Display(IConsoleItem parent)
        {
            base.Display(parent);

            Presenter.PresentHeader($"View/Edit {{{Name}}} - current value:");
            AnsiConsole.WriteLine(Value?.ToString() ?? "(null)");
            AnsiConsole.Write(new Rule().RuleStyle(Presenter.Style.DefaultTextStyle).LeftAligned());
            if (AnsiConsole.Confirm("Edit value?"))
                Value = AnsiConsole.Ask<T>(
                    $"Please enter a {Presenter.HighlightText("new value")}:{Environment.NewLine}");
        }

        /// <summary>   Gets the value. </summary>
        /// <returns>   The value. </returns>
        protected abstract T GetValue();

        /// <summary>   Sets a value. </summary>
        /// <param name="value">    The value. </param>
        protected abstract void SetValue(T value);
    }
}