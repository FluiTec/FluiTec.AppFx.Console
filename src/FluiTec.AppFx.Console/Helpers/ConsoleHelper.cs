using System;
using System.Linq;
using Microsoft.Extensions.Hosting;

namespace FluiTec.AppFx.Console.Helpers
{
    /// <summary>   A console helper. </summary>
    // ReSharper disable once UnusedMember.Global
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

        /// <summary>   Executes the console operation. </summary>
        /// <param name="host">             The host to act on. </param>
        /// <param name="applicationName">  Name of the application. </param>
        /// <param name="args">             The arguments. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        public static bool RunConsole(this IHost host, string applicationName, string[] args)
        {
            var run = new Action<string[]>(a => ConsoleHost.FromHost(host).Run(applicationName, a));
            var iRun = new Action<string[]>(a => ConsoleHost.FromHost(host).RunInteractive(applicationName, a));
            return RunConsole(run, iRun, args);
        }

        /// <summary>   Executes the console operation. </summary>
        /// <param name="host">             The host to act on. </param>
        /// <param name="applicationType">  Type of the application. </param>
        /// <param name="args">             The arguments. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        // ReSharper disable once UnusedMember.Global
        public static bool RunConsole(this IHost host, Type applicationType, string[] args)
        {
            return host.RunConsole(applicationType.Assembly.GetName().Name, args);
        }
    }
}