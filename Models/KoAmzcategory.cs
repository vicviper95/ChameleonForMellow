using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzcategory
    {
        public KoAmzcategory()
        {
            AmazonBsrs = new HashSet<AmazonBsr>();
            KoAmzsellerRankHistories = new HashSet<KoAmzsellerRankHistory>();
        }

        public long CategoryNodeId { get; set; }
        public string CategoryNode { get; set; }
        public string Classification { get; set; }

        public virtual ICollection<AmazonBsr> AmazonBsrs { get; set; }
        public virtual ICollection<KoAmzsellerRankHistory> KoAmzsellerRankHistories { get; set; }
    }
}
