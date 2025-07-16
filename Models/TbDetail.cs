using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TbDetail
    {
        public int TbDetailId { get; set; }
        public int TakeBackId { get; set; }
        public int TbItemId { get; set; }
        public int TbQty { get; set; }
        public decimal? TbCostEst { get; set; }
        public decimal? TbCostAct { get; set; }

        public virtual TakeBack TakeBack { get; set; }
        public virtual TbItem TbItem { get; set; }
    }
}
