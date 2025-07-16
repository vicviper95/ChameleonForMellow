using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoSoD
    {
        public int KoSoDId { get; set; }
        public int KoSoTId { get; set; }
        public int? KoLineNo { get; set; }
        public int ShipFromWhId { get; set; }
        public string CustSku { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOrdered { get; set; }
        public decimal UnitPrice { get; set; }
        public string DiscCode { get; set; }
        public decimal? DiscAmt { get; set; }
        public decimal? VatAmt { get; set; }
        public decimal? FeeAmt { get; set; }
        public decimal? ShipAmt { get; set; }
        public int ShipViaId { get; set; }
        public int ApplyDbst { get; set; }
        public int? OrderStatusId { get; set; }
        public string MemoLine { get; set; }
        public string ShipScac { get; set; }
        public DateTime LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual KoSoT KoSoT { get; set; }
        public virtual SoStatusKo OrderStatus { get; set; }
        public virtual BpmLocation ShipFromWh { get; set; }
        public virtual ShipVium ShipVia { get; set; }
    }
}
