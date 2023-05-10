using System;
using System.Collections.Generic;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization;

/// <summary>
///     Interface for menu item.
/// </summary>
public interface IWindowMenuItem
{
    /// <summary>
    ///     Gets the title.
    /// </summary>
    /// <value>
    ///     The title.
    /// </value>
    string Title { get; }

    /// <summary>
    ///     Gets the parent title.
    /// </summary>
    /// <value>
    ///     The parent title.
    /// </value>
    string? ParentTitle { get; }

    /// <summary>
    ///     Gets the before title.
    /// </summary>
    /// <value>
    ///     The before title.
    /// </value>
    string? BeforeTitle { get; }

    /// <summary>
    ///     Gets the after title.
    /// </summary>
    /// <value>
    ///     The after title.
    /// </value>
    string? AfterTitle { get; }

    /// <summary>
    ///     Gets the shortcut.
    /// </summary>
    /// <value>
    ///     The shortcut.
    /// </value>
    Key Shortcut { get; }

    /// <summary>
    ///     Gets the execute.
    /// </summary>
    /// <value>
    ///     The execute.
    /// </value>
    Action? Execute { get; }

    /// <summary>
    ///     Gets the can execute.
    /// </summary>
    /// <value>
    ///     A function delegate that yields a bool.
    /// </value>
    Func<bool>? CanExecute { get; }

    /// <summary>
    ///     Gets the children.
    /// </summary>
    /// <value>
    ///     The children.
    /// </value>
    IList<IWindowMenuItem> Children { get; }
}