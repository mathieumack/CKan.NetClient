using System;
using System.Collections.Generic;
using System.Text;

namespace CKan.NetClient.Clients.Groups.HttpModels
{
    public class GroupShowResult
    {
        public bool Success { get; set; }

        public GroupShowDetails Result { get; set; }
    }
}
