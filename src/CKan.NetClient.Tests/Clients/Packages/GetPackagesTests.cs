using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System.IO;
using System.Net;

namespace CKan.NetClient.Tests.Clients.Package
{
    [TestClass]
    public class GetPackagesTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Packages/httpCalls/list_200.json"));

            var packagesClient = GetCKanClient<IPackagesClient>();
            var packages = await packagesClient.GetPackages();

            packages.Should().HaveCount(3);
        }

        [TestMethod]
        public async Task PagingCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Packages/httpCalls/list_200.json"));

            var packagesClient = GetCKanClient<IPackagesClient>();
            var packages = await packagesClient.GetPackages(limit:2, offset:1);

            packages.Should().HaveCount(3);
        }


        [TestMethod]
        public async Task GroupCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Packages/httpCalls/groupPackages_200.json"));

            var packagesClient = GetCKanClient<IPackagesClient>();
            var packages = await packagesClient.GetPackagesByGroup("culture");

            packages.Should().HaveCount(10);
        }
    }
}
