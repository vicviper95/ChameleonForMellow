using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Announcement
    {
        public int AncmntId { get; set; }
        public string ArticleContent { get; set; }
        public int? DeptId { get; set; }
        public bool? IsPublicAncmnt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? LastModifiedBy { get; set; }
        public byte[] LastModifiedTime { get; set; }
        public string Title { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Department Dept { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
    }
}
