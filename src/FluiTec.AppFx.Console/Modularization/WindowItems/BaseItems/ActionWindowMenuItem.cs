using System;

namespace FluiTec.AppFx.Console.Modularization.WindowItems.BaseItems;

/// <summary>
///     An action menu item.
/// </summary>
public class ActionWindowMenuItem : WindowMenuItem
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="title">    The title. </param>
    /// <param name="execute">  The execute. </param>
    public ActionWindowMenuItem(string title, Action execute) : base(title)
    {
        Execute = execute;
        CanExecute = () => true;
    }

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="title">        The title. </param>
    /// <param name="execute">      The execute. </param>
    /// <param name="canExecute">   The can execute. </param>
    public ActionWindowMenuItem(string title, Action execute, Func<bool> canExecute)
        : this(title, execute)
    {
        CanExecute = canExecute;
    }

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="title">        The title. </param>
    /// <param name="parentTitle">  The parent title. </param>
    /// <param name="execute">      The execute. </param>
    /// <param name="canExecute">   The can execute. </param>
    public ActionWindowMenuItem(string title, string parentTitle, Action execute, Func<bool> canExecute)
        : this(title, execute, canExecute)
    {
        ParentTitle = parentTitle;
    }
}