using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CKan.NetClient.ServiceCollections;
using System;
using System.Net;
using System.Net.Http;
using Moq;
using System.Threading.Tasks;
using Moq.Protected;
using System.Threading;
using System.Net.Http.Headers;

namespace CKan.NetClient.Tests
{
    public abstract class BaseTestsClass
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private IServiceProvider serviceProvider;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// Load DI without Http Mocks
        /// </summary>
        protected void LoadServices()
        {
            LoadServices(HttpStatusCode.Accepted, string.Empty);
        }

        /// <summary>
        /// Load DI without a HTTP call mock
        /// </summary>
        protected void LoadServices(HttpStatusCode statusCode, string httpSimulationContent)
        {
            serviceProvider = ServiceCollectionInitializer("https://data.metropolegrenoble.fr/ckan", statusCode, httpSimulationContent);
        }

        protected T GetCKanClient<T>()
        {
            var client = serviceProvider.GetRequiredService<CKanClient>();
            return client.GetClient<T>();
        }

        /// <summary>
        /// Initialize a new service collection environment and create a new JsonTransform object
        /// </summary>
        /// <returns></returns>
        private IServiceProvider ServiceCollectionInitializer(string baseUri, HttpStatusCode statusCode, string httpSimulationContent)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging(configure => configure.AddConsole());

            serviceCollection.AddCKanClient(baseUri, "mocks");

            if (!string.IsNullOrWhiteSpace(httpSimulationContent))
                RegisterHttpMock(serviceCollection, statusCode, httpSimulationContent);

            return serviceCollection.BuildServiceProvider();
        }

        #region Mock Http calls with sample data

        private void RegisterHttpMock(IServiceCollection services, HttpStatusCode statusCode, string httpSimulationContent)
        {
            services.AddHttpClient("mocks")
                        .ConfigurePrimaryHttpMessageHandler(() =>
                        {
                            return GetMockMessageHandler(statusCode, httpSimulationContent);
                        });
        }

        private HttpMessageHandler GetMockMessageHandler(HttpStatusCode statusCode, string httpSimulationContent)
        {
            var mock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            var response = new HttpResponseMessage()
            {
                StatusCode = statusCode,
                Content = new StringContent(httpSimulationContent)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            mock.Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(response)
               .Verifiable();

            return mock.Object;
        }

        #endregion
    }
}