using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Container
    {
        public Container()
        {
            DrayageFeeDs = new HashSet<DrayageFeeD>();
            PoDConts = new HashSet<PoDCont>();
            PoOwnershipTs = new HashSet<PoOwnershipT>();
            PoRcvTs = new HashSet<PoRcvT>();
        }

        public int ContainerId { get; set; }
        public int? NsIntId { get; set; }
        public string NsIbsNo { get; set; }
        public string ContainerNo { get; set; }
        public int PoBoLId { get; set; }
        public int? LocationId { get; set; }
        public int? ContStatusId { get; set; }
        public DateTime? DateAvail { get; set; }
        public DateTime? DateLfdPort { get; set; }
        public DateTime? DateLfdEmpty { get; set; }
        public DateTime? DatePrePull { get; set; }
        public DateTime? DatePkUpPlan { get; set; }
        public DateTime? DatePkUpAct { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateReturned { get; set; }
        public string UnloadPriority { get; set; }
        public int? TransporterId { get; set; }
        public string Memo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? LastModKoT { get; set; }
        public int? LastModKoE { get; set; }
        public string BolNo { get; set; }
        public DateTime? DateGated { get; set; }
        public DateTime? DateReturnPlan { get; set; }
        public DateTime? DateArrivalNoti { get; set; }
        public bool? IsReviewDone { get; set; }
        public bool? IsInTransitReview { get; set; }

        public virtual ContStatus ContStatus { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual PoBol PoBoL { get; set; }
        public virtual Transporter Transporter { get; set; }
        public virtual ICollection<DrayageFeeD> DrayageFeeDs { get; set; }
        public virtual ICollection<PoDCont> PoDConts { get; set; }
        public virtual ICollection<PoOwnershipT> PoOwnershipTs { get; set; }
        public virtual ICollection<PoRcvT> PoRcvTs { get; set; }
    }
}
