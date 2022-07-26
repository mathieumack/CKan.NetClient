﻿using Newtonsoft.Json;

namespace CKan.NetClient.Clients.Groups.HttpModels
{
    public class GroupShowResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("result")]
        public GroupShowDetails Result { get; set; }
    }
}
