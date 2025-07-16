using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiT
    {
        public int EdiTsId { get; set; }
        public int? EpIcId { get; set; }
        public int? MyIcId { get; set; }
        public int TsNo { get; set; }
        public byte FgcId { get; set; }
        public string TrStatus { get; set; }
        public bool IsM2p { get; set; }
        public int? SoTId { get; set; }
        public int? CmTId { get; set; }
        public int? IfTId { get; set; }
        public int? InvTId { get; set; }
        public int? PoTId { get; set; }
        public int? ToTId { get; set; }
        public int? RcvTId { get; set; }
        public int? ArnId { get; set; }
        public int? LocId { get; set; }
        public int? InvFeedTId { get; set; }
        public int? ItemNoId { get; set; }
        public int? TplInvRptTId { get; set; }

        public virtual AdArn Arn { get; set; }
        public virtual KoCoT CmT { get; set; }
        public virtual EdiIcP2m EpIc { get; set; }
        public virtual EdiFgc Fgc { get; set; }
        public virtual ItemFft IfT { get; set; }
        public virtual MkInvFeedT InvFeedT { get; set; }
        public virtual InvT InvT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Loc { get; set; }
        public virtual EdiIcM2p MyIc { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual PoRcvT RcvT { get; set; }
        public virtual SoT SoT { get; set; }
        public virtual ToT ToT { get; set; }
        public virtual TplInvRptT TplInvRptT { get; set; }
    }
}
