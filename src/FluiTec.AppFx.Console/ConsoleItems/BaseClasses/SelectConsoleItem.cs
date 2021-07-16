using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.Presentation;
using Spectre.Console;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    public abstract class SelectConsoleItem : ConsoleItem
    {
        /// <summary>   Gets or sets a value indicating whether the default items is shown. </summary>
        /// <value> True if show default items, false if not. </value>
        public bool ShowDefaultItems { get; protected set; } = true;

        /// <summary>   Gets the name of the display. </summary>
        /// <value> The name of the display. </value>
        public override string DisplayName => Items.Any() ? $"{Name} ({Items.Count} items)" : Name;

        /// <summary>   Gets the items. </summary>
        /// <value> The items. </value>
        public List<IConsoleItem> Items { get; }

        /// <summary>   Gets the prompt title. </summary>
        /// <value> The prompt title. </value>
        public virtual string PromptTitle { get; }

        /// <summary>   Gets the more choices text. </summary>
        /// <value> The more choices text. </value>
        public virtual string MoreChoicesText { get; }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected SelectConsoleItem()
        {
            Items = new List<IConsoleItem>();
            PromptTitle = $"Please select any {Presenter.HighlightText("item")} from the list:";
            MoreChoicesText = Presenter.DefaultText("(Move up and down to show more items)");
        }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="name"> The name. </param>
        protected SelectConsoleItem(string name) : this()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public override void Display(IConsoleItem parent)
        {
            base.Display(parent);
            
            if (!Items.Any()) return;
            Presenter.PresentHeader(Name);

            var selected = AnsiConsole.Prompt(new SelectionPrompt<IConsoleItem>()
                .Title(PromptTitle)
                .PageSize(Presenter.DefaultPageSize)
                .MoreChoicesText(MoreChoicesText)
                .AddChoices(ShowDefaultItems ? Items.Concat(CreateDefaultItems()) : Items)
                .UseConverter(ListEntryConverter)
                .HighlightStyle(Presenter.Style.SelectHighlightTextStyle)
            );

            selected.Display(this);
        }

        /// <summary>   Converters the given argument. </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>   A string. </returns>
        protected virtual string ListEntryConverter(IConsoleItem arg)
        {
            return ConsoleApplicationSettings.Instance.Presenter.DefaultListEntryConverter(arg);
        }

        /// <summary>   Enumerates create default items in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process create default items in this
        ///     collection.
        /// </returns>
        protected virtual IEnumerable<IConsoleItem> CreateDefaultItems()
        {
            return new IConsoleItem[] {new BackConsoleItem(), new ExitConsoleItem()};
        }
    }
}