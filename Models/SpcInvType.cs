using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpcInvType
    {
        public SpcInvType()
        {
            SpcInvDs = new HashSet<SpcInvD>();
        }

        public int InvTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
    }
}
