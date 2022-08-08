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
    public class GetGroupBynameTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Groups/httpCalls/byName_200.json"));

            var groupsClient = GetCKanClient<IGroupsClient>();
            var groupDetails = await groupsClient.GetGroupByName("sample");

            groupDetails.Id.Should().Be(Guid.Parse("d3f4879f-8628-44d1-8a6d-d250fbdac37f"));
            groupDetails.DisplayName.Should().Be("Sample group");
            groupDetails.Title.Should().Be("Sample");
        }
    }
}
