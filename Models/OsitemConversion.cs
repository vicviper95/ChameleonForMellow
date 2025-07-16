using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class OsitemConversion
    {
        public int OsSkuId { get; set; }
        public string OsSkuname { get; set; }
        public int? ItemNoId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
    }
}
