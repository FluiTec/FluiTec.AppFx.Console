using System;
using Microsoft.Extensions.Configuration;

namespace FluiTec.AppFx.Console.Programs.EventsArguments
{
    /// <summary>
    /// Additional information for configuration created events.
    /// </summary>
    public class ConfigurationCreatedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the configuration root.
        /// </summary>
        ///
        /// <value>
        /// The configuration root.
        /// </value>
        public IConfigurationRoot ConfigurationRoot { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="configurationRoot">    The configuration root. </param>
        public ConfigurationCreatedEventArgs(IConfigurationRoot configurationRoot)
        {
            ConfigurationRoot = configurationRoot;
        }
    }
}