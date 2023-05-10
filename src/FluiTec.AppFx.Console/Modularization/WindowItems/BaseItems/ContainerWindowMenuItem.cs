namespace FluiTec.AppFx.Console.Modularization.WindowItems.BaseItems;

/// <summary>
///     A container menu item.
/// </summary>
public class ContainerWindowMenuItem : WindowMenuItem
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="title">    The title. </param>
    public ContainerWindowMenuItem(string title) : base(title)
    {
    }

    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="title">        The title. </param>
    /// <param name="parentTitle">  The parent title. </param>
    public ContainerWindowMenuItem(string title, string parentTitle)
        : this(title)
    {
        ParentTitle = parentTitle;
    }
}