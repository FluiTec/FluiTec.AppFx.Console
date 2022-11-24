using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluiTec.AppFx.Console.Modularization;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Hosting.WindowHosting;

/// <summary>   A menu builder. </summary>
public class MenuBuilder
{
    /// <summary>   Builds a menu. </summary>
    /// <param name="menuItems">    The menu items. </param>
    /// <returns>   A MenuBarItem[]. </returns>
    public virtual MenuBarItem[] BuildMenu(IEnumerable<IWindowMenuItem> menuItems)
    {
        var menu = new List<IWindowMenuItem>();

        IList<IWindowMenuItem> currentItems = menuItems.ToList();
        menu.AddRange(currentItems.Where(i => string.IsNullOrWhiteSpace(i.ParentTitle)));
        foreach (var item in menu)
            AddChildren(item, ref currentItems);
        ThrowOnMissingChildren(currentItems, menu);

        SortMenu(menu);

        return TransformToMenu(menu).Cast<MenuBarItem>().ToArray();
    }

    /// <summary>
    ///     Sort menu.
    /// </summary>
    /// <param name="items">    The items. </param>
    protected virtual void SortMenu(IList<IWindowMenuItem> items)
    {
        var newList = new List<IWindowMenuItem>();
        int matched;
        do
        {
            matched = 0;
            for (var i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (string.IsNullOrWhiteSpace(item.BeforeTitle) && string.IsNullOrWhiteSpace(item.AfterTitle))
                {
                    newList.Add(item);
                    items.RemoveAt(i);
                    i--;
                    matched++;
                }
                else if (!string.IsNullOrWhiteSpace(item.BeforeTitle))
                {
                    var beforeItem = newList.SingleOrDefault(j => j.Title == item.BeforeTitle);
                    if (beforeItem == null) continue;
                    var beforeIndex = newList.IndexOf(beforeItem);
                    newList.Insert(beforeIndex, item);
                    items.RemoveAt(i);
                    i--;
                    matched++;
                }
                else if (!string.IsNullOrWhiteSpace(item.AfterTitle))
                {
                    var afterItem = newList.SingleOrDefault(j => j.Title == item.AfterTitle);
                    if (afterItem == null) continue;
                    var afterIndex = newList.IndexOf(afterItem);
                    newList.Insert(afterIndex + 1, item);
                    items.RemoveAt(i);
                    i--;
                    matched++;
                }
            }
        } while (items.Any() && matched > 0);

        ThrowOnMissingNeighbor(items);

        foreach (var item in newList)
        {
            if (item.Children.Any())
                SortMenu(item.Children);
            items.Add(item);
        }
    }

    /// <summary>
    ///     Adds a children to 'items'.
    /// </summary>
    /// <param name="parent">   The parent. </param>
    /// <param name="items">    [in,out] The items. </param>
    protected void AddChildren(IWindowMenuItem parent, ref IList<IWindowMenuItem> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];
            if (item.ParentTitle != parent.Title) continue;
            parent.Children.Add(item);
            items.RemoveAt(i);
            i--;

            if (item.Children.Any()) AddChildren(item, ref items);
        }
    }

    /// <summary>
    ///     Transform to menu.
    /// </summary>
    /// <param name="items">    The items. </param>
    /// <returns>
    ///     A MenuBarItem[].
    /// </returns>
    protected virtual MenuItem[] TransformToMenu(IEnumerable<IWindowMenuItem> items)
    {
        var menu = new List<MenuItem>();

        foreach (var item in items)
        {
            var menuItem = item.Children.Any()
                ? new MenuBarItem
                {
                    Title = item.Title,
                    Shortcut = item.Shortcut,
                    Action = item.Execute,
                    CanExecute = item.CanExecute
                }
                : new MenuItem
                {
                    Title = item.Title,
                    Shortcut = item.Shortcut,
                    Action = item.Execute,
                    CanExecute = item.CanExecute
                };

            if (item.Children.Any())
                if (menuItem is MenuBarItem parentItem)
                    parentItem.Children = TransformToMenu(item.Children);

            menu.Add(menuItem);
        }

        return menu.ToArray();
    }

    /// <summary>
    ///     Throw on missing children.
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">
    ///     Thrown when the index is outside the required
    ///     range.
    /// </exception>
    /// <param name="currentItems"> The current items. </param>
    /// <param name="menu">         The menu. </param>
    protected virtual void ThrowOnMissingChildren(IList<IWindowMenuItem> currentItems, List<IWindowMenuItem> menu)
    {
        var mParents =
            (from item in currentItems
                let menuItem = menu.SingleOrDefault(m => m.Title == item.Title)
                where menuItem == null
                select item).ToList();

        if (mParents.Count <= 0) return;
        var message = new StringBuilder();
        message.AppendLine($"There's {mParents.Count} conole-items claiming to have a parent that doesn't exist.");
        foreach (var mParent in mParents)
            message.AppendLine(
                $"- {mParent.Title} -> Parent: {mParent.ParentTitle}, Before: {mParent.BeforeTitle}, After: {mParent.AfterTitle}");

        throw new IndexOutOfRangeException(message.ToString());
    }

    /// <summary>
    ///     Throw on missing neighbor.
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">
    ///     Thrown when the index is outside the required
    ///     range.
    /// </exception>
    /// <param name="items">    The items. </param>
    protected virtual void ThrowOnMissingNeighbor(IList<IWindowMenuItem> items)
    {
        if (!items.Any()) return;
        var message = new StringBuilder();
        message.AppendLine($"There's {items.Count} conole-items that could not be sorted into the menu.");
        foreach (var item in items)
            message.AppendLine(
                $"- {item.Title} -> Parent: {item.ParentTitle}, Before: {item.BeforeTitle}, After: {item.AfterTitle}");
        throw new IndexOutOfRangeException(message.ToString());
    }
}