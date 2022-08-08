using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System.IO;
using System.Net;

namespace CKan.NetClient.Tests.Clients.Organizations
{
    [TestClass]
    public class GetOrganizationsTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients\\Organizations\\httpCalls\\list_200.json"));

            var organizationsClient = GetCKanClient<IOrganizationsClient>();
            var organizations = await organizationsClient.GetOrganizations();

            organizations.Should().HaveCount(2);
        }
    }
}
