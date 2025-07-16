using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WfsInvtHist
    {
        public int InvtLogHisId { get; set; }
        public int InvtLogId { get; set; }
        public string ShipmentId { get; set; }
        public int? ChangedUnits { get; set; }
        public int? TransactionTypeId { get; set; }
        public string TransactionReasonDesc { get; set; }
        public int? TransactionReasonCodeId { get; set; }
        public int? TransactionLocationId { get; set; }
        public string TransactionId { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime? TransactionTime { get; set; }
        public string FcName { get; set; }
        public string FcId { get; set; }
        public int? LocationId { get; set; }

        public virtual WfsInvtLog InvtLog { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual TransactionLocation TransactionLocation { get; set; }
        public virtual TransactionReasonCode TransactionReasonCode { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
