using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Groups.HttpModels;
using CKan.NetClient.Clients.Groups.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKan.NetClient.Clients.Groups
{
    internal class GroupsClient : BaseHttpClient, IGroupsClient
    {
        public GroupsClient(CKanClient client, IHttpClientFactory clientFactory)
            : base(client, clientFactory)
        {
        }

        /// <inheritdoc/>
        public async Task<GroupShowDetails> GetGroupById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var content = await GetContent($"api/3/action/group_show?id={id}");
            var responsecontent = await content.ReadAsAsync<GroupShowResult>();
            return responsecontent.Result;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetGroups(int? limit = null, int? offset = null)
        {
            var queryParams = new List<string>();

            // Paging configuration :
            if (limit.HasValue)
                queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue)
                queryParams.Add($"offset={offset.Value}");

            var content = await GetContent("api/3/action/group_list", queryParams);
            var responsecontent = await content.ReadAsAsync<GroupListResult>();
            return responsecontent.Result;
        }
    }
}
