using CKan.NetClient.Clients.Groups.HttpModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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
        /// <param name="limit">if given, the list of results will be broken into pages only one page will be returned</param>
        /// <param name="offset">when <paramref name="limit"/> is given, the offset to start</param>
        /// <returns></returns>
        Task<List<string>> GetGroups(int? limit = null, int? offset = null);

        /// <summary>
        /// Get group details by identifier
        /// </summary>
        /// <param name="id">group identifier</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> must not be null or empty</exception>
        /// <returns></returns>
        Task<GroupShowDetails> GetGroupById(string id);
    }
}
