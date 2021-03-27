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
    }
}