using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class MasterSku
    {
        public MasterSku()
        {
            BpmItems = new HashSet<BpmItem>();
        }

        public int MasterSkuId { get; set; }
        public string SkuName { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public int? LastModEmp { get; set; }
        public int? NsIntId { get; set; }

        public virtual ICollection<BpmItem> BpmItems { get; set; }
    }
}
