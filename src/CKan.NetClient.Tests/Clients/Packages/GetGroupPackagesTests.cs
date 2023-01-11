using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System.IO;
using System.Net;

namespace CKan.NetClient.Tests.Clients.Package
{
    [TestClass]
    public class GetGroupPackagesTests : BaseTestsClass
    {
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
