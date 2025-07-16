using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoPossiblePo
    {
        public int PossBpmPoId { get; set; }
        public int? Year { get; set; }
        public int? WkNum { get; set; }
        public string ItemNo { get; set; }
        public int? Qty { get; set; }

        public virtual KoItemno ItemNoNavigation { get; set; }
    }
}
