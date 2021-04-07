using FluiTec.AppFx.Console;

namespace SimpleSample
{
    /// <summary>   A program. </summary>
    internal class Program
    {
        /// <summary>   Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        private static void Main(string[] args)
        {
            new InteractiveConsoleHost()
                .RunInteractive();
        }
    }
}
