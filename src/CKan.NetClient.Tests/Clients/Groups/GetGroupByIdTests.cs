using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System;
using System.Net;
using System.IO;

namespace CKan.NetClient.Tests.Clients.Groups
{
    [TestClass]
    public class GetGroupByIdTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Groups/httpCalls/byId_200.json"));

            var groupsClient = GetCKanClient<IGroupsClient>();
            var groupDetails = await groupsClient.GetGroupById("sample");

            groupDetails.Id.Should().Be("d3f4879f-8628-44d1-8a6d-d250fbdac37f");
            groupDetails.DisplayName.Should().Be("Sample group");
            groupDetails.Title.Should().Be("Sample");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task InvalidIdentifier()
        {
            LoadServices(HttpStatusCode.Accepted, "{ }");

            var groupsClient = GetCKanClient<IGroupsClient>();
            await groupsClient.GetGroupById(null);
        }
    }
}
