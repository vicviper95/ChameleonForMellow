using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpRecapOpex
    {
        public int SpRecapOpexId { get; set; }
        public DateTime DateFr { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal OpexPercent { get; set; }
    }
}
