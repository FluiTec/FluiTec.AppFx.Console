using FluiTec.AppFx.Console.Controls;
using FluiTec.AppFx.Console.Items;

namespace SimpleSample.ConsoleModules.Config
{
    /// <summary>   A configuration option service interactive console item. </summary>
    public class ConfigOptionServiceInteractiveConsoleItem : BaseInteractiveConsoleItem
    {
        /// <summary>   Gets or sets the key. </summary>
        /// <value> The key. </value>
        public string Key { get; set; }

        /// <summary>   Gets or sets the value. </summary>
        /// <value> The value. </value>
        public string Value { get; set; }
        
        /// <summary>   Gets or sets the description. </summary>
        /// <value> The description. </value>
        public override string Description
        {
            get => HasChildren ? $"Options for {Name}" : "Read/Update value";
            protected set
            {
                // ignore
            }
        }

        /// <summary>   Constructor. </summary>
        /// <param name="key">          The key. </param>
        /// <param name="value">        (Optional) The value. </param>
        public ConfigOptionServiceInteractiveConsoleItem(string key, string value = "") 
            : base(key, "<placeholder>", null)
        {
            Key = key;
            Value = value;
        }

        public override void OnPicked()
        {
            if (!HasChildren) // editable value
            {
                var newValue = new EditMenu(Key, Value).EditValue();
                Host.Presenter.Pick(Parent.Children);
            }
            else
            {
                base.OnPicked();   
            }
        }
    }
}