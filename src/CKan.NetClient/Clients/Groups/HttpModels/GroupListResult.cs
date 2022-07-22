using System.Collections.Generic;

namespace CKan.NetClient.Clients.Groups.Models
{
    public class GroupListResult
    {
        public bool Success { get; set; }

        public List<string> Result { get; set; }
    }
}
