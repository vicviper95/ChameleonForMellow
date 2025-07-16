using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemFobHist
    {
        public int ItemFobHistId { get; set; }
        public int ItemNoId { get; set; }
        public int VendorId { get; set; }
        public int? CountryFrId { get; set; }
        public int CountryToId { get; set; }
        public decimal FobCost { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int TotalPoCount { get; set; }
        public int TotalPoQty { get; set; }
        public int EmployeeId { get; set; }

        public virtual Country CountryFr { get; set; }
        public virtual Country CountryTo { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
