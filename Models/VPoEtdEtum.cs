using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VPoEtdEtum
    {
        public string Ponumber { get; set; }
        public string Vdcode { get; set; }
        public string Location { get; set; }
        public string Itemno { get; set; }
        public decimal? Oqoutstand { get; set; }
        public string SageEtd { get; set; }
        public DateTime? KoEtd { get; set; }
        public DateTime? BolEtd { get; set; }
        public DateTime? SageEta { get; set; }
        public DateTime? BolEta { get; set; }
    }
}
