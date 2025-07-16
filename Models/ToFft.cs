using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToFft
    {
        public ToFft()
        {
            ToFfds = new HashSet<ToFfd>();
        }

        public int ToFftId { get; set; }
        public int? NsIntId { get; set; }
        public string IfNo { get; set; }
        public int ToTId { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }
        public int? GlimpactTId { get; set; }
        public int IfStatusId { get; set; }

        public virtual GlimpactT GlimpactT { get; set; }
        public virtual StatusIf IfStatus { get; set; }
        public virtual ToT ToT { get; set; }
        public virtual ICollection<ToFfd> ToFfds { get; set; }
    }
}
