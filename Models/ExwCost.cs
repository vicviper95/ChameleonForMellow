using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ExwCost
    {
        public int ExwCostId { get; set; }
        public decimal OceanCost { get; set; }
        public decimal StrCostPerCf { get; set; }
        public decimal WhouseExp { get; set; }
        public decimal StrageIr { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime AddedDate { get; set; }
        public int? ModByWoId { get; set; }

        public virtual Employee ModByWo { get; set; }
    }
}
