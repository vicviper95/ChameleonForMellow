using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PortOrigin
    {
        public PortOrigin()
        {
            BolSailDays = new HashSet<BolSailDay>();
            PoBols = new HashSet<PoBol>();
            PoEtaEstimates = new HashSet<PoEtaEstimate>();
            PoTs = new HashSet<PoT>();
            Vendors = new HashSet<Vendor>();
        }

        public int PortOriginId { get; set; }
        public string OriginName { get; set; }
        public int? NsIntId { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public DateTime? AddedDate { get; set; }
        public string PortName { get; set; }
        public bool IsActive { get; set; }
        public string PortCode { get; set; }

        public virtual ICollection<BolSailDay> BolSailDays { get; set; }
        public virtual ICollection<PoBol> PoBols { get; set; }
        public virtual ICollection<PoEtaEstimate> PoEtaEstimates { get; set; }
        public virtual ICollection<PoT> PoTs { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
