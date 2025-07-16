using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToD
    {
        public ToD()
        {
            ContFeeDs = new HashSet<ContFeeD>();
            LandedCosts = new HashSet<LandedCost>();
            ToFfds = new HashSet<ToFfd>();
            ToRcvDs = new HashSet<ToRcvD>();
        }

        public int ToDId { get; set; }
        public int ToTId { get; set; }
        public int LineNo { get; set; }
        public int? ShipLineNo { get; set; }
        public int? RecvLineNo { get; set; }
        public string CustSku { get; set; }
        public int ItemNoId { get; set; }
        public decimal? UnitCost { get; set; }
        public int QtyOrder { get; set; }
        public int QtyShipped { get; set; }
        public int QtyReceived { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModTime { get; set; }
        public int? PoDId { get; set; }
        public int QtyCommitted { get; set; }
        public decimal? TransportationCost { get; set; }
        public string InvNoForTransCost { get; set; }
        public DateTime? InvDateForTransCost { get; set; }
        public decimal? PickPackCost { get; set; }
        public string InvNoForPickPackCost { get; set; }
        public DateTime? InvDateForPickPackCost { get; set; }
        public int? NsIntId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual PoD PoD { get; set; }
        public virtual ToT ToT { get; set; }
        public virtual ICollection<ContFeeD> ContFeeDs { get; set; }
        public virtual ICollection<LandedCost> LandedCosts { get; set; }
        public virtual ICollection<ToFfd> ToFfds { get; set; }
        public virtual ICollection<ToRcvD> ToRcvDs { get; set; }
    }
}
