using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObForecasting
    {
        public AmzObForecasting()
        {
            AmzObFcstDs = new HashSet<AmzObFcstD>();
        }

        public int FcstId { get; set; }
        public int RptId { get; set; }
        public int IcrId { get; set; }
        public string Asin { get; set; }
        public int ProbLevel { get; set; }
        public int StartWkNo { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime LastModTime { get; set; }

        public virtual MkIcr Icr { get; set; }
        public virtual AmzObRptT Rpt { get; set; }
        public virtual ICollection<AmzObFcstD> AmzObFcstDs { get; set; }
    }
}
