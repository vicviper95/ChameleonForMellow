using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoWmtproduct
    {
        public KoWmtproduct()
        {
            Wmtlistings = new HashSet<Wmtlisting>();
        }

        public string WmtItemId { get; set; }
        public int? ItemNoId { get; set; }
        public byte IsGettingPrice { get; set; }

        public virtual KoItemno ItemNo { get; set; }
        public virtual ICollection<Wmtlisting> Wmtlistings { get; set; }
    }
}
