using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Packages.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKan.NetClient.Clients.Packages
{
    internal class PackagesClient : BaseHttpClient, IPackagesClient
    {
        public PackagesClient(CKanClient client, IHttpClientFactory clientFactory)
            : base(client, clientFactory)
        {
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetPackages(int? limit = null, int? offset = null)
        {
            var queryParams = new List<string>();

            // Paging configuration :
            if (limit.HasValue)
                queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue)
                queryParams.Add($"offset={offset.Value}");

            var content = await GetContent("api/3/action/package_list", queryParams);
            var responsecontent = await content.ReadAsAsync<PackageListResult>();
            return responsecontent.Result;
        }
    }
}
