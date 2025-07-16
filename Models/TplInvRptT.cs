using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplInvRptT
    {
        public TplInvRptT()
        {
            EdiTs = new HashSet<EdiT>();
            TplInvRptDs = new HashSet<TplInvRptD>();
        }

        public int TplInvRptTId { get; set; }
        public DateTime ReportTime { get; set; }
        public int LocationId { get; set; }
        public string ReportId { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<TplInvRptD> TplInvRptDs { get; set; }
    }
}
