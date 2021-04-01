using System;

namespace FluiTec.AppFx.Console.Extensions
{
    /// <summary>   A console extension.</summary>
    public static class ConsoleExtension
    {
        /// <summary>   Clears the current console line.</summary>
        public static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = System.Console.CursorTop;
            System.Console.SetCursorPosition(0, System.Console.CursorTop);
            System.Console.Write(new string(' ', System.Console.WindowWidth));
            System.Console.SetCursorPosition(0, currentLineCursor);
        }

        /// <summary>   Writes. </summary>
        /// <param name="content">  The content. </param>
        /// <param name="color">    The color. </param>
        public static void Write(string content, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.Write(content);
            System.Console.ResetColor();
        }

        /// <summary>   Writes a line. </summary>
        /// <param name="content">  The content. </param>
        /// <param name="color">    The color. </param>
        public static void WriteLine(string content, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(content);
            System.Console.ResetColor();
        }

        /// <summary>   Writes a line centered. </summary>
        /// <param name="centerContent">    The center content. </param>
        /// <param name="fillCharacter">    The fill character. </param>
        /// <param name="centerColor">      The center color. </param>
        /// <param name="fillColor">        The fill color. </param>
        public static void WriteLineCentered(string centerContent, char fillCharacter, ConsoleColor centerColor,
            ConsoleColor fillColor)
        {
            var fillLength = System.Console.WindowWidth - centerContent.Length - 2; // 2 as spacer around content
            Write(new string(fillCharacter, fillLength/2), fillColor);
            Write($" {centerContent} ", centerColor);
            Write(new string(fillCharacter, fillLength/2), fillColor);
            System.Console.WriteLine();
        }
    }
}