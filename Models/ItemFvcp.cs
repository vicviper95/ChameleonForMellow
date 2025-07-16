using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFvcp
    {
        public int ItemFvcpId { get; set; }
        public int ItemNoId { get; set; }
        public int VendorId { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime LastModTime { get; set; }
        public int LastModById { get; set; }
        public bool IsAmazonDi { get; set; }
        public string Memo { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual Employee LastModBy { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
