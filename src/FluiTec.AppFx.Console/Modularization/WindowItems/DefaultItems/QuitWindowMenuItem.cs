using FluiTec.AppFx.Console.Modularization.WindowItems.BaseItems;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization.WindowItems.DefaultItems;

/// <summary>
///     A quit item.
/// </summary>
public class QuitWindowMenuItem : ActionWindowMenuItem
{
    /// <summary>
    ///     Default constructor.
    /// </summary>
    public QuitWindowMenuItem() : base("Quit", "_File", () => Application.RequestStop(), () => true)
    {
        Shortcut = Key.CtrlMask | Key.Q;
    }
}