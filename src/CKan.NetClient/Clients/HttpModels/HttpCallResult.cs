using Newtonsoft.Json;

namespace CKan.NetClient.Clients.HttpModels
{
    public class HttpCallResult<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
