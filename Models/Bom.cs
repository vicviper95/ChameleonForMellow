using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Bom
    {
        public int BomId { get; set; }
        public int? NsIntId { get; set; }
        public int ParentItemId { get; set; }
        public int ChildItemId { get; set; }
        public int KittingQty { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public bool? IsFeedable { get; set; }
        public int? LastModifiedBy { get; set; }

        public virtual BpmItem ChildItem { get; set; }
        public virtual BpmItem ParentItem { get; set; }
    }
}
