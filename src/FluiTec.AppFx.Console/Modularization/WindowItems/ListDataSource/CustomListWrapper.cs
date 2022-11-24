using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using NStack;
using Terminal.Gui;

namespace FluiTec.AppFx.Console.Modularization.WindowItems.ListDataSource;

/// <summary>
///     A custom list wrapper.
/// </summary>
/// <typeparam name="T">    Generic type parameter. </typeparam>
public class CustomListWrapper<T> : IListDataSource
{
    private readonly int _count;
    private readonly BitArray _marks;
    protected readonly IList<T> Src;

    /// <summary>
    ///     Initializes a new instance of <see cref="ListWrapper" /> given an <see cref="IList" />
    /// </summary>
    /// <param name="source"></param>
    public CustomListWrapper(IList<T> source)
    {
        if (source == null) return;
        _count = source.Count;
        _marks = new BitArray(_count);
        Src = source;
        Length = GetMaxLengthItem();
    }

    /// <summary>
    ///     Gets the number of items in the <see cref="IList" />.
    /// </summary>
    public int Count => Src?.Count ?? 0;

    /// <summary>
    ///     Gets the maximum item length in the <see cref="IList" />.
    /// </summary>
    public int Length { get; }

    /// <summary>
    ///     Renders a <see cref="ListView" /> item to the appropriate type.
    /// </summary>
    /// <param name="container">The ListView.</param>
    /// <param name="driver">The driver used by the caller.</param>
    /// <param name="marked">Informs if it's marked or not.</param>
    /// <param name="item">The item.</param>
    /// <param name="col">The col where to move.</param>
    /// <param name="line">The line where to move.</param>
    /// <param name="width">The item width.</param>
    /// <param name="start">The index of the string to be displayed.</param>
    public virtual void Render(ListView container, ConsoleDriver driver, bool marked, int item, int col, int line,
        int width, int start = 0)
    {
        container.Move(col, line);
        var t = Src[item];
        switch (t)
        {
            case null:
                RenderUstr(driver, ustring.Make(""), col, line, width);
                break;
            case ustring u:
                RenderUstr(driver, u, col, line, width, start);
                break;
            case string s:
                RenderUstr(driver, s, col, line, width, start);
                break;
            default:
                RenderUstr(driver, t.ToString(), col, line, width, start);
                break;
        }
    }

    /// <summary>
    ///     Returns true if the item is marked, false otherwise.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns><c>true</c>If is marked.<c>false</c>otherwise.</returns>
    public bool IsMarked(int item)
    {
        if (item >= 0 && item < _count)
            return _marks[item];
        return false;
    }

    /// <summary>
    ///     Sets the item as marked or unmarked based on the value is true or false, respectively.
    /// </summary>
    /// <param name="item">The item</param>
    /// <param name="value"><true>Marks the item.</true><false>Unmarked the item.</false>The value.</param>
    public void SetMark(int item, bool value)
    {
        if (item >= 0 && item < _count)
            _marks[item] = value;
    }

    /// <summary>
    ///     Returns the source as IList.
    /// </summary>
    /// <returns></returns>
    public IList ToList()
    {
        return (IList)Src;
    }

    private int GetMaxLengthItem()
    {
        if (Src == null || Src?.Count == 0) return 0;

        var maxLength = 0;
        Debug.Assert(Src != null, nameof(Src) + " != null");
        foreach (var t in Src)
        {
            var l = t switch
            {
                ustring u => u.RuneCount,
                string s => s.Length,
                _ => t.ToString().Length
            };

            if (l > maxLength) maxLength = l;
        }

        return maxLength;
    }

    protected static void RenderUstr(ConsoleDriver driver, ustring ustr, int col, int line, int width, int start = 0)
    {
        var byteLen = ustr.Length;
        var used = 0;
        for (var i = start; i < byteLen;)
        {
            var (rune, size) = Utf8.DecodeRune(ustr, i, i - byteLen);
            var count = Rune.ColumnWidth(rune);
            if (used + count > width)
                break;
            driver.AddRune(rune);
            used += count;
            i += size;
        }

        for (; used < width; used++) driver.AddRune(' ');
    }
}