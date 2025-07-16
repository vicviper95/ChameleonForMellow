using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TbStatus
    {
        public TbStatus()
        {
            TakeBacks = new HashSet<TakeBack>();
        }

        public int TbStatusId { get; set; }
        public string StatusTb { get; set; }

        public virtual ICollection<TakeBack> TakeBacks { get; set; }
    }
}
