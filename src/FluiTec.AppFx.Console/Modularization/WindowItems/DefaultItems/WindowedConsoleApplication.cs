using System.Collections.Generic;
using FluiTec.AppFx.Console.Hosting.WindowHosting;
using FluiTec.AppFx.Console.Modularization.WindowItems.ListDataSource;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization.WindowItems.DefaultItems;

/// <summary>   A windowed console application. </summary>
public class WindowedConsoleApplication
{
    /// <summary>   Constructor. </summary>
    /// <param name="name">         The name. </param>
    /// <param name="moduleItems">  The module items. </param>
    /// <param name="menuItems">    The menu items. </param>
    public WindowedConsoleApplication(string name, IEnumerable<IWindowModuleItem> moduleItems,
        IEnumerable<IWindowMenuItem> menuItems)
    {
        Name = name;
        ModuleItems = moduleItems;
        MenuItems = menuItems;
    }

    /// <summary>   Gets the name. </summary>
    /// <value> The name. </value>
    public string Name { get; }

    /// <summary>   Gets the module items. </summary>
    /// <value> The module items. </value>
    public IEnumerable<IWindowModuleItem> ModuleItems { get; }

    /// <summary>   Gets the menu items. </summary>
    /// <value> The menu items. </value>
    public IEnumerable<IWindowMenuItem> MenuItems { get; }

    /// <summary>   Runs this object. </summary>
    public void Run()
    {
        Application.Init();

        var topMenu = new MenuBar(BuildMenu());
        var window = CreateMainWindow();
        var lPane = CreateLeftPane();
        window.Add(lPane);
        var rPane = CreateRightPane();
        window.Add(rPane);

        lPane.Add(CreateModuleList(lPane, rPane));

        lPane.FocusFirst();
        Application.Top.Add(topMenu, window);
        Application.Run();
        Application.Shutdown();
    }

    /// <summary>
    ///     Creates main window.
    /// </summary>
    /// <returns>
    ///     The new main window.
    /// </returns>
    protected virtual Window CreateMainWindow()
    {
        return new Window(Name)
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill() - 1
        };
    }

    /// <summary>
    ///     Creates left pane.
    /// </summary>
    /// <returns>
    ///     The new left pane.
    /// </returns>
    protected virtual FrameView CreateLeftPane()
    {
        var leftPane = new FrameView("Modules")
        {
            X = 0,
            Y = 1,
            Width = 25,
            Height = Dim.Fill(1),
            CanFocus = false,
            Shortcut = Key.CtrlMask | Key.C
        };
        leftPane.Title = $"{leftPane.Title} ({leftPane.ShortcutTag})";
        leftPane.ShortcutAction = () => leftPane.SetFocus();

        return leftPane;
    }

    /// <summary>   Creates right pane. </summary>
    /// <returns>   The new right pane. </returns>
    protected virtual FrameView CreateRightPane()
    {
        var rightPane = new FrameView("Module Actions")
        {
            X = 25,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill(1),
            CanFocus = true,
            Shortcut = Key.CtrlMask | Key.S
        };
        rightPane.Title = $"{rightPane.Title} ({rightPane.ShortcutTag})";
        rightPane.ShortcutAction = () => rightPane.SetFocus();

        return rightPane;
    }

    /// <summary>   Creates module list. </summary>
    /// <param name="lPane">    The pane. </param>
    /// <param name="rPane">    The pane. </param>
    /// <returns>   The new module list. </returns>
    protected virtual View CreateModuleList(FrameView lPane, FrameView rPane)
    {
        var listView = new ListView(new ModuleListDataSource(ModuleItems))
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(2),
            Height = Dim.Fill(),
            AutoSize = true,
            AllowsMarking = false,
            AllowsMultipleSelection = false,
            CanFocus = true
        };

        listView.SelectedItemChanged += args =>
        {
            rPane.Clear();
            if (listView.Source.ToList()[args.Item] is not IWindowModuleItem item) return;

            rPane.Add(item.GetView());
        };

        return listView;
    }

    /// <summary>
    ///     Builds the menu.
    /// </summary>
    /// <returns>
    ///     A MenuBarItem[].
    /// </returns>
    protected virtual MenuBarItem[] BuildMenu()
    {
        return new MenuBuilder().BuildMenu(MenuItems);
    }
}