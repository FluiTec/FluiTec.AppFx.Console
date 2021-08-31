using System.CommandLine;
using System.CommandLine.Invocation;
using FluiTec.AppFx.Console.ConsoleItems;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console.Samples.SimpleSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConsoleHost.ConfigureModule(services, provider => new TestModule());
            var provider = services.BuildServiceProvider();
            
            new ConsoleHost(provider).Run("Test-App", args);
        }
    }

    /// <summary>
    /// A test module.
    /// </summary>
    public class TestModule : ModuleConsoleItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public TestModule() : base("Test")
        {
        }

        /// <summary>
        /// Initializes this.
        /// </summary>
        protected override void Initialize() {}

        /// <summary>
        /// Configure command.
        /// </summary>
        ///
        /// <returns>
        /// A System.CommandLine.Command.
        /// </returns>
        public override Command ConfigureCommand()
        {
            var cmd = new Command("--test", "Test-Module");

            var updateCmd = new Command("--edit", "Edit a configuration-entry.");
            updateCmd.AddOption(new Option<string>("--key", "Key of the configuration-entry.") {IsRequired = true});
            updateCmd.AddOption(new Option<string>("--value", "Value of the the configuration-entry.") {IsRequired = false});
            updateCmd.Handler = CommandHandler.Create<string, string>(ProcessEdit);
            cmd.AddCommand(updateCmd);
            return cmd;
        }

        private void ProcessEdit(string key, string val)
        {
            System.Console.WriteLine($">> {key}:{val}");
        }
    }
}
