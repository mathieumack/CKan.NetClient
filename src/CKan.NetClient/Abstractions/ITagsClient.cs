using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKan.NetClient.Abstractions
{
    /// <summary>
    /// Client that let you to read and manipulate tags
    /// </summary>
    public interface ITagsClient
    {
        /// <summary>
        /// Get list of tags
        /// </summary>
        /// <param name="limit">if given, the list of results will be broken into pages only one page will be returned</param>
        /// <param name="offset">when <paramref name="limit"/> is given, the offset to start</param>
        /// <returns></returns>
        Task<List<string>> GetTags(int? limit = null, int? offset = null);
    }
}
