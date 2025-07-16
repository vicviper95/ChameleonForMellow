using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RemitInvD
    {
        public int RemitInvDId { get; set; }
        public int RemitInvTId { get; set; }
        public int? NsIntId { get; set; }
        public int? RemitInvId { get; set; }
        public int? RemitClaimId { get; set; }
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
        public virtual RemitInv RemitInv { get; set; }
        public virtual RemitInvT RemitInvT { get; set; }
        public virtual BpmItem RemitItem { get; set; }
        public virtual RemitService RemitService { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
