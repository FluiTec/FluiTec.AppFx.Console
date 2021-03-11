using System;
using FluentValidation;
using FluiTec.AppFx.Options.Attributes;

namespace FluiTec.AppFx.Console.Settings
{
    /// <summary>   A console settings. </summary>
    [ConfigurationKey("ConsoleSettings")]
    public class ConsoleSettings
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this  use application context base directory.
        /// </summary>
        /// <value> True if use application context base directory, false if not. </value>
        public bool UseAppContextBaseDirectory { get; set; }

        /// <summary>   Gets or sets the pathname of the base directory. </summary>
        /// <value> The pathname of the base directory. </value>
        public string BaseDirectory { get; set; }

        /// <summary>   Gets or sets the plugin subdirectory. </summary>
        /// <value> The plugin subdirectory. </value>
        public string PluginSubdirectory { get; set; } = "plugins";

        /// <summary>   Gets the pathname of the plugin directory. </summary>
        /// <value> The pathname of the plugin directory. </value>
        public string PluginDirectory => UseAppContextBaseDirectory
            ? System.IO.Path.Combine(AppContext.BaseDirectory, PluginSubdirectory)
            : System.IO.Path.Combine(BaseDirectory, PluginSubdirectory);
    }

    /// <summary>   A console settings validator. </summary>
    public class ConsoleSettingsValidator : AbstractValidator<ConsoleSettings>
    {
        /// <summary>   Default constructor. </summary>
        public ConsoleSettingsValidator()
        {
            RuleFor(setting => setting.PluginSubdirectory).NotEmpty();
            RuleFor(setting => setting.PluginDirectory).NotEmpty()
                .Must(System.IO.Directory.Exists).WithMessage("PluginDirectory does not exist - but is required.");
        }
    }
}