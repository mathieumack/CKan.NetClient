using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKan.NetClient.Abstractions
{
    /// <summary>
    /// Client that let you to read and manipulate organizations
    /// </summary>
    public interface IOrganizationsClient
    {
        /// <summary>
        /// Get list of organizations
        /// </summary>
        /// <param name="limit">if given, the list of results will be broken into pages only one page will be returned</param>
        /// <param name="offset">when <paramref name="limit"/> is given, the offset to start</param>
        /// <returns></returns>
        Task<List<string>> GetOrganizations(int? limit = null, int? offset = null);
    }
}
