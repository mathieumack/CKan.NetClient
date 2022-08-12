using Newtonsoft.Json;

namespace CKan.NetClient.Clients.Packages.HttpModels
{
    public class PackageTagItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
