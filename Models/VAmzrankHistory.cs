using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VAmzrankHistory
    {
        public DateTime Date { get; set; }
        public string Itemno { get; set; }
        public string CategoryNode { get; set; }
        public string Classification { get; set; }
        public int SellingRank { get; set; }
    }
}
