using Newtonsoft.Json;

namespace CKan.NetClient.Clients.Packages.HttpModels
{
    public class PackageResourceItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }
    }
}
