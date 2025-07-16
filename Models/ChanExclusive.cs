using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ChanExclusive
    {
        public ChanExclusive()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int ChanExclusiveId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
