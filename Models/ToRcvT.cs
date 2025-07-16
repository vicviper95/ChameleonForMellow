using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToRcvT
    {
        public ToRcvT()
        {
            ToRcvDs = new HashSet<ToRcvD>();
        }

        public int ToRcvTId { get; set; }
        public int? NsIntId { get; set; }
        public int ToTId { get; set; }
        public string RcvNo { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public string ExternalId { get; set; }
        public int? GlimpactTId { get; set; }
        public bool? IsValid { get; set; }

        public virtual GlimpactT GlimpactT { get; set; }
        public virtual ToT ToT { get; set; }
        public virtual ICollection<ToRcvD> ToRcvDs { get; set; }
    }
}
