using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FobCostTrack
    {
        public int FobCostId { get; set; }
        public int? ItemNoId { get; set; }
        public int VendorId { get; set; }
        public int CoOId { get; set; }
        public int IncoTermId { get; set; }
        public decimal? FobAvg { get; set; }
        public decimal? FobLastPo { get; set; }
        public decimal FobCurr { get; set; }
        public decimal DutyRate { get; set; }
        public decimal GspRate { get; set; }
        public decimal TariffRate { get; set; }
        public decimal? FobTotal { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public int LastModEId { get; set; }

        public virtual FobCountry CoO { get; set; }
        public virtual FobIncoTerm IncoTerm { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
