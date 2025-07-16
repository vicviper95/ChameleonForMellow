using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VCog
    {
        public DateTime? Invdate { get; set; }
        public string Ponumber { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public string Cat { get; set; }
        public decimal? Qtyshipped { get; set; }
        public decimal? Exticost { get; set; }
    }
}
