using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemMdFob
    {
        public int ItemMdFobId { get; set; }
        public int ItemNoId { get; set; }
        public int VendorId { get; set; }
        public int? CountryFrId { get; set; }
        public int CountryToId { get; set; }
        public decimal FobCost { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsAmzDi { get; set; }
        public string VendorCode { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public string Note { get; set; }

        public virtual Country CountryFr { get; set; }
        public virtual Country CountryTo { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
