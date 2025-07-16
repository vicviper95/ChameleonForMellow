using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemStatus
    {
        public ItemStatus()
        {
            BpmItems = new HashSet<BpmItem>();
            FcstAvgSqas = new HashSet<FcstAvgSqa>();
            ItemAbcPcs = new HashSet<ItemAbcPc>();
            ItemStatLogs = new HashSet<ItemStatLog>();
            MkIcrs = new HashSet<MkIcr>();
        }

        public int ItemStatusId { get; set; }
        public string StatusItem { get; set; }
        public string StatusNs { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
        public virtual ICollection<FcstAvgSqa> FcstAvgSqas { get; set; }
        public virtual ICollection<ItemAbcPc> ItemAbcPcs { get; set; }
        public virtual ICollection<ItemStatLog> ItemStatLogs { get; set; }
        public virtual ICollection<MkIcr> MkIcrs { get; set; }
    }
}
