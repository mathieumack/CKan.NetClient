using System.Collections.Generic;
using System.Threading.Tasks;

namespace CKan.NetClient.Abstractions
{
    /// <summary>
    /// Client that let you to read and manipulate packages
    /// </summary>
    public interface IPackagesClient
    {
        /// <summary>
        /// Get list of packages
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetPackages();
    }
}
