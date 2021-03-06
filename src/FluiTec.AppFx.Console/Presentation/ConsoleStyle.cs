using Spectre.Console;

namespace FluiTec.AppFx.Console.Presentation
{
    /// <summary>   A console style. </summary>
    public class ConsoleStyle
    {
        /// <summary>   Gets or sets the default text style. </summary>
        /// <value> The default text style. </value>
        public Style DefaultTextStyle { get; set; } = "grey";

        /// <summary>   Gets or sets the highlight text style. </summary>
        /// <value> The highlight text style. </value>
        public Style HighlightTextStyle { get; set; } = "gold3";

        /// <summary>   Gets or sets the error text style. </summary>
        /// <value> The error text style. </value>
        public Style ErrorTextStyle { get; set; } = "red";

        /// <summary>   Gets or sets the select highlight text style. </summary>
        /// <value> The select highlight text style. </value>
        public Style SelectHighlightTextStyle { get; set; } = "darkgoldenrod";
    }
}