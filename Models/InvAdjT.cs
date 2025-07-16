using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvAdjT
    {
        public InvAdjT()
        {
            InvAdjDs = new HashSet<InvAdjD>();
        }

        public int InvAdjTId { get; set; }
        public int NsIntId { get; set; }
        public string Iano { get; set; }
        public int? CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModDate { get; set; }
        public int? GlimpactTId { get; set; }
        public bool IsCgbackordered { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual GlimpactT GlimpactT { get; set; }
        public virtual ICollection<InvAdjD> InvAdjDs { get; set; }
    }
}
