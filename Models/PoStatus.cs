using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoStatus
    {
        public PoStatus()
        {
            PoDs = new HashSet<PoD>();
            PoTs = new HashSet<PoT>();
        }

        public int PoStatusId { get; set; }
        public string StatusPo { get; set; }

        public virtual ICollection<PoD> PoDs { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
    }
}
