using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console application. </summary>
    public class ConsoleApplication : SelectConsoleItem
    {
        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="name">         The name. </param>
        /// <param name="hostServices"> The host services. </param>
        /// <param name="consoleArgs">  . </param>
        public ConsoleApplication(string name, IServiceProvider hostServices, string[] consoleArgs) : base(name)
        {
            HostServices = hostServices ?? throw new ArgumentNullException(nameof(hostServices));
            ConsoleArgs = consoleArgs ?? throw new ArgumentNullException(nameof(consoleArgs));

            Items.AddRange(hostServices.GetServices<ModuleConsoleItem>());
            foreach (var item in Items)
                ((ModuleConsoleItem) item).Application = this;
        }

        /// <summary>   Gets the host services. </summary>
        /// <value> The host services. </value>
        public IServiceProvider HostServices { get; }

        /// <summary>   Gets the console arguments. </summary>
        /// <value> The console arguments. </value>
        public string[] ConsoleArgs { get; }

        /// <summary>   Executes the console application.  </summary>
        public int Run()
        {
            // TODO: parse arguments and execute
            var modules = Items.Where(i => i is ModuleConsoleItem).Cast<ModuleConsoleItem>();

            var rootCommand = new RootCommand(Name);

            foreach (var module in modules) rootCommand.AddCommand(module.ConfigureCommand());

            return rootCommand.Invoke(ConsoleArgs);
        }

        /// <summary>   Executes the console application interactively. </summary>
        public void RunInteractive()
        {
            Display(this);
        }

        /// <summary>   Displays this. </summary>
        public override void Display(IConsoleItem parent)
        {
            AnsiConsole.Clear();
            base.Display(parent);
        }

        /// <summary>   Enumerates create default items in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process create default items in this
        ///     collection.
        /// </returns>
        protected override IEnumerable<IConsoleItem> CreateDefaultItems()
        {
            return new IConsoleItem[] {new ExitConsoleItem()};
        }
    }
}