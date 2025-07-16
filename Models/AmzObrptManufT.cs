using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzObrptManufT
    {
        public AmzObrptManufT()
        {
            AmzObmthlyRptManufInvDs = new HashSet<AmzObmthlyRptManufInvD>();
            AmzObmthlyRptManufSalesDs = new HashSet<AmzObmthlyRptManufSalesD>();
            AmzObmthlyRptNetppmDs = new HashSet<AmzObmthlyRptNetppmD>();
        }

        public int RptManufTId { get; set; }
        public DateTime DateStart { get; set; }
        public int AddedUserId { get; set; }
        public bool? IsWeely { get; set; }
        public bool IsYearly { get; set; }
        public bool IsManuf { get; set; }

        public virtual ICollection<AmzObmthlyRptManufInvD> AmzObmthlyRptManufInvDs { get; set; }
        public virtual ICollection<AmzObmthlyRptManufSalesD> AmzObmthlyRptManufSalesDs { get; set; }
        public virtual ICollection<AmzObmthlyRptNetppmD> AmzObmthlyRptNetppmDs { get; set; }
    }
}
