using System;
using System.Linq;
using System.Reflection;
using FluiTec.AppFx.Console.ConsoleItems;
using FluiTec.AppFx.Data.Dynamic.Configuration;
using FluiTec.AppFx.Options.Attributes;
using Spectre.Console;

namespace SimpleSample
{
    /// <summary>   A dynamic data provider item. </summary>
    public class DynamicDataProviderItem : SelectConsoleItem
    {
        /// <summary>   Gets the data module. </summary>
        /// <value> The data module. </value>
        public DynamicDataConsoleModule Module { get; }

        /// <summary>   Gets the provider key. </summary>
        /// <value> The provider key. </value>
        public string ProviderKey { get; }

        /// <summary>   Gets or sets the provider. </summary>
        /// <value> The provider. </value>
        public DataProvider Provider
        {
            get => Module.DynamicDataOptions.CurrentValue.Provider;
            set
            {
                if (Provider != value)
                {
                    AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new provider")} is \"{value}\"");
                    Module.EditSetting(ProviderKey, value.ToString());
                    AnsiConsole.MarkupLine($"The {Presenter.HighlightText("new provider")} was saved");
                }
                else
                {
                    AnsiConsole.MarkupLine(
                        $"The new provider {Presenter.HighlightText("equals")} the current provider - no changes saved");
                }
            }
        }

        /// <summary>   Constructor. </summary>
        /// <param name="module">   The module. </param>
        public DynamicDataProviderItem(DynamicDataConsoleModule module) : base("Provider")
        {
            Module = module;
            Items.AddRange(Enum.GetValues<DataProvider>().Select(v => new DataProviderConsoleItem(v)));

            ProviderKey = typeof(DynamicDataOptions).GetTypeInfo()
                    .GetCustomAttributes(typeof(ConfigurationKeyAttribute)).SingleOrDefault() is
                ConfigurationKeyAttribute attribute
                ? attribute.Name
                : nameof(DynamicDataOptions);
            ProviderKey = $"{ProviderKey}:{nameof(DynamicDataOptions.Provider)}";
        }

        /// <summary>   Displays the given parent. </summary>
        /// <param name="parent">   The parent. </param>
        public override void Display(IConsoleItem parent)
        {
            if (parent != null)
                Parent = parent;
            
            Presenter.PresentHeader($"Pick {{{Name}}} - current value:");
            AnsiConsole.WriteLine(Provider.ToString());
            AnsiConsole.Render(new Rule().RuleStyle(Presenter.Style.DefaultTextStyle).LeftAligned());

            var selected = AnsiConsole.Prompt(new SelectionPrompt<IConsoleItem>()
                .Title(PromptTitle)
                .PageSize(Presenter.DefaultPageSize)
                .MoreChoicesText(MoreChoicesText)
                .AddChoices(ShowDefaultItems ? Items.Concat(CreateDefaultItems()) : Items)
                .UseConverter(ListEntryConverter)
                .HighlightStyle(Presenter.Style.SelectHighlightTextStyle)
            );

            if (selected is DataProviderConsoleItem providerConsoleItem)
            {
                Provider = providerConsoleItem.Provider;
                Parent.Display(null);
            }
            else
            {
                selected.Display(this);
            }
        }

        /// <summary>   A data provider console item. </summary>
        public class DataProviderConsoleItem : ConsoleItem
        {
            /// <summary>   Gets the provider. </summary>
            /// <value> The provider. </value>
            public DataProvider Provider { get; }

            /// <summary>   Constructor. </summary>
            /// <param name="provider"> The provider. </param>
            public DataProviderConsoleItem(DataProvider provider) : base(provider.ToString())
            {
                Provider = provider;
            }
        }
    }
}