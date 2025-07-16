using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VReceivedPo
    {
        public string Ponumber { get; set; }
        public DateTime? Postdate { get; set; }
        public string Vdcode { get; set; }
        public string Itemno { get; set; }
        public decimal Qtyrecvd { get; set; }
        public DateTime? Dtarrival { get; set; }
        public string Loc { get; set; }
    }
}
