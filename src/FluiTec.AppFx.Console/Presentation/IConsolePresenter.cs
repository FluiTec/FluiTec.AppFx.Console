using System.Collections.Generic;
using FluiTec.AppFx.Console.ConsoleItems;

namespace FluiTec.AppFx.Console.Presentation
{
    /// <summary>   Interface for console presenter. </summary>
    public interface IConsolePresenter
    {
        /// <summary>   Gets the activated items. </summary>
        /// <value> The activated items. </value>
        List<IConsoleItem> ActivatedItems { get; }

        /// <summary>
        /// Gets the style.
        /// </summary>
        ///
        /// <value>
        /// The style.
        /// </value>
        ConsoleStyle Style { get; }

        /// <summary>   Gets the default page size. </summary>
        /// <value> The default page size. </value>
        int DefaultPageSize { get; }

        /// <summary>   Default text. </summary>
        /// <param name="text"> The text. </param>
        /// <returns>   A string. </returns>
        string DefaultText(string text);

        /// <summary>   Highlight text. </summary>
        /// <param name="text"> The text. </param>
        /// <returns>   A string. </returns>
        string HighlightText(string text);

        /// <summary>
        /// Error text.
        /// </summary>
        ///
        /// <param name="text"> The text. </param>
        ///
        /// <returns>
        /// A string.
        /// </returns>
        string ErrorText(string text);

        /// <summary>   Default list entry converter. </summary>
        /// <param name="arg">  The argument. </param>
        /// <returns>   A string. </returns>
        string DefaultListEntryConverter(IConsoleItem arg);

        /// <summary>   Present header. </summary>
        /// <param name="header">   The header. </param>
        void PresentHeader(string header);
    }
}