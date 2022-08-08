# CKan.NetClient
This library let you to interact with a CKan server APIs with dedicated clients.

==========

# IC
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=mathieumack_CKan.NetClient&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=mathieumack_CKan.NetClient)
[![.NET](https://github.com/mathieumack/CKan.NetClient/actions/workflows/ci.yml/badge.svg)](https://github.com/mathieumack/CKan.NetClient/actions/workflows/ci.yml)
[![NuGet package](https://buildstats.info/nuget/CKan.NetClient.Unoficial?includePreReleases=true)](https://nuget.org/packages/CKan.NetClient.Unoficial)

# Onboarding Instructions 

## Installation

1. Add nuget package: 

> Install-Package CKan.NetClient.Unoficial

2. CI configuration. In your startup file, you must register an HttpClient by using the HttpClientFactory and next register the custom CKan client by calling the AddCKanClient method.

```c#
private void Register(this IServiceCollection services)
{
    // Define the baseUri of your organization :
    var baseUri = "https://sample.com/ckan";

    // Register the HttpClientFactory :
    services.AddHttpClient()

    // Register the CKanClient object :
    services.AddCKanClient(baseUri);
}
```

> If you have a named HttpClient, you can use it. 
Ex : You can use it to mock Http calls :

```c#
private void Register(this IServiceCollection services)
{
    // Register the HttpClientFactory :
    services.AddHttpClient("customName")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    // custom handler
                });

    // Register the CKanClient object with the named http client
    services.AddCKanClient(baseUri, "customName");
}
```

3. Now in your application you can use the CKanClient object from the DI or directly from the service provider : 

```c#
public CkanClient GetClient(IServiceProvider serviceProvider)
{
    return serviceProvider.GetRequiredService<CKanClient>();
}

public class MyHttpController
{
    private readonly CkanClient client;

    public MyHttpController(CkanClient client)
    {
        this.client = client;
    }
}
```

## API calls
Each API has his own client that let you to read and manipulate datas.
Each API is linked to an interface named : I\<Api name\>Client.

Ex for groups :

```c#
public IGroupsClient GetGroupsClient(CkanClient client)
{
    return serviceProvider.GetClient<IGroupsClient>();
}
```

This interface let you to read groups, get group details, ...

### List of available clients :

* Groups : IGroupsClient
* Organizations : IOrganizationsClient
* Packages : IPackagesClient
* Tags : ITagsClient

### Common supported functions :

Only read operations are avaiable yet. But more functions will be developped soon. Do not hesitate to participate.

# Documentation : I want more

Do not hesitate to check unit tests on the solution. It's a good way to check client calls and samples.

Do not hesitate to contribute.


# Support / Contribute
> If you have any questions, problems or suggestions, create an issue or fork the project and create a Pull Request.