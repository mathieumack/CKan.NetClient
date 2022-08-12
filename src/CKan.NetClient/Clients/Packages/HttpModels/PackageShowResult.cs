using Newtonsoft.Json;

namespace CKan.NetClient.Clients.Packages.HttpModels
{
    public class PackageShowResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public PackageShowDetails Result { get; set; }
    }
}
