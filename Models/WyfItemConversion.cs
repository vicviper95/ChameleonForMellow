using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WyfItemConversion
    {
        public int WyfSkuId { get; set; }
        public string WyfSkuname { get; set; }
        public int? ItemNoId { get; set; }

        public virtual KoItemno ItemNo { get; set; }
    }
}
