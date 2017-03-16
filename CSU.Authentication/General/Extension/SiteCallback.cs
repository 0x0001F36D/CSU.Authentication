
namespace CSU.Authentication.General.Extension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Reflection;
    using Status;

    public static class SiteCallback
    {
        public static RCallback Bind<RCallback>(this string json, RCallback anonymousObject)
            => JsonConvert.DeserializeAnonymousType(json, anonymousObject);

        public static IDictionary<string, object> Reflect(this IStatus obj)
            => (from d in obj.Data.GetType().GetProperties()
                let value = d.GetValue(obj.Data)
                where !string.IsNullOrWhiteSpace(value?.ToString())
                select new { d.Name, value }).ToDictionary(x => x.Name, x => x.value);

    }
}
