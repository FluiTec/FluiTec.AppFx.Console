using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    public abstract class SelectConsoleItem : ConsoleItem
    {
        /// <summary>   Gets or sets a value indicating whether the default items is shown. </summary>
        /// <value> True if show default items, false if not. </value>
        public bool ShowDefaultItems { get; protected set; } = true;

        /// <summary>   Gets or sets the page size. </summary>
        /// <value> The size of the page. </value>
        public int PageSize { get; protected set; } = 10;

        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public override string Name { get; protected set; }

        /// <summary>   Gets the items. </summary>
        /// <value> The items. </value>
        public List<IConsoleItem> Items { get; }

        /// <summary>   Specialized default constructor for use only by derived class. </summary>
        protected SelectConsoleItem()
        {
            Items = new List<IConsoleItem>();
        }

        /// <summary>   Gets the prompt title. </summary>
        /// <value> The prompt title. </value>
        public virtual string PromptTitle { get; } = "Please select any [green]item[/] from the list:";

        /// <summary>   Displays this.  </summary>
        public override void Display()
        {
            AnsiConsole.Render(new Rule($"[darkgoldenrod]{Name}[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.Prompt(new SelectionPrompt<IConsoleItem>()
                .Title(PromptTitle)
                .PageSize(PageSize)
                .MoreChoicesText("[grey](Move up and down to show more items)[/]")
                .AddChoices(ShowDefaultItems ? Items.Concat(CreateDefaultItems()) : Items)
                .UseConverter(ListEntryConverter)
                .HighlightStyle(new Style(Color.Yellow))
            );
        }

        /// <summary>   Converters the given argument. </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>   A string. </returns>
        protected virtual string ListEntryConverter(IConsoleItem arg) => arg?.Name;

        /// <summary>   Enumerates create default items in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process create default items in this
        ///     collection.
        /// </returns>
        protected virtual IEnumerable<IConsoleItem> CreateDefaultItems()
        {
            return new IConsoleItem[] {new BackConsoleItem(this), new ExitConsoleItem()};
        }
    }
}