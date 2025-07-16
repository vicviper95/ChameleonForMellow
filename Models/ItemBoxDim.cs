using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemBoxDim
    {
        public int ItemBoxDimId { get; set; }
        public int ItemNoId { get; set; }
        public int? VendorId { get; set; }
        public decimal BoxLength { get; set; }
        public decimal BoxWidth { get; set; }
        public decimal BoxHeight { get; set; }
        public decimal BoxWeight { get; set; }
        public decimal BoxVolCf { get; set; }
        public decimal BoxVolCm { get; set; }
        public int QtyHq40 { get; set; }
        public decimal BoxGirth { get; set; }
        public decimal BoxDimWgt { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
