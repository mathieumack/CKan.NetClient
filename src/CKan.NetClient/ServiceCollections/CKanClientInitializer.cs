using CKan.NetClient.Abstractions;
using CKan.NetClient.Clients.Groups;
using CKan.NetClient.Clients.Organization;
using CKan.NetClient.Clients.Packages;
using CKan.NetClient.Clients.Tags;
using Microsoft.Extensions.DependencyInjection;

namespace CKan.NetClient.ServiceCollections
{
    public static class CKanClientInitializer
    {
        public static void AddCKanClient(this IServiceCollection serviceCollection, string baseUri)
        {
            serviceCollection.AddCKanClient(baseUri, string.Empty);
        }

        public static void AddCKanClient(this IServiceCollection serviceCollection, string baseUri, string httpClientName)
        {
            serviceCollection.AddSingleton(options =>
            {
                return new CKanClient(baseUri, options, httpClientName);
            });

            // Add clients :
            serviceCollection.AddTransient<IGroupsClient, GroupsClient>();
            serviceCollection.AddTransient<ITagsClient, TagsClient>();
            serviceCollection.AddTransient<IPackagesClient, PackagesClient>();
            serviceCollection.AddTransient<IOrganizationsClient, OrganizationsClient>();
        }
    }
}
