using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TbCost
    {
        public int TbCostId { get; set; }
        public int TakeBackerId { get; set; }
        public string TbCostSize { get; set; }
        public decimal? TbCostSingle { get; set; }
        public decimal? TbCostSet { get; set; }

        public virtual TakeBacker TakeBacker { get; set; }
    }
}
