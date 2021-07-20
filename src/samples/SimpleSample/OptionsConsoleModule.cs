using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.ConsoleItems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SimpleSample
{
    /// <summary>   The options console module. </summary>
    public class OptionsConsoleModule : ModuleConsoleItem
    {
        /// <summary>   Default constructor. </summary>
        public OptionsConsoleModule() : base("Options")
        {
        }

        /// <summary>   Initializes this. </summary>
        protected override void Initialize()
        {
            var config = Application.HostServices.GetRequiredService<IConfigurationRoot>();
            var providers = config.Providers
                .Where(p => p.GetType() != typeof(EnvironmentVariablesConfigurationProvider))
                .Where(p => !(p is JsonConfigurationProvider) || ((JsonConfigurationProvider) p).Source.Path != "appsettings.conf.json");
            
            var configValues = new ConfigurationRoot(providers.ToList()).AsEnumerable().OrderBy(v => v.Key);
            foreach (var val in configValues)
            {
                var parent = val.Key.Contains(':') ? FindParent(val) : this;
                parent.Items.Add(new OptionsConsoleItem(this, val));
            }
        }

        /// <summary>   Finds the parent of this item. </summary>
        /// <param name="entry">    The entry. </param>
        /// <returns>   The found parent. </returns>
        protected SelectConsoleItem FindParent(KeyValuePair<string, string> entry)
        {
            var split = entry.Key.Split(':').ToList();

            SelectConsoleItem parent = this;
            for (var i = 0; i < split.Count - 1; i++)
            {
                var parentName = split[i];
                var nParent = parent.Items.SingleOrDefault(item => item.Name == parentName) as SelectConsoleItem;
                if (nParent == null)
                {
                    nParent = new OptionsConsoleItem(this, new KeyValuePair<string, string>(split[i], null));
                    parent.Items.Add(nParent);
                }

                parent = nParent;
            }

            return parent;
        }

        /// <summary>   Finds the configured option types in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the configured option types in
        ///     this collection.
        /// </returns>
        private IEnumerable<Type> FindConfiguredOptionTypes()
        {
            if (Application.HostServices.GetRequiredService(typeof(IServiceCollection)) is not IServiceCollection
                services) return Enumerable.Empty<Type>();
            
            return services
                .Select(s => s.ServiceType)
                .Where(s => s.IsGenericType && typeof(IConfigureOptions<>).IsAssignableFrom(s.GetGenericTypeDefinition()))
                .Select(s => s.GenericTypeArguments.Single())
                .ToList();
        }

        /// <summary>   Edit setting. </summary>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        public void EditSetting(string key, string value)
        {

        }

        /// <summary>   Edit setting. </summary>
        /// <param name="item"> The item. </param>
        public void EditSetting(KeyValuePair<string, string> item)
        {
            EditSetting(item.Key, item.Value);
        }
    }
}