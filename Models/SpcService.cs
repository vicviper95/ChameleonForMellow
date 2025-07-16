using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpcService
    {
        public SpcService()
        {
            SpcInvDs = new HashSet<SpcInvD>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
    }
}
