using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AccInvInOutD
    {
        public int AccInvInOutDId { get; set; }
        public int AccInvInOutTId { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int PmEndQty { get; set; }
        public decimal PmEndAmt { get; set; }
        public int CmIbqty { get; set; }
        public decimal CmIbamt { get; set; }
        public int CmObqty { get; set; }
        public decimal CmObamt { get; set; }
        public int CmAdjQty { get; set; }
        public decimal CmAdjAmt { get; set; }
        public int CmEndQty { get; set; }
        public decimal CmEndAmt { get; set; }

        public virtual AccInvInOutT AccInvInOutT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
