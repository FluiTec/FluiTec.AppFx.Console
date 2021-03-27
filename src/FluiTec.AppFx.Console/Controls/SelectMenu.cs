using System;
using System.Collections.Generic;

namespace FluiTec.AppFx.Console.Controls
{
    /// <summary>   A select menu.</summary>
    public class SelectMenu<T>
    {
        /// <summary>   Gets the items.</summary>
        /// <value> The items.</value>
        public List<SelectMenuItem<T>> Items { get; }

        /// <summary>   Default constructor.</summary>
        public SelectMenu()
        {
            Items = new List<SelectMenuItem<T>>();
            DefaultItemColor = ConsoleColor.White;
            SelectedItemColor = ConsoleColor.Cyan;
        }

        /// <summary>   Gets or sets the default item color.</summary>
        /// <value> The default item color.</value>
        public ConsoleColor DefaultItemColor { get; set; }

        /// <summary>   Gets or sets the selected item color.</summary>
        /// <value> The color of the selected item.</value>
        public ConsoleColor SelectedItemColor { get; set; }

        /// <summary>   Select item.</summary>
        /// <returns>   A SelectMenuItem&lt;T&gt;</returns>
        public SelectMenuItem<T> SelectItem(string selectTitle = "Please select any of the following options:")
        {
            var countLength = Items.Count.ToString().Length;
            var selected = 0;
            var done = false;
            
            while (!done)
            {
                //System.Console.Clear();
                System.Console.WriteLine(selectTitle);
                System.Console.WriteLine("_______________________________________");
                System.Console.WriteLine();
                for (var i = 0; i < Items.Count; i++)
                {
                    if (selected == i)
                    {
                        System.Console.ForegroundColor = SelectedItemColor;
                        System.Console.Write(">");
                        System.Console.Write(new string(' ', countLength));
                    }
                    else
                    {
                        System.Console.ForegroundColor = DefaultItemColor;
                        System.Console.Write(new string(' ', countLength+1));
                    }

                    System.Console.WriteLine($"{i+1}.) {Items[i].Name} ({Items[i].Description})");
                    System.Console.ResetColor();
                }
                System.Console.WriteLine("_______________________________________");

                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(Items.Count - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }
                
                if (!done)
                    System.Console.CursorTop -= Items.Count + 4;
            }

            return Items[selected];
        }
    }
}