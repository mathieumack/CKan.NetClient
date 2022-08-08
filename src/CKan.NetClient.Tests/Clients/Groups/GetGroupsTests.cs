using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System.Net;
using System.IO;

namespace CKan.NetClient.Tests.Clients.Groups
{
    [TestClass]
    public class GetGroupsTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients\\Groups\\httpCalls\\list_200.json"));

            var groupsClient = GetCKanClient<IGroupsClient>();
            var groups = await groupsClient.GetGroups();

            groups.Should().HaveCount(2);
        }
    }
}
