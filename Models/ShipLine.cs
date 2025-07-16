using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ShipLine
    {
        public ShipLine()
        {
            PoBols = new HashSet<PoBol>();
        }

        public int ShipLineId { get; set; }
        public string ShipLineName { get; set; }
        public int? NsIntId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public DateTime? AddedDate { get; set; }
        public string Scac { get; set; }

        public virtual CarrierCharge CarrierCharge { get; set; }
        public virtual ICollection<PoBol> PoBols { get; set; }
    }
}
