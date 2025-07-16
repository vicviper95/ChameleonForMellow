using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WarehouseBin
    {
        public WarehouseBin()
        {
            WmsAdjustDetails = new HashSet<WmsAdjustDetail>();
            WmsCycleCounts = new HashSet<WmsCycleCount>();
            WmsInventoryQoHs = new HashSet<WmsInventoryQoH>();
            WmsPoDetails = new HashSet<WmsPoDetail>();
            WmsRmaDetails = new HashSet<WmsRmaDetail>();
            WmsSoDetails = new HashSet<WmsSoDetail>();
            WmsTransferDetailFromBins = new HashSet<WmsTransferDetail>();
            WmsTransferDetailToBins = new HashSet<WmsTransferDetail>();
        }

        public int BinId { get; set; }
        public string BinNo { get; set; }
        public int LocationId { get; set; }
        public int PalletPerBin { get; set; }

        public virtual KoLocation Location { get; set; }
        public virtual ICollection<WmsAdjustDetail> WmsAdjustDetails { get; set; }
        public virtual ICollection<WmsCycleCount> WmsCycleCounts { get; set; }
        public virtual ICollection<WmsInventoryQoH> WmsInventoryQoHs { get; set; }
        public virtual ICollection<WmsPoDetail> WmsPoDetails { get; set; }
        public virtual ICollection<WmsRmaDetail> WmsRmaDetails { get; set; }
        public virtual ICollection<WmsSoDetail> WmsSoDetails { get; set; }
        public virtual ICollection<WmsTransferDetail> WmsTransferDetailFromBins { get; set; }
        public virtual ICollection<WmsTransferDetail> WmsTransferDetailToBins { get; set; }
    }
}
