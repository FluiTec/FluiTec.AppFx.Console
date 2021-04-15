using System;
using FluiTec.AppFx.Console.Items;
using FluiTec.AppFx.Data.Dynamic.Configuration;

namespace SimpleSample.ConsoleModules.Data
{
    /// <summary>   A base data service interactive console item. </summary>
    public abstract class BaseDataServiceInteractiveConsoleItem : ServiceInteractiveConsoleItem
    {
        /// <summary>   Gets or sets options for controlling the operation. </summary>
        /// <value> The options. </value>
        public DynamicDataOptions Options { get; set; }

        /// <summary>   Specialized constructor for use only by derived class. </summary>
        /// <param name="name">         The name. </param>
        /// <param name="description">  The description. </param>
        /// <param name="options">      Options for controlling the operation. </param>
        protected BaseDataServiceInteractiveConsoleItem(string name, string description, DynamicDataOptions options) :
            base(name, description)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}