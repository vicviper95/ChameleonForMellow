using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TutorialClient
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int BranchId { get; set; }
    }
}
