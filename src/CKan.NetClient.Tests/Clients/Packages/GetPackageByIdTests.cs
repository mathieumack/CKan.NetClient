using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System;
using System.Net;
using System.IO;

namespace CKan.NetClient.Tests.Clients.Packages
{
    [TestClass]
    public class GetPackageByIdTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Packages/httpCalls/byId_200.json"));

            var packagesClient = GetCKanClient<IPackagesClient>();
            var packageDetails = await packagesClient.GetPackageById("sample");

            packageDetails.Id.Should().Be("42a155db-1111-1111-1111-924fc3ed50af");
            packageDetails.Title.Should().Be("Resource 1");
            packageDetails.Resources.Count.Should().Be(2);
            packageDetails.Name.Should().Be("Resource 1");
            packageDetails.State.Should().Be("active");
            packageDetails.Type.Should().Be("dataset");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task InvalidIdentifier()
        {
            LoadServices(HttpStatusCode.Accepted, "{ }");

            var groupsClient = GetCKanClient<IPackagesClient>();
            await groupsClient.GetPackageById(null);
        }
    }
}
