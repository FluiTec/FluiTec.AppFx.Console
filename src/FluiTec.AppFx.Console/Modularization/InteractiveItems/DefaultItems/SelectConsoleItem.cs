using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.BaseItems;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.Interfaces;
using Spectre.Console;

namespace FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;

/// <summary>   A select console item. </summary>
public abstract class SelectConsoleItem : ConsoleItem
{
    /// <summary>   Specialized constructor for use only by derived class. </summary>
    /// <param name="name"> The name. </param>
    protected SelectConsoleItem(string name) : base(name)
    {
        Items = new List<IInteractiveConsoleItem>();
        PromptTitle = "Please select any [gold3]item[/] from the list:";
        MoreChoicesText = "(Move up and down to show more items)";
    }

    /// <summary>   Gets or sets a value indicating whether the default items is shown. </summary>
    /// <value> True if show default items, false if not. </value>
    public bool ShowDefaultItems { get; protected set; } = true;

    /// <summary>   Gets the items string. </summary>
    /// <value> The items string. </value>
    private string ItemsString => Items.Count > 1 ? "items" : "item";

    /// <summary>   Gets the name of the display. </summary>
    /// <value> The name of the display. </value>
    public override string DisplayName => Items.Any() ? $"{Name} ({Items.Count} {ItemsString})" : Name;

    /// <summary>   Gets the items. </summary>
    /// <value> The items. </value>
    public List<IInteractiveConsoleItem> Items { get; }

    /// <summary>   Gets the prompt title. </summary>
    /// <value> The prompt title. </value>
    public virtual string PromptTitle { get; }

    /// <summary>   Gets the more choices text. </summary>
    /// <value> The more choices text. </value>
    public virtual string MoreChoicesText { get; }

    /// <summary>   Displays this. </summary>
    /// <param name="parent">   The parent. </param>
    public override void Display(IInteractiveConsoleItem parent)
    {
        base.Display(parent);

        if (!Items.Any()) return;

        var selected = AnsiConsole.Prompt(new SelectionPrompt<IInteractiveConsoleItem>()
            .Title(PromptTitle)
            .PageSize(10)
            .MoreChoicesText(MoreChoicesText)
            .AddChoices(ShowDefaultItems ? Items.Concat(CreateDefaultItems()) : Items)
            .UseConverter(ListEntryConverter)
            .HighlightStyle("gold3")
        );

        selected.Display(this);
    }

    /// <summary>   Converters the given argument. </summary>
    /// <param name="arg">  The argument. </param>
    /// <returns>   A string. </returns>
    protected virtual string ListEntryConverter(IInteractiveConsoleItem arg)
    {
        return arg.DisplayName;
    }


    /// <summary>   Enumerates create default items in this collection. </summary>
    /// <returns>
    ///     An enumerator that allows foreach to be used to process create default items in this
    ///     collection.
    /// </returns>
    protected virtual IEnumerable<IInteractiveConsoleItem> CreateDefaultItems()
    {
        return new IInteractiveConsoleItem[] { new BackConsoleItem(), new ExitConsoleItem() };
    }
}