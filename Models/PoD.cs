using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoD
    {
        public PoD()
        {
            ContFeeDs = new HashSet<ContFeeD>();
            InventoryAgingDs = new HashSet<InventoryAgingD>();
            InvtCoOs = new HashSet<InvtCoO>();
            LandedCosts = new HashSet<LandedCost>();
            PoBillDs = new HashSet<PoBillD>();
            PoDConts = new HashSet<PoDCont>();
            PoOwnershipDs = new HashSet<PoOwnershipD>();
            PoPackDs = new HashSet<PoPackD>();
            PoRcvDs = new HashSet<PoRcvD>();
            SoCoos = new HashSet<SoCoo>();
            ToDs = new HashSet<ToD>();
            VendorReturnDs = new HashSet<VendorReturnD>();
            WayPoTkDs = new HashSet<WayPoTkD>();
        }

        public int PoDId { get; set; }
        public int? NsLineKey { get; set; }
        public int PoTId { get; set; }
        public int? NsIntId { get; set; }
        public int PoDlineNo { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public decimal UnitCost { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyOwned { get; set; }
        public int QtyShipped { get; set; }
        public int QtyReceived { get; set; }
        public int QtyBilled { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? QtyVirtualRcv { get; set; }
        public DateTime? VirtualRcvDate { get; set; }
        public bool? IsClosed { get; set; }
        public int? SoDId { get; set; }
        public int? PoStatusId { get; set; }
        public string SpInstruction { get; set; }
        public string InternalPoNo { get; set; }
        public long? PrePoId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual PoStatus PoStatus { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual PrePo PrePo { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual ICollection<ContFeeD> ContFeeDs { get; set; }
        public virtual ICollection<InventoryAgingD> InventoryAgingDs { get; set; }
        public virtual ICollection<InvtCoO> InvtCoOs { get; set; }
        public virtual ICollection<LandedCost> LandedCosts { get; set; }
        public virtual ICollection<PoBillD> PoBillDs { get; set; }
        public virtual ICollection<PoDCont> PoDConts { get; set; }
        public virtual ICollection<PoOwnershipD> PoOwnershipDs { get; set; }
        public virtual ICollection<PoPackD> PoPackDs { get; set; }
        public virtual ICollection<PoRcvD> PoRcvDs { get; set; }
        public virtual ICollection<SoCoo> SoCoos { get; set; }
        public virtual ICollection<ToD> ToDs { get; set; }
        public virtual ICollection<VendorReturnD> VendorReturnDs { get; set; }
        public virtual ICollection<WayPoTkD> WayPoTkDs { get; set; }
    }
}
