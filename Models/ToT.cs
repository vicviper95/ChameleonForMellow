using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToT
    {
        public ToT()
        {
            EdiTs = new HashSet<EdiT>();
            FreightInvoiceRefs = new HashSet<FreightInvoiceRef>();
            InvtDailyTrxDs = new HashSet<InvtDailyTrxD>();
            ToDs = new HashSet<ToD>();
            ToFfts = new HashSet<ToFft>();
            ToRcvTs = new HashSet<ToRcvT>();
        }

        public int ToTId { get; set; }
        public int? NsIntId { get; set; }
        public string NsToNo { get; set; }
        public string CustRef { get; set; }
        public int ToStatusId { get; set; }
        public int ShipFrId { get; set; }
        public int ShipToId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipEtd { get; set; }
        public DateTime? ShipEta { get; set; }
        public string RecvNo { get; set; }
        public DateTime? RecvDate { get; set; }
        public string BpmPo { get; set; }
        public string NewSpo { get; set; }
        public string Memo { get; set; }
        public string Source { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string ExternalId { get; set; }
        public string TrsfNo { get; set; }
        public bool? IsNeedReceive { get; set; }
        public DateTime? Euld { get; set; }
        public int? PoTId { get; set; }
        public int? ToContainerId { get; set; }
        public string Ifno { get; set; }
        public string TicketNo { get; set; }

        public virtual PoT PoT { get; set; }
        public virtual BpmLocation ShipFr { get; set; }
        public virtual BpmLocation ShipTo { get; set; }
        public virtual ToContainer ToContainer { get; set; }
        public virtual ToStatus ToStatus { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<FreightInvoiceRef> FreightInvoiceRefs { get; set; }
        public virtual ICollection<InvtDailyTrxD> InvtDailyTrxDs { get; set; }
        public virtual ICollection<ToD> ToDs { get; set; }
        public virtual ICollection<ToFft> ToFfts { get; set; }
        public virtual ICollection<ToRcvT> ToRcvTs { get; set; }
    }
}
