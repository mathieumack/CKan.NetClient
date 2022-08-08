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
        /// <returns></returns>
        Task<List<string>> GetOrganizations();
    }
}
