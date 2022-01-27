using System;
using Microsoft.Extensions.Configuration;

namespace FluiTec.AppFx.Console.Programs.EventsArguments
{
    /// <summary>
    ///     Additional information for configuration builder created events.
    /// </summary>
    public class ConfigurationBuilderCreatedEventArgs : EventArgs
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="builder">  The builder. </param>
        public ConfigurationBuilderCreatedEventArgs(IConfigurationBuilder builder)
        {
            Builder = builder;
        }

        /// <summary>
        ///     Gets the builder.
        /// </summary>
        /// <value>
        ///     The builder.
        /// </value>
        public IConfigurationBuilder Builder { get; }
    }
}