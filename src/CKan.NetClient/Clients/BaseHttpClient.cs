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
            HttpClient httpclient;
            
            if(string.IsNullOrWhiteSpace(httpClientName))
                httpclient = clientFactory.CreateClient();
            else
                httpclient = clientFactory.CreateClient(httpClientName);

            // TODO : Add Encoding management on headers

            var response = await httpclient.GetAsync($"{client.BaseUri}/{uri}");

            // TODO : Define Error management in HTTP calls
            response.EnsureSuccessStatusCode();

            return response.Content;
        }
    }
}
