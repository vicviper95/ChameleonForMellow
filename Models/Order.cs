using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Order
    {
        public Order()
        {
            BpmBols = new HashSet<BpmBol>();
            Cancels = new HashSet<Cancel>();
            OrderDetails = new HashSet<OrderDetail>();
            Rmas = new HashSet<Rma>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerPonumber { get; set; }
        public int MarketPlaceId { get; set; }
        public int EndCustomerId { get; set; }
        public string CustomerIonumber { get; set; }
        public DateTime? ShipWindowStart { get; set; }
        public DateTime? ShipWindowEnd { get; set; }
        public string SageSoNo { get; set; }
        public byte IsExpShipping { get; set; }
        public int ShipViaId { get; set; }
        public DateTime? TimeKoCreated { get; set; }
        public DateTime? TimeSoCreated { get; set; }
        public DateTime? TimeAccepted { get; set; }
        public string SageInvNo { get; set; }
        public DateTime? TimeInvoiced { get; set; }
        public DateTime? LastModDateTime { get; set; }
        public DateTime? AddedDateTime { get; set; }
        public string ScacCode { get; set; }
        public string ShipAccount { get; set; }

        public virtual EndCustomer EndCustomer { get; set; }
        public virtual KoMarketPlace MarketPlace { get; set; }
        public virtual ShipVium ShipVia { get; set; }
        public virtual ICollection<BpmBol> BpmBols { get; set; }
        public virtual ICollection<Cancel> Cancels { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Rma> Rmas { get; set; }
    }
}
