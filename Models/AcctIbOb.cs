using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AcctIbOb
    {
        public int AcctIbObId { get; set; }
        public DateTime CmDate { get; set; }
        public int ItemNoId { get; set; }
        public int PmEndQty { get; set; }
        public int CmIbqty { get; set; }
        public decimal PmEndAmt { get; set; }
        public int CmObqty { get; set; }
        public decimal CmObamt { get; set; }
        public int CmAdjQty { get; set; }
        public decimal CmAdjAmt { get; set; }
        public int CmEndQty { get; set; }
        public decimal CmEndAmt { get; set; }
        public decimal CmIbamt { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
