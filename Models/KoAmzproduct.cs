using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzproduct
    {
        public string Asin { get; set; }
        public int? ItemNoId { get; set; }
        public byte IsGettingPrice { get; set; }
        public byte IsGettingRank { get; set; }

        public virtual KoItemno ItemNo { get; set; }
    }
}
