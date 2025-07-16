using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Bookmark
    {
        public long BookmarkId { get; set; }
        public int? DeptEmployeeId { get; set; }
        public bool? IsDept { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }
}
