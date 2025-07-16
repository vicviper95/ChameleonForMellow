using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class JournalT
    {
        public JournalT()
        {
            JournalDs = new HashSet<JournalD>();
        }

        public int JournalTId { get; set; }
        public int? NsIntId { get; set; }
        public string Tranid { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public string Source { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual ICollection<JournalD> JournalDs { get; set; }
    }
}
