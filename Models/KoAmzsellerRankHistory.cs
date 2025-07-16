using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoAmzsellerRankHistory
    {
        public DateTime Date { get; set; }
        public string Asin { get; set; }
        public long CategoryNodeId { get; set; }
        public int SellingRank { get; set; }
        public int CountryId { get; set; }

        public virtual KoAmzcategory CategoryNode { get; set; }
        public virtual Country Country { get; set; }
    }
}
