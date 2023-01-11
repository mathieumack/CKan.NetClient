using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CKan.NetClient.Clients.Packages.HttpModels
{
    public class PackageShowDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("revision_id")]
        public string RevisionId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("creator_user_id")]
        public string CreatorUserId { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("author_email")]
        public string AuthorEmail { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("resources")]
        public List<PackageResourceItem> Resources { get; set; }

        [JsonProperty("tags")]
        public List<PackageTagItem> Tags { get; set; }
    }
}
