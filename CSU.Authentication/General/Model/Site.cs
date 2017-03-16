
namespace CSU.Authentication.General.Model
{
    using System.Collections.Specialized;
    using Newtonsoft.Json;

    [JsonObject]
    public class Site
    {
        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("Parameters")]
        public Parameters Parameters { get; set; }

    }
}
