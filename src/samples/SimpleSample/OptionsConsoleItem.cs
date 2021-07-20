using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.ConsoleItems;
using Spectre.Console;

namespace SimpleSample
{
    /// <summary>   The options console item. </summary>
    public class OptionsConsoleItem : SelectConsoleItem
    {
        /// <summary>   Gets the module. </summary>
        /// <value> The module. </value>
        public OptionsConsoleModule Module { get; }

        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        public string Key { get; set; }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; set; }

        /// <summary>   Constructor. </summary>
        /// <param name="module">   The module. </param>
        /// <param name="item">     The item. </param>
        public OptionsConsoleItem(OptionsConsoleModule module, KeyValuePair<string, string> item) : base(item.Key.Contains(':') ? item.Key.Substring(item.Key.LastIndexOf(':')+1) : item.Key)
        {
            Module = module;
            Key = item.Key;
            Value = item.Value;
        }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public override void Display(IConsoleItem parent)
        {
            base.Display(parent);

            // if item contains elements - SelectConsoleItem (parent) already did it's thing
            if (Items.Any()) return;

            // if item doesnt contain element - let the user edit the value and after doing so - return control
            Presenter.PresentHeader($"Edit {{{Name}}} - current value:");
            AnsiConsole.WriteLine(Value);
            AnsiConsole.Render(new Rule().RuleStyle(Presenter.Style.DefaultTextStyle).LeftAligned());
            Value = AnsiConsole.Ask<string>($"Please enter a {Presenter.HighlightText("new value")}:{Environment.NewLine}");
            AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new value")} is \"{Value}\"");
            Module.EditSetting(Key, Value);
            AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new value")} was saved");

            Parent.Display(null);
        }
    }
}