using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TableauIncoming
    {
        public string PoNo { get; set; }
        public string Spo { get; set; }
        public string VendorName { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }
        public string Ir { get; set; }
        public DateTime PoDate { get; set; }
        public decimal UnitCost { get; set; }
        public int QtyOrdered { get; set; }
        public int QtyOwned { get; set; }
        public int QtyShipped { get; set; }
        public int QtyReceived { get; set; }
        public DateTime? PoEpcd { get; set; }
        public DateTime? PoEtd { get; set; }
        public DateTime? EtdC { get; set; }
        public DateTime? EtdB { get; set; }
        public DateTime? EtaB { get; set; }
        public string RcvNo { get; set; }
        public DateTime? RcvDate { get; set; }
        public string StatusPo { get; set; }
        public DateTime? DateAvail { get; set; }
        public DateTime? DateLfdPort { get; set; }
        public DateTime? DateLfdEmpty { get; set; }
        public DateTime? DatePrePull { get; set; }
        public DateTime? Pud { get; set; }
        public DateTime? Apd { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateReturned { get; set; }
        public string NsIbsNo { get; set; }
        public string ContainerNo { get; set; }
        public string BoLno { get; set; }
        public string ShipLineName { get; set; }
        public DateTime? PoEta { get; set; }
        public DateTime? DateEstUnload { get; set; }
        public string PoLoc { get; set; }
        public string CtLoc { get; set; }
        public string FLoc { get; set; }
        public string DestName { get; set; }
        public string OriginName { get; set; }
    }
}
