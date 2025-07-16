using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdAfcid
    {
        public AdAfcid()
        {
            AdArns = new HashSet<AdArn>();
            AdBols = new HashSet<AdBol>();
            AdOrders = new HashSet<AdOrder>();
            NsOrders = new HashSet<NsOrder>();
            SoDs = new HashSet<SoD>();
        }

        public int AmazonFcId { get; set; }
        public string FcAid { get; set; }
        public string FcName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public DateTime? AddedTime { get; set; }
        public string San { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? CustomerId { get; set; }
        public int? NsIntId { get; set; }
        public DateTime? NsSyncTime { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<AdArn> AdArns { get; set; }
        public virtual ICollection<AdBol> AdBols { get; set; }
        public virtual ICollection<AdOrder> AdOrders { get; set; }
        public virtual ICollection<NsOrder> NsOrders { get; set; }
        public virtual ICollection<SoD> SoDs { get; set; }
    }
}
