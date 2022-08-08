using System.Collections.Generic;

namespace CKan.NetClient.Clients.Organizations.Models
{
    public class OrganizationListResult
    {
        public bool Success { get; set; }

        public List<string> Result { get; set; }
    }
}
