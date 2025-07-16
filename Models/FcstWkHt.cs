using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstWkHt
    {
        public FcstWkHt()
        {
            FcsWkHdata = new HashSet<FcsWkHdatum>();
        }

        public int FcstWkHtId { get; set; }
        public short FcstMarketId { get; set; }
        public DateTime? AddedDate { get; set; }
        public int FcstAccountId { get; set; }
        public int FcstNetworkId { get; set; }
        public int ItemNoId { get; set; }

        public virtual FcstAccount FcstAccount { get; set; }
        public virtual FcstMarket FcstMarket { get; set; }
        public virtual FcstNetwork FcstNetwork { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<FcsWkHdatum> FcsWkHdata { get; set; }
    }
}
