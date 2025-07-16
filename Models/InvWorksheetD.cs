using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvWorksheetD
    {
        public InvWorksheetD()
        {
            InvtCoOs = new HashSet<InvtCoO>();
        }

        public int InvWorksheetDId { get; set; }
        public int InvWorksheetTId { get; set; }
        public int NsIntId { get; set; }
        public int Line { get; set; }
        public int ItemNoId { get; set; }
        public int LocationId { get; set; }
        public int Qty { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountCredit { get; set; }
        public decimal? AmountDebit { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual InvWorksheetT InvWorksheetT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<InvtCoO> InvtCoOs { get; set; }
    }
}
