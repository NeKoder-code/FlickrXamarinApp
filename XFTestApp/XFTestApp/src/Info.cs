using System.Collections.Generic;
using Newtonsoft.Json;

namespace XFTestApp
{
    class Info
    {
        [JsonProperty(PropertyName = "photo")]
        public List<Photo> PhotoList { get; set; }
    }
}