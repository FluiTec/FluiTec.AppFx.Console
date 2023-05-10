using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization.WindowItems.BaseItems;

/// <summary>
///     A menu item.
/// </summary>
public abstract class WindowMenuItem : IWindowMenuItem
{
    /// <summary>
    ///     Specialized default constructor for use only by derived class.
    /// </summary>
    protected WindowMenuItem(string title)
    {
        Title = title;
        Children = new List<IWindowMenuItem>();
    }

    /// <summary>
    ///     Gets or sets the title.
    /// </summary>
    /// <value>
    ///     The title.
    /// </value>
    public string Title { get; init; }

    /// <summary>
    ///     Gets or sets the parent title.
    /// </summary>
    /// <value>
    ///     The parent title.
    /// </value>
    public string? ParentTitle { get; init; }

    /// <summary>
    ///     Gets or sets the before title.
    /// </summary>
    /// <value>
    ///     The before title.
    /// </value>
    public string? BeforeTitle { get; init; }

    /// <summary>
    ///     Gets or sets the after title.
    /// </summary>
    /// <value>
    ///     The after title.
    /// </value>
    public string? AfterTitle { get; init; }

    /// <summary>
    ///     Gets or sets the shortcut.
    /// </summary>
    /// <value>
    ///     The shortcut.
    /// </value>
    public Key Shortcut { get; init; }

    /// <summary>
    ///     Gets or sets the execute.
    /// </summary>
    /// <value>
    ///     The execute.
    /// </value>
    public Action? Execute { get; init; }

    /// <summary>
    ///     Gets or sets the can execute.
    /// </summary>
    /// <value>
    ///     A function delegate that yields a bool.
    /// </value>
    public Func<bool>? CanExecute { get; init; }

    public IList<IWindowMenuItem> Children { get; init; }
}