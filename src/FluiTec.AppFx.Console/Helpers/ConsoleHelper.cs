using System;
using System.Linq;

namespace FluiTec.AppFx.Console.Helpers
{
    /// <summary>   A console helper. </summary>
    public static class ConsoleHelper
    {
        /// <summary>   Gets or sets the console required character. </summary>
        /// <value> The console required character. </value>
        public static char ConsoleRequiredChar { get; set; } = 'c';

        /// <summary>   Gets or sets the interactive console character. </summary>
        /// <value> The interactive console character. </value>
        public static char InteractiveConsoleChar { get; set; } = 'i';

        /// <summary>   Console required. </summary>
        /// <param name="interactive">  [out] True to interactive. </param>
        /// <param name="args">         The arguments. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public static bool ConsoleRequired(out bool interactive, string[] args)
        {
            if (args.Any() && args.Contains($"-{ConsoleRequiredChar}"))
            {
                interactive = args.Contains($"-{InteractiveConsoleChar}");
                return true;
            }

            interactive = false;
            return false;
        }

        /// <summary>   Executes the console operation. </summary>
        /// <param name="run">              The run. </param>
        /// <param name="runInteractive">   The run interactive. </param>
        /// <param name="args">             The arguments. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public static bool RunConsole(Action<string[]> run, Action<string[]> runInteractive, string[] args)
        {
            var required = ConsoleRequired(out var interactive, args);
            if (!required) return false;

            if (interactive)
                runInteractive(args);
            else
                run(args);
            return true;
        }
    }
}