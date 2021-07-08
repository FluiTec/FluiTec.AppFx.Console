using FluiTec.AppFx.Console.ConsoleItems;
using Spectre.Console;

namespace SimpleSample
{
    /// <summary>   The options console module. </summary>
    public class OptionsConsoleModule : ModuleConsoleItem
    {
        /// <summary>   Default constructor. </summary>
        public OptionsConsoleModule() : base("Options")
        {
            Items.Add(new TestConsoleItem("Test 1"));
            Items.Add(new TestConsoleItem("Test 2"));
            Items.Add(new Test2ConsoleItem("Test 3"));
        }
    }

    public class TestConsoleItem : ConsoleItem
    {
        public TestConsoleItem(string name) : base(name) {}

        public override void Display()
        {
            AnsiConsole.Write("Test");
        }
    }

    public class Test2ConsoleItem : SelectConsoleItem
    {
        public Test2ConsoleItem(string name) : base(name)
        {
            Items.Add(new TestConsoleItem("Test 1"));
            Items.Add(new TestConsoleItem("Test 2"));
        }
    }
}