using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluiTec.AppFx.Console.Items;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;

namespace SimpleSample.ConsoleModules.Config
{
    /// <summary>   A configuration service interactive console item. </summary>
    public class ConfigServiceInteractiveConsoleItem : ServiceInteractiveConsoleItem
    {
        /// <summary>   Default constructor. </summary>
        public ConfigServiceInteractiveConsoleItem() : base("Options", "View/change options")
        {

        }

        /// <summary>   Executes the picked action. </summary>
        /// <remarks>
        ///     Will be triggered upon getting the item selected. Will trigger auto-pick, when item has
        ///     children.
        /// </remarks>
        public override void OnPicked()
        {
            if (Children != null)
            {
                var config = Host.HostServices.GetService(typeof(IConfigurationRoot)) as ConfigurationRoot;
                var configProvider = config?.Providers
                    .Where(p => p is JsonConfigurationProvider)
                    .Cast<JsonConfigurationProvider>()
                    .Single(p => p.Source.Path == "appsettings.conf.json");

                var filePath =
                    $"{(configProvider?.Source?.FileProvider as PhysicalFileProvider)?.Root}{configProvider?.Source?.Path}";

                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    ConfigureChildren(config, configProvider, filePath);
                }
            }

            base.OnPicked();
        }

        /// <summary>   Configure children. </summary>
        /// <param name="root">             The root. </param>
        /// <param name="provider">         The provider. </param>
        /// <param name="configFilePath">   Full pathname of the configuration file. </param>
        private void ConfigureChildren(IConfigurationRoot root, JsonConfigurationProvider provider, string configFilePath)
        {
            var tempRoot = new ConfigurationRoot(root.Providers.Where(p =>
                p is not EnvironmentVariablesConfigurationProvider).ToList());

            var entries =tempRoot.AsEnumerable().OrderBy(kv => kv.Key).ToList();

            foreach (var entry in entries)
            {
                if (!entry.Key.Contains(':'))
                {
                    // no parent assumed, insert directly
                    Children.Add(new ConfigOptionServiceInteractiveConsoleItem(entry.Key, entry.Value));
                }
                else
                {
                    var child = new ConfigOptionServiceInteractiveConsoleItem(entry.Key, entry.Value);

                    var parentKey = entry.Key.Substring(0, entry.Key.LastIndexOf(':'));

                    var parent = Children
                        .SingleOrDefault(p => ((ConfigOptionServiceInteractiveConsoleItem) p).Key == parentKey) 
                        ?? CreateParent(child);

                    parent.Children.Add(child);
                }
            }
        }

        /// <summary>   Creates a parent. </summary>
        /// <param name="child">    The child. </param>
        /// <returns>   The new parent. </returns>
        private IInteractiveConsoleItem CreateParent(ConfigOptionServiceInteractiveConsoleItem child)
        {
            var parentKey = child.Key.Substring(0, child.Key.LastIndexOf(':'));



            return null;
        }

        private IInteractiveConsoleItem ParentExists(string key)
        {
            if (!key.Contains(':')) return this;
        }
    }
}