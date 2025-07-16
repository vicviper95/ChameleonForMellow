using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsCustPn
    {
        public NsCustPn()
        {
            KoAmzvendorRptInvts = new HashSet<KoAmzvendorRptInvt>();
            KoAmzvendorRptSales = new HashSet<KoAmzvendorRptSale>();
        }

        public int CustPnId { get; set; }
        public string MarketPlace { get; set; }
        public string CustAsin { get; set; }
        public int ItemNoId { get; set; }
        public DateTime? AddedTime { get; set; }
        public DateTime? LastModTime { get; set; }
        public int MarketId { get; set; }
        public int? Cat3Id { get; set; }
        public string Cat3 { get; set; }
        public int? IsActive { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual Market Market { get; set; }
        public virtual ICollection<KoAmzvendorRptInvt> KoAmzvendorRptInvts { get; set; }
        public virtual ICollection<KoAmzvendorRptSale> KoAmzvendorRptSales { get; set; }
    }
}
