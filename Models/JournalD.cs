using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class JournalD
    {
        public int JournalDId { get; set; }
        public int? NsIntId { get; set; }
        public int JournalTId { get; set; }
        public int AccountId { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? CreditAmount { get; set; }
        public string Memo { get; set; }

        public virtual GlAccount Account { get; set; }
        public virtual JournalT JournalT { get; set; }
    }
}
