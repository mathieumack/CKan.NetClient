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
        /// <returns></returns>
        Task<List<string>> GetTags();
    }
}
