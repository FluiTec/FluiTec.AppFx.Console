using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace FluiTec.AppFx.Console.Configuration
{
    /// <summary>   A saveable JSON configuration provider. </summary>
    public class SaveableJsonConfigurationProvider : JsonConfigurationProvider
    {
        /// <summary>   Constructor. </summary>
        /// <param name="source">   Source for the. </param>
        public SaveableJsonConfigurationProvider(JsonConfigurationSource source) : base(source)
        {
        }

        /// <summary>   Sets a value for a given key. </summary>
        /// <param name="key">      The configuration key to set. </param>
        /// <param name="value">    The value to set. </param>
        public override void Set(string key, string value)
        {
            System.Diagnostics.Debug.WriteLine($"SET {key} = {value}");
            base.Set(key, value);

            var fileInfo = Source.FileProvider.GetFileInfo(Source.Path);
            File.WriteAllText(fileInfo.PhysicalPath, ConvertToJson(Data));
        }

        /// <summary>   Converts a data to a JSON. </summary>
        /// <param name="data"> The data. </param>
        /// <returns>   The given data converted to a JSON. </returns>
        private static string ConvertToJson(IDictionary<string, string> data)
        {
            var outputDic = new Dictionary<string, object>();
            foreach (var (key, value) in data)
            {
                var keys = key.Split(':');
                SetValues(keys, 0, value, outputDic);
            }

            var json = JsonConvert.SerializeObject(outputDic, Formatting.Indented);
            return json;
        }

        /// <summary>   Sets the values. </summary>
        /// <param name="keys">         The keys. </param>
        /// <param name="keyIndex">     Zero-based index of the key. </param>
        /// <param name="value">        The value to set. </param>
        /// <param name="parentDic">    The parent dic. </param>
        private static void SetValues(IReadOnlyList<string> keys, int keyIndex, string value, IDictionary<string, object> parentDic)
        {
            var key = keys[keyIndex];

            if (keys.Count > keyIndex + 1)
            {
                IDictionary<string, object> childDict;
                if (parentDic.TryGetValue(key, out var childObj))
                {
                    childDict = (IDictionary<string, object>)childObj;
                }
                else
                {
                    childDict = new Dictionary<string, object>();
                    parentDic[key] = childDict;
                }

                SetValues(keys, keyIndex + 1, value, childDict);

            }
            else
            {
                parentDic[key] = value;
            }
        }
    }
}