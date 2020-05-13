using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GermanOutletStore.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void Put<T>(this ISession session, string key, T value) where T : class
        {
            session.SetString(key, JsonConvert.SerializeObject(value));            
        }

        public static T Get<T>(this ISession session, string key) where T : class
        {
            string result = session.GetString(key);
            return result == null ? null : JsonConvert.DeserializeObject<T>(result);
        }
    }
}
