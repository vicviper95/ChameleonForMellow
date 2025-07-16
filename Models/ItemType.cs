using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int ItemTypeId { get; set; }
        public string ItType { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
