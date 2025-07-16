using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoOwnershipT
    {
        public PoOwnershipT()
        {
            PoOwnershipDs = new HashSet<PoOwnershipD>();
            PoRcvTs = new HashSet<PoRcvT>();
        }

        public int PoOwnershipTId { get; set; }
        public int? NsIntId { get; set; }
        public DateTime Date { get; set; }
        public string DocNo { get; set; }
        public int PoTId { get; set; }
        public int ContainerId { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual Container Container { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual ICollection<PoOwnershipD> PoOwnershipDs { get; set; }
        public virtual ICollection<PoRcvT> PoRcvTs { get; set; }
    }
}
