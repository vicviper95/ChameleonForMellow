using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PalletType1
    {
        public PalletType1()
        {
            AdPalletOnBols = new HashSet<AdPalletOnBol>();
        }

        public int PalletTypeId { get; set; }
        public int NoPosition { get; set; }
        public decimal WidthIn { get; set; }
        public decimal LengthIn { get; set; }
        public string Note { get; set; }
        public decimal MaxVolumeCf { get; set; }
        public decimal WeightLb { get; set; }
        public decimal MaxHeightIn { get; set; }

        public virtual ICollection<AdPalletOnBol> AdPalletOnBols { get; set; }
    }
}
