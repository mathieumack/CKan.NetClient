using CKan.NetClient.Clients;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CKan.NetClient
{
    public class CKanClient
    {
        /// <summary>
        /// Base uri of the service used.
        /// ex : https://something.com/ckan
        /// </summary>
        public string BaseUri { get; }
        public string HttpClientName { get; }
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUri"></param>
        public CKanClient(string baseUri, IServiceProvider serviceProvider)
        {
            this.BaseUri = baseUri;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUri"></param>
        public CKanClient(string baseUri, IServiceProvider serviceProvider, string httpClientName)
        {
            this.BaseUri = baseUri;
            this.serviceProvider = serviceProvider;
            this.HttpClientName = httpClientName;
        }

        public T GetClient<T>()
        {
            var service = serviceProvider.GetRequiredService<T>();

            (service as BaseHttpClient)?.RegisterHttpClientName(HttpClientName);

            return service;
        }
    }
}