using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.CommandLine;
using FluiTec.AppFx.Console.Modularization;

namespace FluiTec.AppFx.Console.Hosting
{
    /// <summary>   A base hosted command program. </summary>
    public abstract class BaseHostedCommandProgram : BaseHostedProgram
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public abstract string Name { get; }

        /// <summary>   Gets the commands. </summary>
        /// <value> The commands. </value>
        public IEnumerable<IConsoleCommand> Commands { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="logger">   The logger. </param>
        /// <param name="lifetime"> The lifetime. </param>
        /// <param name="commands"> The commands. </param>
        protected BaseHostedCommandProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime, IEnumerable<IConsoleCommand> commands) 
            : base(logger, lifetime)
        {
            Commands = commands;
        }

        /// <summary>   Runs the given arguments. </summary>
        /// <param name="args"> The arguments. </param>
        public override void Run(string[] args)
        {
            CreateRootCommand().Invoke(args);
        }

        /// <summary>   Creates root command. </summary>
        /// <returns>   The new root command. </returns>
        protected virtual Command CreateRootCommand()
        {
            var rootCmd = new RootCommand(Name);

            foreach(var cmd in Commands)
                rootCmd.Add(cmd.ConfigureCommand());

            return rootCmd;
        }
    }
}