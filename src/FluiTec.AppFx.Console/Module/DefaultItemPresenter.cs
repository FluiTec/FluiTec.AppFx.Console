using System;
using System.Linq;
using FluiTec.AppFx.Console.Controls;
using FluiTec.AppFx.Console.Extensions;

namespace FluiTec.AppFx.Console.Module
{
    /// <summary>   A presenter for default items information. </summary>
    public class DefaultItemPresenter : IItemPresenter
    {
        /// <summary>   Gets or sets the host. </summary>
        /// <value> The host. </value>
        public InteractiveConsoleHost Host { get; protected set; }

        /// <summary>   Gets the default color. </summary>
        /// <value> The default color. </value>
        public ConsoleColor DefaultColor { get; }

        /// <summary>   Gets the color of the title. </summary>
        /// <value> The color of the title. </value>
        public ConsoleColor TitleColor { get; }

        /// <summary>   Gets the separator character. </summary>
        /// <value> The separator character. </value>
        public char SeparatorChar { get; }

        /// <summary>   Default constructor. </summary>
        public DefaultItemPresenter(InteractiveConsoleHost host)
        {
            Host = host;
            DefaultColor = ConsoleColor.White;
            TitleColor = ConsoleColor.Cyan;

            SeparatorChar = '#';
        }

        /// <summary>   Presents the given item. </summary>
        /// <param name="item"> The item. </param>6
        public virtual void Present(IConsoleMenuItem item)
        {
            System.Console.Clear();

            PresentTitle(item);
            PresentChildren(item);
        }

        /// <summary>   Present title. </summary>
        /// <param name="item"> The item. </param>
        protected virtual void PresentTitle(IConsoleMenuItem item)
        {
            ConsoleExtension.WriteLine(new string(SeparatorChar, System.Console.WindowWidth), DefaultColor);
            ConsoleExtension.WriteLineCentered(item.Name, SeparatorChar, TitleColor, DefaultColor);
            ConsoleExtension.WriteLineCentered(item.Description, SeparatorChar, TitleColor, DefaultColor);
            ConsoleExtension.WriteLine(new string(SeparatorChar, System.Console.WindowWidth), DefaultColor);
            if (!string.IsNullOrWhiteSpace(item.HelpText))
            {
                ConsoleExtension.WriteLine(item.HelpText, TitleColor);
                ConsoleExtension.WriteLine(new string(SeparatorChar, System.Console.WindowWidth), DefaultColor);
            }
        }

        /// <summary>   Present children. </summary>
        /// <param name="item"> The item. </param>
        protected virtual void PresentChildren(IConsoleMenuItem item)
        {
            if (!item.HasChildren) return;

            var menu = new SelectMenu<IConsoleMenuItem>();
            menu.Items.AddRange(item.Children.Select(i => new SelectMenuItem<IConsoleMenuItem>(i, i.Name, i.Description)));
            Host.ActiveItem = menu.SelectItem().Item;
        }
    }
}