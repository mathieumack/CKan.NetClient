using Newtonsoft.Json;
using System.Collections.Generic;

namespace CKan.NetClient.Clients.HttpModels
{
    public class HttpCallListResult<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public List<T> Result { get; set; }
    }
}
