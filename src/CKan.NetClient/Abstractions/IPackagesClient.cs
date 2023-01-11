using CKan.NetClient.Clients.Packages.HttpModels;
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
        /// <param name="limit">if given, the list of results will be broken into pages only one page will be returned</param>
        /// <param name="offset">when <paramref name="limit"/> is given, the offset to start</param>
        /// <returns></returns>
        Task<List<string>> GetPackages(int? limit = null, int? offset = null);

        /// <summary>
        /// Get package by identifier
        /// </summary>
        /// <param name="id">package identifier</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> must not be null or empty</exception>
        /// <returns></returns>
        Task<PackageShowDetails> GetPackageById(string id);

        /// <summary>
        /// Get packages by group identifier
        /// </summary>
        /// <param name="id">group identifier</param>
        /// <param name="limit">if given, the list of results will be broken into pages only one page will be returned</param>
        /// <param name="offset">when <paramref name="limit"/> is given, the offset to start</param>
        /// <exception cref="ArgumentNullException"><paramref name="id"/> must not be null or empty</exception>
        /// <returns></returns>
        Task<List<PackageShowDetails>> GetPackagesByGroup(string id, int? limit = null, int? offset = null);
    }
}
