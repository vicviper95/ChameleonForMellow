using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillCreditD
    {
        public int BillCreditDId { get; set; }
        public int BillCreditTId { get; set; }
        public int? NsIntId { get; set; }
        public int AccountId { get; set; }
        public decimal? Amount { get; set; }
        public string Memo { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual BillCreditT BillCreditT { get; set; }
    }
}
