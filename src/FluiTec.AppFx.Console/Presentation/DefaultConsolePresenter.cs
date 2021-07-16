﻿using System.Collections.Generic;
using FluiTec.AppFx.Console.ConsoleItems;
using Spectre.Console;

namespace FluiTec.AppFx.Console.Presentation
{
    /// <summary>   A presenter for default consoles information. </summary>
    public class DefaultConsolePresenter : IConsolePresenter
    {
        /// <summary>   Gets the activated items. </summary>
        /// <value> The activated items. </value>
        public List<IConsoleItem> ActivatedItems { get; }

        public ConsoleStyle Style { get; }

        /// <summary>   Gets the default page size. </summary>
        /// <value> The default page size. </value>
        public int DefaultPageSize { get; } = 10;

        public DefaultConsolePresenter()
        {
            Style = new ConsoleStyle
            {
                DefaultTextStyle = "grey",
                HighlightTextStyle = "gold3",
                SelectHighlightTextStyle = "darkgoldenrod"
            };
            ActivatedItems = new List<IConsoleItem>();
        }

        public string DefaultText(string text) => $"[{Style.DefaultTextStyle.Foreground.ToMarkup()}][/]";

        /// <summary>   Highlight text. </summary>
        /// <param name="text"> The text. </param>
        /// <returns>   A string. </returns>
        public string HighlightText(string text) => $"[{Style.HighlightTextStyle.Foreground.ToMarkup()}]{text}[/]";

        /// <summary>   Default list entry converter. </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>   A string. </returns>
        public string DefaultListEntryConverter(IConsoleItem arg) => arg.DisplayName;

        /// <summary>   Present header. </summary>
        /// <param name="header">   The header. </param>
        public void PresentHeader(string header)
        {
            AnsiConsole.Render(new Rule($"[{Style.HighlightTextStyle.Foreground.ToMarkup()}]{header}[/]").RuleStyle(Style.DefaultTextStyle).LeftAligned());
        }
    }
}