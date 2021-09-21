using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading;

namespace Cli.Playground
{
    /// <summary>
    /// A program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry-point for this application.
        /// </summary>
        ///
        /// <param name="args"> An array of command-line argument strings. </param>
        private static void Main(string[] args)
        {
            Run();
        }

        static void Cmd(string[] args)
        {
            var cmd = new RootCommand("Configuration of the database.");
            var dataCmd = new Command("--data", "Data");
            var migrateCommand = new Command("--migrate", "Migrate the database.")
            {
                new Argument<string>("service", "Name of the service to migrate."),
                new Argument<long>("migration", "Version of the migration to use."),
                new Argument<MigrationOption>("option", "MigrationOption to use.")
            };
            migrateCommand.Handler = CommandHandler.Create<string, long, MigrationOption>((s, m, o) =>
            {
                Console.WriteLine($"{s}-{m}-{o}");
            });

            dataCmd.AddCommand(migrateCommand);
            cmd.AddCommand(dataCmd);
            cmd.Invoke(args);
        }

        private static void Run(char symbol = '@', char exitChar = 'q', int sleepMilliseconds = 150)
        {
            int posX = 5;
            int posY = 20;
            int directionX = 1;
            int directionY = 1;
            bool exit = false;

            while (!exit) // run the loop till exit = true
            {
                // check if a key was pressed
                if (Console.KeyAvailable)
                {
                    // get the next available key
                    var input = Console.ReadKey(true);

                    // if key equals 'q' - exit
                    if (input.KeyChar == exitChar)
                        exit = true;
                }

                // clear current cursor position by writing a blank
                // this removes previously printed symbols
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(' ');
                
                // change position by applying the direction
                posX += directionX;
                posY += directionY;

                // print the selected symbol
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine(symbol);

                // change direction for x if necessary
                if (posX >= 25 || posX <= 0)
                {
                    directionX *= -1;
                }

                // change direction for y if necessary
                if (posY >= 25 || posY <= 0)
                {
                    directionY *= -1;
                }

                // wait a little while
                Thread.Sleep(sleepMilliseconds);
            }
        }
    }

    public class MigrationOptions
    {
        public string ServiceName { get; set; }
        public long MigrationVersion { get; set; }
        public MigrationOption Direction { get; set; }
    }

    public enum MigrationOption
    {
        Apply,
        Rollback
    }
}
