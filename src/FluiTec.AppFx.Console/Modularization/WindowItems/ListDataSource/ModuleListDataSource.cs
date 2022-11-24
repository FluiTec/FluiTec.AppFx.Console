using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization.WindowItems.ListDataSource;

/// <summary>
///     A module list data source.
/// </summary>
public class ModuleListDataSource : CustomListWrapper<IWindowModuleItem>
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="source">   Source for the. </param>
    public ModuleListDataSource(IEnumerable<IWindowModuleItem> source) : base(source.ToList())
    {
    }

    /// <summary>
    ///     Renders a <see cref="T:Terminal.Gui.ListView" /> item to the appropriate type.
    /// </summary>
    /// <param name="container">    The ListView. </param>
    /// <param name="driver">       The driver used by the caller. </param>
    /// <param name="marked">       Informs if it's marked or not. </param>
    /// <param name="item">         The item. </param>
    /// <param name="col">          The col where to move. </param>
    /// <param name="line">         The line where to move. </param>
    /// <param name="width">        The item width. </param>
    /// <param name="start">        (Optional) The index of the string to be displayed. </param>
    public override void Render(ListView container, ConsoleDriver driver, bool marked, int item, int col, int line,
        int width,
        int start = 0)
    {
        container.Move(col, line);
        var t = Src[item];

        RenderUstr(driver, t.Name, col, line, width, start);
    }
}