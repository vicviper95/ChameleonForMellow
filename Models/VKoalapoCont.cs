using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VKoalapoCont
    {
        public string Ponumber { get; set; }
        public string Vendor { get; set; }
        public DateTime? Etdsage { get; set; }
        public string Location { get; set; }
        public string Itemno { get; set; }
        public int? QtyOrdered { get; set; }
        public int? QtyOutstand { get; set; }
        public int? QtyContainer { get; set; }
        public DateTime? BolEtd { get; set; }
        public DateTime? BolEta { get; set; }
    }
}
