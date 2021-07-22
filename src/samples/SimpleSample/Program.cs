using FluiTec.AppFx.Console.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SimpleSample
{
    /// <summary>   A program. </summary>
    public class Program
    {
        /// <summary>   Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (!host.RunConsole(typeof(Program), args))
                host.Run();
        }

        /// <summary>   Creates host builder. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        /// <returns>   The new host builder. </returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}