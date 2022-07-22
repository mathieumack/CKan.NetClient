using CKan.NetClient.Clients.Groups.HttpModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKan.NetClient.Abstractions
{
    /// <summary>
    /// Client that let you to read and manipulate groups
    /// </summary>
    public interface IGroupsClient
    {
        /// <summary>
        /// Get list of groups
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetGroups();

        /// <summary>
        /// Get group details by group name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<GroupShowDetails> GetGroupByName(string name);
    }
}
