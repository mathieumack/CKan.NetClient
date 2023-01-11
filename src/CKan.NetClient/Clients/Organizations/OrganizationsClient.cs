using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.HttpModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKan.NetClient.Clients.Organization
{
    internal class OrganizationsClient : BaseHttpClient, IOrganizationsClient
    {
        public OrganizationsClient(CKanClient client, IHttpClientFactory clientFactory)
            : base(client, clientFactory)
        {
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetOrganizations(int? limit = null, int? offset = null)
        {
            var queryParams = new List<string>();

            // Paging configuration :
            if (limit.HasValue)
                queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue)
                queryParams.Add($"offset={offset.Value}");

            var content = await GetContent("api/3/action/organization_list", queryParams);
            var responsecontent = await content.ReadAsAsync<HttpCallListResult<string>>();
            return responsecontent.Result;
        }
    }
}
