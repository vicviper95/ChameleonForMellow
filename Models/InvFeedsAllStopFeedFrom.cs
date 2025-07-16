using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsAllStopFeedFrom
    {
        public int InvFeedsAllStopFeedFromId { get; set; }
        public string Title { get; set; }
        public bool? IsActivated { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MasterWarehouse { get; set; }
        public int? BackUpWarehouse01 { get; set; }
        public int? BackUpWarehouse02 { get; set; }
        public int? BackUpWarehouse03 { get; set; }
        public int? CrossOverQtyMtoB01 { get; set; }
        public int? CrossOverQtyB01toB02 { get; set; }
        public int? CrossOverQtyB02toB03 { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
