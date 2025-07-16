using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsTransferDetail
    {
        public int TransferLineId { get; set; }
        public int TransferId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyTotal { get; set; }
        public int? QtyReceived { get; set; }
        public string Note { get; set; }
        public DateTime? TimeReceived { get; set; }
        public int? FromBinId { get; set; }
        public int? ToBinId { get; set; }
        public int? QtyPallets { get; set; }
        public int? QtyPerPallet { get; set; }
        public string ContainerNo { get; set; }
        public string SageTrNo { get; set; }
        public int? TransferLineNo { get; set; }

        public virtual WarehouseBin FromBin { get; set; }
        public virtual KoItemno ItemNo { get; set; }
        public virtual WarehouseBin ToBin { get; set; }
        public virtual WmsTransfer Transfer { get; set; }
    }
}
