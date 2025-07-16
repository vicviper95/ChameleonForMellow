using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzChargeBack
    {
        public int ChargeBackId { get; set; }
        public string CbAmzNo { get; set; }
        public int? CbTypeId { get; set; }
        public int? CbSubTypeId { get; set; }
        public int CbQty { get; set; }
        public decimal CbAmount { get; set; }
        public DateTime CbCreatedDate { get; set; }
        public DateTime? CbDisputeByDate { get; set; }
        public int? CbStatusId { get; set; }
        public string PoNo { get; set; }
        public int? OrderTypeId { get; set; }
        public string Asin { get; set; }
        public int? ArnNo { get; set; }
        public DateTime? ArnCreatedDate { get; set; }
        public DateTime? ShipWinowStart { get; set; }
        public DateTime? ShipWinowEnd { get; set; }
        public int? DaysEarly { get; set; }
        public int? DaysLate { get; set; }
        public int? QtyOrdered { get; set; }
        public int? QtyAccepted { get; set; }
        public string ProNo { get; set; }
        public string AmzNotes { get; set; }
        public int? QtySubmit { get; set; }

        public virtual AmzCbStatus CbStatus { get; set; }
        public virtual AmzCbSubType CbSubType { get; set; }
        public virtual AmzCbType CbType { get; set; }
        public virtual AmzOrderType OrderType { get; set; }
    }
}
