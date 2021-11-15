using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace FluiTec.AppFx.Console.Configuration
{
    /// <summary>   A saveable JSON configuration extensions. </summary>
    public static class SaveableJsonConfigurationExtensions
    {
        /// <summary>   Adds a JSON configuration source to <paramref name="builder" />. </summary>
        /// <param name="builder">  The <see cref="IConfigurationBuilder" /> to add to. </param>
        /// <param name="path">     Full pathname of the file. </param>
        /// <returns>   The <see cref="IConfigurationBuilder" />. </returns>
        public static IConfigurationBuilder AddSaveableJsonFile(this IConfigurationBuilder builder, string path)
        {
            return AddSaveableJsonFile(builder, null, path, false, false);
        }

        /// <summary>   Adds a JSON configuration source to <paramref name="builder" />. </summary>
        /// <param name="builder">  The <see cref="IConfigurationBuilder" /> to add to. </param>
        /// <param name="path">     Full pathname of the file. </param>
        /// <param name="optional"> True to optional. </param>
        /// <returns>   The <see cref="IConfigurationBuilder" />. </returns>
        public static IConfigurationBuilder AddSaveableJsonFile(this IConfigurationBuilder builder, string path,
            bool optional)
        {
            return AddSaveableJsonFile(builder, null, path, optional, false);
        }

        /// <summary>   Adds a JSON configuration source to <paramref name="builder" />. </summary>
        /// <param name="builder">          The <see cref="IConfigurationBuilder" /> to add to. </param>
        /// <param name="path">             Full pathname of the file. </param>
        /// <param name="optional">         True to optional. </param>
        /// <param name="reloadOnChange">   True to reload on change. </param>
        /// <returns>   The <see cref="IConfigurationBuilder" />. </returns>
        public static IConfigurationBuilder AddSaveableJsonFile(this IConfigurationBuilder builder, string path,
            bool optional, bool reloadOnChange)
        {
            return AddSaveableJsonFile(builder, null, path, optional, reloadOnChange);
        }

        /// <summary>   Adds a JSON configuration source to <paramref name="builder" />. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="builder">          The <see cref="IConfigurationBuilder" /> to add to. </param>
        /// <param name="provider">         The provider. </param>
        /// <param name="path">             Full pathname of the file. </param>
        /// <param name="optional">         True to optional. </param>
        /// <param name="reloadOnChange">   True to reload on change. </param>
        /// <returns>   The <see cref="IConfigurationBuilder" />. </returns>
        public static IConfigurationBuilder AddSaveableJsonFile(this IConfigurationBuilder builder,
            IFileProvider? provider, string path, bool optional, bool reloadOnChange)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            return builder.AddSaveableJsonFile(s =>
            {
                s.FileProvider = provider;
                s.Path = path;
                s.Optional = optional;
                s.ReloadOnChange = reloadOnChange;
                s.ResolveFileProvider();
            });
        }

        /// <summary>
        ///     Adds a JSON configuration source to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder" /> to add to.</param>
        /// <param name="configureSource">Configures the source.</param>
        /// <returns>The <see cref="IConfigurationBuilder" />.</returns>
        public static IConfigurationBuilder AddSaveableJsonFile(this IConfigurationBuilder builder,
            Action<SaveableJsonConfigurationSource> configureSource)
        {
            return builder.Add(configureSource);
        }
    }
}