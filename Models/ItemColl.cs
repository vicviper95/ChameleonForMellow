using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemColl
    {
        public ItemColl()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int ItemCollId { get; set; }
        public string CollName { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
