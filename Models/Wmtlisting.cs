using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Wmtlisting
    {
        public int ListingId { get; set; }
        public string WmtSku { get; set; }
        public string WmtItemId { get; set; }

        public virtual KoWmtproduct WmtItem { get; set; }
    }
}
