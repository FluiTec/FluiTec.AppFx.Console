using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace FluiTec.AppFx.Console.Configuration
{
    /// <summary>   A saveable JSON configuration source. </summary>
    public class SaveableJsonConfigurationSource : JsonConfigurationSource
    {
        /// <summary>
        ///     Builds the
        ///     <see cref="T:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider" /> for
        ///     this source.
        /// </summary>
        /// <param name="builder">
        ///     The
        ///     <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.
        /// </param>
        /// <returns>
        ///     A <see cref="T:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider" />
        /// </returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new SaveableJsonConfigurationProvider(this);
        }
    }
}