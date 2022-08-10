using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CKan.NetClient.Clients
{
    internal abstract class BaseHttpClient
    {
        protected readonly CKanClient client;
        protected string httpClientName;
        protected readonly IHttpClientFactory clientFactory;

        protected BaseHttpClient(CKanClient client, 
                                IHttpClientFactory clientFactory)
        {
            this.client = client;
            this.clientFactory = clientFactory;
        }

        internal void RegisterHttpClientName(string httpClientName)
        {
            this.httpClientName = httpClientName;
        }

        protected async Task<HttpContent> GetContent(string uri)
        {
            return await GetContent(uri, null);
        }

        protected async Task<HttpContent> GetContent(string uri, List<string> queryParams)
        {
            HttpClient httpclient;

            if (string.IsNullOrWhiteSpace(httpClientName))
                httpclient = clientFactory.CreateClient();
            else
                httpclient = clientFactory.CreateClient(httpClientName);

            // TODO : Add Encoding management on headers

            var finalUri = uri;
            if(queryParams != null && queryParams.Count > 0)
                finalUri += "?" + string.Join("&", queryParams);

            var response = await httpclient.GetAsync($"{client.BaseUri}/{finalUri}");

            // TODO : Define Error management in HTTP calls
            response.EnsureSuccessStatusCode();

            return response.Content;
        }
    }
}
