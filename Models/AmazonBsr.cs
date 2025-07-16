using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmazonBsr
    {
        public int BsrId { get; set; }
        public DateTime RankDate { get; set; }
        public string Asin { get; set; }
        public int IcrId { get; set; }
        public long CatNodeId { get; set; }
        public long Rank { get; set; }
        public string Country { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual KoAmzcategory CatNode { get; set; }
        public virtual MkIcr Icr { get; set; }
    }
}
