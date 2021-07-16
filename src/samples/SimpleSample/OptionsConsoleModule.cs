using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Console.ConsoleItems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Spectre.Console;

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
                parent.Items.Add(new OptionsConsoleItem(val));
            }
        }

        /// <summary>   Finds the parent of this item. </summary>
        /// <param name="entry">    The entry. </param>
        /// <returns>   The found parent. </returns>
        protected SelectConsoleItem FindParent(KeyValuePair<string, string> entry)
        {
            System.Diagnostics.Debug.WriteLine(entry);
            var split = entry.Key.Split(':').ToList();

            SelectConsoleItem parent = this;
            for (var i = 0; i < split.Count - 1; i++)
            {
                var parentName = split[i];
                var nParent = parent.Items.SingleOrDefault(item => item.Name == parentName) as SelectConsoleItem;
                if (nParent == null)
                {
                    nParent = new OptionsConsoleItem(new KeyValuePair<string, string>(split[i], null));
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
    }

    /// <summary>   The options console item. </summary>
    public class OptionsConsoleItem : SelectConsoleItem
    {
        public string Key { get; set; }

        public string Value { get; set; }

        /// <summary>   Constructor. </summary>
        /// <param name="item"> The item. </param>
        public OptionsConsoleItem(KeyValuePair<string, string> item) : base(item.Key.Contains(':') ? item.Key.Substring(item.Key.LastIndexOf(':')+1) : item.Key)
        {
            Key = item.Key;
            Value = item.Value;
        }

        /// <summary>   Displays this. </summary>
        /// <param name="parent">   The parent. </param>
        public override void Display(IConsoleItem parent)
        {
            base.Display(parent);
            if (Items.Any()) return;

            Presenter.PresentHeader(Name);
            AnsiConsole.MarkupLine($"The {Presenter.HighlightText("current value")} is \"{Value}\"");
            Value = AnsiConsole.Ask<string>($"Please enter a {Presenter.HighlightText("new value")}:");
            AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new value")} is \"{Value}\"");
            Parent.Display(null);
        }
    }
}