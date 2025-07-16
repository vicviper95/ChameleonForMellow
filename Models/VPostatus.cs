using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VPostatus
    {
        public decimal Porhseq { get; set; }
        public decimal? Porlrev { get; set; }
        public decimal Date { get; set; }
        public decimal Audtdate { get; set; }
        public decimal Audttime { get; set; }
        public string Ponumber { get; set; }
        public string Vdcode { get; set; }
        public string Itemno { get; set; }
        public decimal? Oqordered { get; set; }
        public decimal? Oqoutstand { get; set; }
        public decimal? Unitcost { get; set; }
        public string Etd { get; set; }
        public string Location { get; set; }
        public string Shptoloc { get; set; }
    }
}
