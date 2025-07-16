using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VAllSageOrder
    {
        public DateTime? Orddate { get; set; }
        public string Lastinvnum { get; set; }
        public string Ordnumber { get; set; }
        public string Ponumber { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public decimal? Qty { get; set; }
        public string Shpname { get; set; }
        public string Shpaddr1 { get; set; }
        public string Shpcity { get; set; }
        public string Shpstate { get; set; }
    }
}
