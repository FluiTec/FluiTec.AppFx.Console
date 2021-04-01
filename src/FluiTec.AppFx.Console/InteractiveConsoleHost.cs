using System;
using FluiTec.AppFx.Console.Menu;
using FluiTec.AppFx.Options.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Console
{
    /// <summary>   An interactive console host. </summary>
    public class InteractiveConsoleHost
    {
        /// <summary>   Gets the configuration root. </summary>
        /// <value> The configuration root. </value>
        public IConfigurationRoot ConfigurationRoot { get; }

        /// <summary>   Gets the caller configure services. </summary>
        /// <value> The caller configure services. </value>
        public Action<IServiceCollection, ValidatingConfigurationManager> CallerConfigureServices { get; }

        /// <summary>   Gets or sets the active item. </summary>
        /// <value> The active item. </value>
        public IConsoleMenuItem ActiveItem { get; set; }

        /// <summary>   The service provider. </summary>
        private IServiceProvider _serviceProvider;

        /// <summary>   Constructor. </summary>
        /// <param name="configurationRoot">    The configuration root. </param>
        /// <param name="configureServices">    The configure services. </param>
        public InteractiveConsoleHost(IConfigurationRoot configurationRoot, Action<IServiceCollection, ValidatingConfigurationManager> configureServices)
        {
            ConfigurationRoot = configurationRoot;
            CallerConfigureServices = configureServices;
        }

        /// <summary>   Executes the interactive operation. </summary>
        public void RunInteractive()
        {
            Initialize();

            var root = new RootMenuItem("Interactive Console", "Pick any menu-item using <UP>/<DOWN> and <ENTER>", this, _serviceProvider.GetServices<IConsoleModule>());
            ActiveItem = root;

            var presenter = _serviceProvider.GetRequiredService<IItemPresenter>();

            while(ActiveItem != null)
                presenter.Present(ActiveItem);
        }

        /// <summary>   Initializes this.  </summary>
        private void Initialize()
        {
            var manager = new ConsoleReportingConfigurationManager(ConfigurationRoot);
            var services = new ServiceCollection();

            ConfigureServices(services, manager);
            CallerConfigureServices(services, manager);

            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>   Configure services. </summary>
        /// <param name="services"> The services. </param>
        /// <param name="manager">  The manager. </param>
        private void ConfigureServices(IServiceCollection services, ValidatingConfigurationManager manager)
        {
            services.AddSingleton(this);
            services.AddSingleton<IItemPresenter, DefaultItemPresenter>();
        }
    }
}