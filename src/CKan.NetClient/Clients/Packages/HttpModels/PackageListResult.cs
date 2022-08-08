using System.Collections.Generic;

namespace CKan.NetClient.Clients.Packages.Models
{
    public class PackageListResult
    {
        public bool Success { get; set; }

        public List<string> Result { get; set; }
    }
}
