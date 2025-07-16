using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmSkuStatus
    {
        public int StatusId { get; set; }
        public DateTime UploadDate { get; set; }
        public string Item { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Note2 { get; set; }
        public DateTime? AmzLaunchDate { get; set; }
    }
}
