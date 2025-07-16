using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoPackT
    {
        public PoPackT()
        {
            PoPackDs = new HashSet<PoPackD>();
        }

        public int PoPackTId { get; set; }
        public int PoTId { get; set; }
        public string BookKey { get; set; }
        public string ShipKey { get; set; }
        public string PackNo { get; set; }
        public string InvNo { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual PoT PoT { get; set; }
        public virtual ICollection<PoPackD> PoPackDs { get; set; }
    }
}
