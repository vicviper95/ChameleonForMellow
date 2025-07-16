using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpcPayType
    {
        public SpcPayType()
        {
            SpcInvDs = new HashSet<SpcInvD>();
        }

        public int PayTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
    }
}
