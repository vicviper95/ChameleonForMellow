using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class FcstWkT
    {
        public FcstWkT()
        {
            FcstWkDs = new HashSet<FcstWkD>();
        }

        public int FcstWkTId { get; set; }
        public short FcstMarketId { get; set; }
        public DateTime AddedMonday { get; set; }
        public string FilePath { get; set; }
        public int AddedUserId { get; set; }

        public virtual Employee AddedUser { get; set; }
        public virtual FcstMarket FcstMarket { get; set; }
        public virtual ICollection<FcstWkD> FcstWkDs { get; set; }
    }
}
