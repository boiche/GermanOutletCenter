using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace GermanOutletStore.Web.Extensions
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary values, string key, T value) where T : class
        {
            values[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary values, string key) where T : class
        {
            values.TryGetValue(key, out object value);
            return value == null ? null : JsonConvert.DeserializeObject<T>((string)value);
        }
    }
}
