using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CKan.NetClient.Abstractions;
using FluentAssertions;
using System.Net;
using System.IO;

namespace CKan.NetClient.Tests.Clients.Tags
{
    [TestClass]
    public class GetTagsTests : BaseTestsClass
    {
        [TestMethod]
        public async Task NomicalCase()
        {
            LoadServices(HttpStatusCode.Accepted, File.ReadAllText("Clients/Tags/httpCalls/list_200.json"));

            var tagsClient = GetCKanClient<ITagsClient>();
            var tags = await tagsClient.GetTags();

            tags.Should().HaveCount(2);
        }
    }
}
