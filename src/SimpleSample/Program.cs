using System;

namespace SimpleSample
{
    /// <summary>   A program. </summary>
    class Program
    {
        /// <summary>   Main entry-point for this application. </summary>
        /// <param name="args"> An array of command-line argument strings. </param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var arg in args)
                Console.WriteLine($"- {arg}");
        }
    }
}
