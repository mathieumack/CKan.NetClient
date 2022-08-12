using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Packages.HttpModels;
using CKan.NetClient.Clients.Packages.Models;
using System;
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
        public async Task<PackageShowDetails> GetPackageById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            var content = await GetContent($"api/3/action/package_show?id={id}");
            var responsecontent = await content.ReadAsAsync<PackageShowResult>();
            return responsecontent.Result;
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
