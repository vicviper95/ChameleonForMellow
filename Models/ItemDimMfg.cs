using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemDimMfg
    {
        public int ItemDimMfgId { get; set; }
        public int ItemNoId { get; set; }
        public decimal CartonLength { get; set; }
        public decimal CartonWidth { get; set; }
        public decimal CartonHeight { get; set; }
        public decimal CartonWeight { get; set; }
        public DateTime AddedTime { get; set; }

        public virtual BpmItem ItemNo { get; set; }
    }
}
