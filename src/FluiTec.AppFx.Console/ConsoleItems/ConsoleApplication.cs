using System;
using System.Collections.Generic;
using Spectre.Console;

namespace FluiTec.AppFx.Console.ConsoleItems
{
    /// <summary>   A console application. </summary>
    public class ConsoleApplication : SelectConsoleItem
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public override string Name { get; protected set; }

        /// <summary>   Gets the console arguments. </summary>
        /// <value> The console arguments. </value>
        public string[] ConsoleArgs { get; }

        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="name"> The name. </param>
        /// <param name="consoleArgs"></param>
        public ConsoleApplication(string name, string[] consoleArgs)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ConsoleArgs = consoleArgs;
        }

        /// <summary>   Executes the console application.  </summary>
        public void Run()
        {
            // TODO: parse arguments and execute
        }

        /// <summary>   Executes the console application interactively. </summary>
        public void RunInteractive()
        {
            Display();
        }

        /// <summary>   Displays this. </summary>
        public override void Display()
        {
            AnsiConsole.Clear();
            base.Display();
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