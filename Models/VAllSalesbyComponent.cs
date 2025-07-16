using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VAllSalesbyComponent
    {
        public DateTime? Invdate { get; set; }
        public string Invnumber { get; set; }
        public string Ordnumber { get; set; }
        public string Customer { get; set; }
        public string Ponumber { get; set; }
        public string Category { get; set; }
        public byte? IsKitting { get; set; }
        public string Item { get; set; }
        public decimal? Qty { get; set; }
        public string Shpcity { get; set; }
        public string Shpstate { get; set; }
        public string Shpzip { get; set; }
        public string Shipvia { get; set; }
        public string CdDesc { get; set; }
        public string Loc { get; set; }
    }
}
