using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Rma
    {
        public Rma()
        {
            RmaDetails = new HashSet<RmaDetail>();
        }

        public int RmaId { get; set; }
        public int OrderId { get; set; }
        public DateTime DateRequested { get; set; }
        public int SalesRepId { get; set; }
        public string Note { get; set; }
        public DateTime? DateRefunded { get; set; }
        public int RmaReasonId { get; set; }
        public int RmaActionId { get; set; }
        public int RmaStatusId { get; set; }
        public DateTime? DateApproved { get; set; }
        public string SageCreditNoteNo { get; set; }
        public int RmaReasonDetailId { get; set; }
        public string MasterTrackNoReturn { get; set; }
        public string MasterTrackNoReplace { get; set; }
        public string SageInternalUseNo { get; set; }
        public DateTime? DateReturned { get; set; }
        public DateTime? DateReplaced { get; set; }

        public virtual Order Order { get; set; }
        public virtual RmaAction RmaAction { get; set; }
        public virtual RmaReason RmaReason { get; set; }
        public virtual RmaReasonDetail RmaReasonDetail { get; set; }
        public virtual RmaStatus RmaStatus { get; set; }
        public virtual Employee SalesRep { get; set; }
        public virtual ICollection<RmaDetail> RmaDetails { get; set; }
    }
}
