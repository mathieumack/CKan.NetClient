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
        public async Task<List<string>> GetPackages()
        {
            var content = await GetContent("api/3/action/package_list");
            var responsecontent = await content.ReadAsAsync<PackageListResult>();
            return responsecontent.Result;
        }
    }
}
