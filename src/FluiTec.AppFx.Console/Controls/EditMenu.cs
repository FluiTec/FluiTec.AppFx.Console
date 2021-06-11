using System;
using System.Runtime.InteropServices;

namespace FluiTec.AppFx.Console.Controls
{
    /// <summary>   An edit menu. </summary>
    public class EditMenu
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public string Name { get; }

        /// <summary>   Gets the original value. </summary>
        /// <value> The original value. </value>
        public string OriginalValue { get; }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; private set; }

        /// <summary>   Gets or sets the default text color. </summary>
        /// <value> The default text color. </value>
        public ConsoleColor DefaultTextColor { get; set; }

        /// <summary>   Gets or sets the color of the highlight text. </summary>
        /// <value> The color of the highlight text. </value>
        public ConsoleColor HighlightTextColor { get; set; }

        /// <summary>   Constructor. </summary>
        /// <param name="name">             The name. </param>
        /// <param name="originalValue">    The original value. </param>
        public EditMenu(string name, string originalValue)
        {
            Name = name;
            OriginalValue = originalValue;
            Value = OriginalValue;

            DefaultTextColor = ConsoleColor.White;
            HighlightTextColor = ConsoleColor.Cyan;
        }
        
        /// <summary>   Edit value. </summary>
        /// <returns>   A string. </returns>
        public string EditValue()
        {
            var done = false;

            System.Console.ForegroundColor = DefaultTextColor;
            System.Console.Write($"Edit value of '{Name}:' ");
            var nullPos = System.Console.CursorLeft;

            System.Console.ForegroundColor = HighlightTextColor;
            System.Console.Write($"{Value}");

            while (!done)
            {
                var info = System.Console.ReadKey(true);
                ConsoleKeyInfo keyInfo;

                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (System.Console.CursorLeft > nullPos)
                            System.Console.CursorLeft--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (nullPos + Value.Length > System.Console.CursorLeft)
                            System.Console.CursorLeft++;
                        break;
                    case ConsoleKey.Backspace:
                        if (System.Console.CursorLeft > nullPos)
                        {

                            System.Console.CursorLeft--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                    default:
                        System.Console.Write(info.KeyChar);
                        break;
                }
            }

            return OriginalValue;
        }
    }
}
