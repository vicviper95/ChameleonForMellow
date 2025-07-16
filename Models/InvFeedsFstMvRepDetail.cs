using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsFstMvRepDetail
    {
        public int FstMvRepDetailId { get; set; }
        public int? FstMvSkusRepId { get; set; }
        public int? ItemNoId { get; set; }
        public string ItemName { get; set; }
        public int? MainslQty { get; set; }
        public int? MainslStagePoqty { get; set; }
        public int? ZinusTracyQty { get; set; }
        public int? ZinusTracyStagePoqty { get; set; }
        public int? ZinusChsQty { get; set; }
        public int? ZinusChsStagePoqty { get; set; }
        public int? TotalQty { get; set; }
        public int? TotalStagePoqty { get; set; }
        public int? SoldQtyOfPast7Days { get; set; }
        public bool? IsIncludedInNotification { get; set; }

        public virtual InvFeedsFstMvSkusReport FstMvSkusRep { get; set; }
    }
}
