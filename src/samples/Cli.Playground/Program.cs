using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Cli.Playground;

/// <summary>
///     A program.
/// </summary>
internal class Program
{
    /// <summary>
    ///     Main entry-point for this application.
    /// </summary>
    /// <param name="args"> An array of command-line argument strings. </param>
    private static void Main(string[] args)
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
}

public enum MigrationOption
{
    // ReSharper disable UnusedMember.Global
    Apply,

    Rollback
    // ReSharper restore UnusedMember.Global
}