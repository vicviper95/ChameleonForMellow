using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillOfMaterial
    {
        public int BoMId { get; set; }
        public int ParentItemId { get; set; }
        public int ChildItemId { get; set; }
        public int KittingQty { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? NsIntId { get; set; }

        public virtual KoItemno ChildItem { get; set; }
        public virtual KoItemno ParentItem { get; set; }
    }
}
