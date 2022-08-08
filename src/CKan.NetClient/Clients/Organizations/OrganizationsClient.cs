using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Packages.Models;
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
        public async Task<List<string>> GetOrganizations()
        {
            var content = await GetContent("api/3/action/organization_list");
            var responsecontent = await content.ReadAsAsync<PackageListResult>();
            return responsecontent.Result;
        }
    }
}
