using System.Collections.Generic;

namespace CKan.NetClient.Clients.Tags.Models
{
    public class TagListResult
    {
        public bool Success { get; set; }

        public List<string> Result { get; set; }
    }
}
