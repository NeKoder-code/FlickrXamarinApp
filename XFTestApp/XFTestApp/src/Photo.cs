using Newtonsoft.Json;

namespace XFTestApp
{
    class Photo
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "farm")]
        public string Farm { get; set; }

        [JsonProperty(PropertyName = "server")]
        public string Server { get; set; }

        [JsonProperty(PropertyName = "secret")]
        public string Secret { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public Photo(string id, string farm,string server, string secret, string title) {
            Id = id;
            Farm = farm;
            Server = server;
            Secret = secret;
            Title = title;
            Link = $"https://farm{Farm}.staticflickr.com/{Server}/{Id}_{Secret}.jpg";
        }
        public Photo() { }
        public string Link { get; set; }
    }
}