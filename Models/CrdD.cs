using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CrdD
    {
        public int CrdDId { get; set; }
        public int CrdTId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public DateTime AddedTime { get; set; }
        public int? InvTId { get; set; }
        public bool? IsCredit { get; set; }
        public string InvNo { get; set; }
        public int? ItemNoId { get; set; }
        public string Description { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual CrdT CrdT { get; set; }
        public virtual InvT InvT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
