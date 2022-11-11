using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;

namespace FluiTec.AppFx.Console.Hosting
{
    /// <summary>   A base hosted module program. </summary>
    public abstract class BaseHostedModuleProgram : BaseHostedProgram
    {
        /// <summary>   Gets or sets the console required character. </summary>
        /// <value> The console required character. </value>
        public static char ConsoleRequiredChar { get; set; } = 'c';

        /// <summary>   Gets or sets the interactive console character. </summary>
        /// <value> The interactive console character. </value>
        public static char InteractiveConsoleChar { get; set; } = 'i';

        /// <summary>   Gets a value indicating whether we can run without console. </summary>
        /// <value> True if we can run without console, false if not. </value>
        public virtual bool CanRunWithoutConsole => false;

        /// <summary>   Gets a value indicating whether the console character required. </summary>
        /// <value> True if console character required, false if not. </value>
        public virtual bool ConsoleCharRequired => true;
        
        /// <summary>   Gets the commands. </summary>
        /// <value> The commands. </value>
        public IEnumerable<IConsoleCommand> Commands { get; }

        /// <summary>   Gets the menus. </summary>
        /// <value> The menus. </value>
        public IEnumerable<IConsoleMenu> Menus { get; }

        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public abstract string Name { get; }

        /// <summary>   Specialized constructor for use only by derived class. </summary>
        /// <param name="logger">   The logger. </param>
        /// <param name="lifetime"> The lifetime. </param>
        /// <param name="commands"> The commands. </param>
        /// <param name="menus">    The menus. </param>
        protected BaseHostedModuleProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime, IEnumerable<IConsoleCommand> commands, IEnumerable<IConsoleMenu> menus) 
            : base(logger, lifetime)
        {
            Commands = commands;
            Menus = menus;
        }

        /// <summary>   Console required. </summary>
        /// <param name="interactive">  [out] True to interactive. </param>
        /// <param name="args">         The arguments. </param>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        protected bool ConsoleRequired(out bool interactive, string[] args)
        {
            if (args.Any())
            {
                interactive = args.Contains($"-{InteractiveConsoleChar}");
                return !ConsoleCharRequired || (ConsoleCharRequired && args.Contains($"-{ConsoleRequiredChar}"));
            }

            interactive = false;
            return false;
        }

        /// <summary>   Runs the given arguments. </summary>
        /// <param name="args"> The arguments. </param>
        public override void Run(string[] args)
        {
            var required = ConsoleRequired(out var interactive, args);
            if (required)
            {
                if (!interactive)
                {
                    CreateRootCommand().Invoke(args);
                }
                else
                {
                    new InteractiveConsoleApplication(Name, Menus).Run();
                }
            }
            else if (CanRunWithoutConsole)
            {
                RunWithoutConsole(args);
            }
            else
            {
                CreateRootCommand().Invoke(args);
            }
        }

        /// <summary>   Creates root command. </summary>
        /// <returns>   The new root command. </returns>
        protected virtual Command CreateRootCommand()
        {
            var rootCmd = new RootCommand(Name);

            foreach (var cmd in Commands)
                rootCmd.Add(cmd.ConfigureCommand());

            return rootCmd;
        }

        /// <summary>   Executes the 'without console' operation. </summary>
        /// <param name="args"> The arguments. </param>
        public virtual void RunWithoutConsole(string[] args) {}
    }
}