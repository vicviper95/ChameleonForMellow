using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvtDailyTrxD
    {
        public int InvtDailyTrxDId { get; set; }
        public int InvtDailyTrxTId { get; set; }
        public int TypeId { get; set; }
        public string Ref1 { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public int? PoTId { get; set; }
        public int? ToTId { get; set; }
        public int? SoTId { get; set; }
        public string CustSku { get; set; }
        public bool? IsValid { get; set; }

        public virtual InvtDailyTrxT InvtDailyTrxT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ToT ToT { get; set; }
        public virtual InvtTrxType Type { get; set; }
    }
}
