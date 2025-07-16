using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvTrT
    {
        public InvTrT()
        {
            InvTrDs = new HashSet<InvTrD>();
        }

        public int InvTrTId { get; set; }
        public int NsIntId { get; set; }
        public string Itno { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime LastModDate { get; set; }
        public string PoNo { get; set; }
        public string ContainerNo { get; set; }
        public int? GlimpactTId { get; set; }

        public virtual GlimpactT GlimpactT { get; set; }
        public virtual ICollection<InvTrD> InvTrDs { get; set; }
    }
}
