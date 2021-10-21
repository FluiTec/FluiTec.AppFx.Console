using System.Collections.Generic;
using FluiTec.AppFx.Console.ConsoleItems;
using Spectre.Console;

namespace FluiTec.AppFx.Console.Presentation
{
    /// <summary>   A presenter for default consoles information. </summary>
    public class DefaultConsolePresenter : IConsolePresenter
    {
        public DefaultConsolePresenter()
        {
            Style = new ConsoleStyle
            {
                DefaultTextStyle = "grey",
                HighlightTextStyle = "gold3",
                SelectHighlightTextStyle = "darkgoldenrod",
                ErrorTextStyle = "red"
            };
            ActivatedItems = new List<IConsoleItem>();
        }

        /// <summary>   Gets the activated items. </summary>
        /// <value> The activated items. </value>
        public List<IConsoleItem> ActivatedItems { get; }

        public ConsoleStyle Style { get; }

        /// <summary>   Gets the default page size. </summary>
        /// <value> The default page size. </value>
        public int DefaultPageSize => 10;

        /// <summary>
        /// Default text.
        /// </summary>
        ///
        /// <param name="text"> The text. </param>
        ///
        /// <returns>
        /// A string.
        /// </returns>
        public string DefaultText(string text)
        {
            return $"[{Style.DefaultTextStyle.Foreground.ToMarkup()}][/]";
        }

        /// <summary>   Highlight text. </summary>
        /// <param name="text"> The text. </param>
        /// <returns>   A string. </returns>
        public string HighlightText(string text)
        {
            return $"[{Style.HighlightTextStyle.Foreground.ToMarkup()}]{text}[/]";
        }

        /// <summary>
        /// Error text.
        /// </summary>
        ///
        /// <param name="text"> The text. </param>
        ///
        /// <returns>
        /// A string.
        /// </returns>
        public string ErrorText(string text)
        {
            return $"[{Style.ErrorTextStyle.Foreground.ToMarkup()}]{text}[/]";
        }

        /// <summary>   Default list entry converter. </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>   A string. </returns>
        public string DefaultListEntryConverter(IConsoleItem arg)
        {
            return arg.DisplayName;
        }

        /// <summary>   Present header. </summary>
        /// <param name="header">   The header. </param>
        public void PresentHeader(string header)
        {
            AnsiConsole.Write(new Rule($"[{Style.HighlightTextStyle.Foreground.ToMarkup()}]{header}[/]")
                .RuleStyle(Style.DefaultTextStyle).LeftAligned());
        }
    }
}