using Newtonsoft.Json;
using System;

namespace CKan.NetClient.Clients.Groups.HttpModels
{
    public class GroupShowDetails
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("revision_id")]
        public Guid RevisionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("image_display_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("package_count")]
        public int PackageCount { get; set; }

        [JsonProperty("num_followers")]
        public int NumberOfFollowers { get; set; }
    }
}
