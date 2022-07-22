using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Groups.HttpModels;
using CKan.NetClient.Clients.Groups.Models;
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
        public async Task<GroupShowDetails> GetGroupByName(string name)
        {
            var content = await GetContent($"api/3/action/group_show?id={name}");
            var responsecontent = await content.ReadAsAsync<GroupShowResult>();
            return responsecontent.Result;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetGroups()
        {
            var content = await GetContent("api/3/action/group_list");
            var responsecontent = await content.ReadAsAsync<GroupListResult>();
            return responsecontent.Result;
        }
    }
}
