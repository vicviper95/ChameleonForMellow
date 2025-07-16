using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitCmD
    {
        public int RemitCmDId { get; set; }
        public int RemitCmTId { get; set; }
        public int? NsIntId { get; set; }
        public int? RemitCmId { get; set; }
        public int? RemitClaimId { get; set; }
        public int? RemitFeeId { get; set; }
        public int? RemitServiceId { get; set; }
        public int? SoDId { get; set; }
        public int? ItemNoId { get; set; }
        public int RemitItemId { get; set; }
        public int? LineNo { get; set; }
        public int Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int? SoTId { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual RemitClaim RemitClaim { get; set; }
        public virtual RemitCm RemitCm { get; set; }
        public virtual RemitCmT RemitCmT { get; set; }
        public virtual RemitFee RemitFee { get; set; }
        public virtual BpmItem RemitItem { get; set; }
        public virtual RemitService RemitService { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
