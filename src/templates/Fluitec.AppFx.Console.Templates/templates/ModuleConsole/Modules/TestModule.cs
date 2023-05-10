using FluiTec.AppFx.Console.Modularization;
using Terminal.Gui;

namespace Fluitec.AppFx.Console.Templates.templates.ModuleConsole.Modules;

/// <summary>   A test module. </summary>
public class TestModule : IWindowModuleItem
{
    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public string Name => "Test-Module";

    /// <summary>   Gets the view. </summary>
    /// <returns>   The view. </returns>
    public View GetView()
    {
        return new Button("Test");
    }

    /// <summary>   Returns a string that represents the current object. </summary>
    /// <returns>   A string that represents the current object. </returns>
    public override string ToString()
    {
        return Name;
    }
}