using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TbItem
    {
        public TbItem()
        {
            TakeBacks = new HashSet<TakeBack>();
            TbDetails = new HashSet<TbDetail>();
        }

        public int TbItemId { get; set; }
        public string TbItemName { get; set; }
        public string TbItemSize { get; set; }

        public virtual ICollection<TakeBack> TakeBacks { get; set; }
        public virtual ICollection<TbDetail> TbDetails { get; set; }
    }
}
