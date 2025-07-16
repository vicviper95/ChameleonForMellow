using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class CrdT
    {
        public CrdT()
        {
            CrdDs = new HashSet<CrdD>();
        }

        public int CrdTId { get; set; }
        public int? NsIntId { get; set; }
        public string CrdNo { get; set; }
        public DateTime CrdDate { get; set; }
        public decimal CrdTotal { get; set; }
        public int? CustomerId { get; set; }
        public string Memo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }

        public virtual ICollection<CrdD> CrdDs { get; set; }
    }
}
