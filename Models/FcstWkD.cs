using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstWkD
    {
        public FcstWkD()
        {
            FcstWkData = new HashSet<FcstWkDatum>();
        }

        public int FcstWkDId { get; set; }
        public int FcstWkTId { get; set; }
        public int FcstAccountId { get; set; }
        public int FcstNetworkId { get; set; }
        public int ItemNoId { get; set; }
        public int? BaseLineQty { get; set; }
        public string Note { get; set; }

        public virtual FcstAccount FcstAccount { get; set; }
        public virtual FcstNetwork FcstNetwork { get; set; }
        public virtual FcstWkT FcstWkT { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual ICollection<FcstWkDatum> FcstWkData { get; set; }
    }
}
