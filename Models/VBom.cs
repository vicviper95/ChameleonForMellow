using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VBom
    {
        public string Parent { get; set; }
        public int? ParentId { get; set; }
        public string Child { get; set; }
        public int? ChildId { get; set; }
        public int KittingQty { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
    }
}
