using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.Controls;
using FluiTec.AppFx.Console.Items;

namespace FluiTec.AppFx.Console.Services
{
    /// <summary>   A presenter for default consoles information. </summary>
    public class DefaultConsolePresenter : IInteractiveConsolePresenter
    {
        #region Properties

        /// <summary>   Gets or sets the default foreground color. </summary>
        /// <value> The default foreground color. </value>
        public ConsoleColor DefaultForegroundColor { get; set; }

        /// <summary>   Gets or sets the color of the highlight foreground. </summary>
        /// <value> The color of the highlight foreground. </value>
        public ConsoleColor HighlightForegroundColor { get; set;}

        /// <summary>   Gets or sets the default background color. </summary>
        /// <value> The default background color. </value>
        public ConsoleColor DefaultBackgroundColor { get; set;}

        /// <summary>   Gets or sets the color of the highlight background. </summary>
        /// <value> The color of the highlight background. </value>
        public ConsoleColor HighlightBackgroundColor { get; set; }

        /// <summary>   Gets or sets the separator character. </summary>
        /// <value> The separator character. </value>
        public char SeparatorChar { get; set; }

        /// <summary>   Gets the name of the application. </summary>
        /// <value> The name of the application. </value>
        public string ApplicationName { get; }

        #endregion

        #region Constructors

        /// <summary>   Default constructor. </summary>
        public DefaultConsolePresenter(string applicationName)
        {
            if (string.IsNullOrWhiteSpace(applicationName))
                throw new ArgumentNullException(nameof(applicationName));
            ApplicationName = applicationName;

            DefaultForegroundColor = ConsoleColor.White;
            DefaultBackgroundColor = ConsoleColor.Black;

            HighlightForegroundColor = ConsoleColor.DarkCyan;
            HighlightBackgroundColor = ConsoleColor.Black;

            SeparatorChar = '#';
        }

        #endregion

        #region Methods

        #region IInteractiveConsolePresenter

        /// <summary>   Prints the welcome message. </summary>
        public void Welcome()
        {
            System.Console.Clear();

            WriteLine(new string(SeparatorChar, System.Console.WindowWidth));
            Write("Interactive console for ");
            Write($"'{ApplicationName}'\n", true);
        }

        /// <summary>   Prints the help message. </summary>
        public void Help()
        {
            WriteLine(new string(SeparatorChar, System.Console.WindowWidth));
            WriteLine("Press <UP> to move selection up.");
            WriteLine("Press <DOWN> to move selection down.");
            WriteLine("Press <ENTER> to pick/execute the currently selected item.");
        }

        /// <summary>   Presents the given console-items. </summary>
        /// <param name="items">    The console-items. </param>
        public void Present(IEnumerable<IInteractiveConsoleItem> items)
        {
            var interactiveConsoleItems = items.ToList();

            if (!interactiveConsoleItems.Any())
                PresentEmpty();
            else
                Pick(interactiveConsoleItems);
        }

        /// <summary>   Picks the given items. </summary>
        /// <param name="items">    The console-items. </param>
        public void Pick(IEnumerable<IInteractiveConsoleItem> items)
        {
            WriteLine(new string(SeparatorChar, System.Console.WindowWidth));

            var interactiveConsoleItems = items.ToList();

            var first = interactiveConsoleItems.First();
            if (first.HasParent)
            {
                interactiveConsoleItems.Add(first.Parent.HasParent
                    ? new BackInteractiveConsoleItem(first.Parent.Parent.Children) {Parent = first.Parent}
                    : new BackInteractiveConsoleItem(first.Host.ConsoleModules) {Parent = first.Parent});
            }
            interactiveConsoleItems.Add(new ExitInteractiveConsoleItem {Parent = first.Parent});

            var menu = new SelectMenu<IInteractiveConsoleItem>
            {
                DefaultItemColor = DefaultForegroundColor,
                SelectedItemColor = HighlightForegroundColor
            };
            
            menu.Items.AddRange(interactiveConsoleItems.Select(i => new SelectMenuItem<IInteractiveConsoleItem>(i, i.Name, i.Description)));
                
            var selected = menu.SelectItem().Item;
            selected.OnPicked();
        }
        
        /// <summary>   Present empty. </summary>
        protected virtual void PresentEmpty()
        {
            WriteLine("No items to pick/execute. Press <Enter> to exit.");
            System.Console.ReadLine();
        }

        #endregion

        #region Console

        /// <summary>   Writes. </summary>
        /// <param name="text">         The text to write. </param>
        /// <param name="highlighted">  (Optional) True if highlighted. </param>
        protected virtual void Write(string text, bool highlighted = false)
        {
            System.Console.ForegroundColor = highlighted ? HighlightForegroundColor : DefaultForegroundColor;
            System.Console.BackgroundColor = highlighted ? HighlightBackgroundColor : DefaultBackgroundColor;

            System.Console.Write(text);

            System.Console.ResetColor();
        }

        /// <summary>   Writes a line. </summary>
        /// <param name="text">         The text to write. </param>
        /// <param name="highlighted">  (Optional) True if highlighted. </param>
        protected virtual void WriteLine(string text, bool highlighted = false)
        {
            System.Console.ForegroundColor = highlighted ? HighlightForegroundColor : DefaultForegroundColor;
            System.Console.BackgroundColor = highlighted ? HighlightBackgroundColor : DefaultBackgroundColor;

            System.Console.WriteLine(text);

            System.Console.ResetColor();
        }

        #endregion

        #endregion
    }
}