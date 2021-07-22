using System.Collections.Generic;
using FluiTec.AppFx.Console.ConsoleItems;
using FluiTec.AppFx.Data.DataServices;
using FluiTec.AppFx.Data.Dynamic.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SimpleSample
{
    /// <summary>   A dynamic data console module. </summary>
    public class DynamicDataConsoleModule : ModuleConsoleItem
    {
        /// <summary>   Gets the save enabled provider. </summary>
        /// <value> The save enabled provider. </value>
        public IConfigurationProvider SaveEnabledProvider { get; }

        /// <summary>   Gets or sets the configuration root. </summary>
        /// <value> The configuration root. </value>
        private IConfigurationRoot ConfigurationRoot { get; set; }

        /// <summary>   Gets or sets options for controlling the dynamic data. </summary>
        /// <value> Options that control the dynamic data. </value>
        public IOptionsMonitor<DynamicDataOptions> DynamicDataOptions { get; private set; }

        /// <summary>   Constructor. </summary>
        /// <param name="saveEnabledProvider">  The save enabled provider. </param>
        public DynamicDataConsoleModule(IConfigurationProvider saveEnabledProvider) : base("Data")
        {
            SaveEnabledProvider = saveEnabledProvider;
            Items.Add(new DynamicDataProviderItem(this));
        }

        /// <summary>   Initializes this. </summary>
        protected override void Initialize()
        {
            ConfigurationRoot = Application.HostServices.GetRequiredService<IConfigurationRoot>();
            DynamicDataOptions = Application.HostServices.GetRequiredService<IOptionsMonitor<DynamicDataOptions>>();

            var dataServices = Application.HostServices.GetServices<IDataService>();
        }

        /// <summary>   Gets setting value. </summary>
        /// <param name="key">  The key. </param>
        /// <returns>   The setting value. </returns>
        public string GetSettingValue(string key)
        {
            return ConfigurationRoot[key];
        }

        /// <summary>   Edit setting. </summary>
        /// <param name="key">      The key. </param>
        /// <param name="value">    The value. </param>
        public void EditSetting(string key, string value)
        {
            SaveEnabledProvider?.Set(key, value);
        }

        /// <summary>   Edit setting. </summary>
        /// <param name="item"> The item. </param>
        public void EditSetting(KeyValuePair<string, string> item)
        {
            EditSetting(item.Key, item.Value);
        }
    }
}