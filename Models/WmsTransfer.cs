using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WmsTransfer
    {
        public WmsTransfer()
        {
            WmsTransferDetails = new HashSet<WmsTransferDetail>();
        }

        public int TransferId { get; set; }
        public int FromLocationId { get; set; }
        public int ToLocationId { get; set; }
        public DateTime TimeOrdered { get; set; }
        public int? RequesterId { get; set; }
        public DateTime? TimeEta { get; set; }
        public string TransferNo { get; set; }
        public string BpmPoNo { get; set; }
        public string SpoNo { get; set; }
        public int? ReceiverId { get; set; }

        public virtual KoLocation FromLocation { get; set; }
        public virtual Employee Receiver { get; set; }
        public virtual Employee Requester { get; set; }
        public virtual KoLocation ToLocation { get; set; }
        public virtual ICollection<WmsTransferDetail> WmsTransferDetails { get; set; }
    }
}
