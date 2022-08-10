using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Tags.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKan.NetClient.Clients.Tags
{
    internal class TagsClient : BaseHttpClient, ITagsClient
    {
        public TagsClient(CKanClient client, IHttpClientFactory clientFactory)
            : base(client, clientFactory)
        {
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetTags(int? limit = null, int? offset = null)
        {
            var queryParams = new List<string>();

            // Paging configuration :
            if (limit.HasValue)
                queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue)
                queryParams.Add($"offset={offset.Value}");

            var content = await GetContent("api/3/action/tag_list", queryParams);
            var responsecontent = await content.ReadAsAsync<TagListResult>();
            return responsecontent.Result;
        }
    }
}
