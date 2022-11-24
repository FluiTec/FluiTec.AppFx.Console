using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization;

/// <summary>   Interface for window module item. </summary>
public interface IWindowModuleItem
{
    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    string Name { get; }

    /// <summary>   Gets the view. </summary>
    /// <returns>   The view. </returns>
    View GetView();
}