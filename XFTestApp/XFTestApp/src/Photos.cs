using Newtonsoft.Json;

namespace XFTestApp
{
    class Photos
    {
        [JsonProperty(PropertyName = "photos")]
        public Info Photoss { get; set; }
    }
}