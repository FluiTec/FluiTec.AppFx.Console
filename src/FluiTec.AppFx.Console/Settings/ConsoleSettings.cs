using FluentValidation;
using FluiTec.AppFx.Options.Attributes;

namespace FluiTec.AppFx.Console.Settings
{
    /// <summary>   A console settings. </summary>
    [ConfigurationKey("ConsoleSettings")]
    public class ConsoleSettings
    {
        /// <summary>   Gets or sets the test. </summary>
        /// <value> The test. </value>
        public string Test { get; set; }
    }

    /// <summary>   A console settings validator. </summary>
    public class ConsoleSettingsValidator : AbstractValidator<ConsoleSettings>
    {

    }
}