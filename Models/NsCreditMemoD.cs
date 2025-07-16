using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsCreditMemoD
    {
        public int NsCreditMemoDId { get; set; }
        public int NsCreditMemoTId { get; set; }
        public int NsIntId { get; set; }
        public int LineId { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public int GlaccountId { get; set; }

        public virtual GlAccount Glaccount { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual NsCreditMemoT NsCreditMemoT { get; set; }
    }
}
