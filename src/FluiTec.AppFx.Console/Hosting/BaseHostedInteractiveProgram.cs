using System.Collections.Generic;
using FluiTec.AppFx.Console.Modularization;
using FluiTec.AppFx.Console.Modularization.InteractiveItems.DefaultItems;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Console.Hosting
{
    /// <summary>   A base hosted interactive program. </summary>
    public abstract class BaseHostedInteractiveProgram : BaseHostedProgram
    {
        /// <summary>   Gets the name. </summary>
        /// <value> The name. </value>
        public abstract string Name { get; }

        /// <summary>   Gets the menus. </summary>
        /// <value> The menus. </value>
        public IEnumerable<IConsoleMenu> Menus { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="logger">   The logger. </param>
        /// <param name="lifetime"> The lifetime. </param>
        /// <param name="menus">    The menus. </param>
        protected BaseHostedInteractiveProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime, IEnumerable<IConsoleMenu> menus) 
            : base(logger, lifetime)
        {
            Menus = menus;
        }

        /// <summary>   Runs the given arguments. </summary>
        /// <param name="args"> The arguments. </param>
        public override void Run(string[] args)
        {
            var app = new InteractiveConsoleApplication(Name, Menus);
            app.Run();
        }
    }
}