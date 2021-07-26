using System.Linq;
using System.Reflection;
using FluiTec.AppFx.Console.ConsoleItems;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Data.Dapper.SqLite;
using FluiTec.AppFx.Options.Attributes;

namespace SimpleSample
{
    /// <summary>   A connection strings console item. </summary>
    public class ConnectionStringsConsoleItem : SelectConsoleItem
    {
        /// <summary>   Gets the module. </summary>
        /// <value> The module. </value>
        public DynamicDataConsoleModule Module { get; }

        /// <summary>   Constructor. </summary>
        /// <param name="module">   The module. </param>
        public ConnectionStringsConsoleItem(DynamicDataConsoleModule module) : base("ConnectionStrings")
        {
            Module = module;

            var optionTypes = new[]
            {
                typeof(MssqlDapperServiceOptions), typeof(PgsqlDapperServiceOptions), typeof(MysqlDapperServiceOptions),
                typeof(SqliteDapperServiceOptions)
            };
            var keys = optionTypes.Select(t =>
                t.GetTypeInfo().GetCustomAttributes(typeof(ConfigurationKeyAttribute)).SingleOrDefault() is
                    ConfigurationKeyAttribute attribute
                    ? attribute.Name
                    : t.Name);
            Items.AddRange(keys.Select(k => new ConnectionStringConsoleItem(k, Module)));
        }

        /// <summary>   A connection string console item. </summary>
        public class ConnectionStringConsoleItem : EditableConsoleItem<string>
        {
            /// <summary>   Gets the provider key. </summary>
            /// <value> The provider key. </value>
            public string ProviderKey { get; }

            /// <summary>   Gets the module. </summary>
            /// <value> The module. </value>
            public DynamicDataConsoleModule Module { get; }

            /// <summary>   Default constructor. </summary>
            public ConnectionStringConsoleItem(string providerKey, DynamicDataConsoleModule module) : base(providerKey)
            {
                ProviderKey = providerKey;
                Module = module;
            }

            /// <summary>   Gets the value. </summary>
            /// <returns>   The value. </returns>
            protected override string GetValue() => Module.GetSettingValue(ProviderKey);

            /// <summary>   Sets a value. </summary>
            /// <param name="value">    The value. </param>
            protected override void SetValue(string value) => Module.EditSetting(ProviderKey, value);
        }
    }
}