using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AcctHqCogsRpt
    {
        public int HqCogsRptId { get; set; }
        public DateTime Date { get; set; }
        public string Channel { get; set; }
        public string Sku { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public decimal CoGs { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
