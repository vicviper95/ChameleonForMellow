using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Market
    {
        public Market()
        {
            CmOrigins = new HashSet<CmOrigin>();
            CsFeeInvTs = new HashSet<CsFeeInvT>();
            CustLocCodes = new HashSet<CustLocCode>();
            Customers = new HashSet<Customer>();
            Edipartners = new HashSet<Edipartner>();
            MarketMasterSkus = new HashSet<MarketMasterSku>();
            MkIcrs = new HashSet<MkIcr>();
            NsCustPns = new HashSet<NsCustPn>();
            RemitMatchClaims = new HashSet<RemitMatchClaim>();
            SalesRemits = new HashSet<SalesRemit>();
        }

        public int MarketId { get; set; }
        public string MarketPlace { get; set; }
        public int? NsIntId { get; set; }
        public short? FcstMarketId { get; set; }

        public virtual ICollection<CmOrigin> CmOrigins { get; set; }
        public virtual ICollection<CsFeeInvT> CsFeeInvTs { get; set; }
        public virtual ICollection<CustLocCode> CustLocCodes { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Edipartner> Edipartners { get; set; }
        public virtual ICollection<MarketMasterSku> MarketMasterSkus { get; set; }
        public virtual ICollection<MkIcr> MkIcrs { get; set; }
        public virtual ICollection<NsCustPn> NsCustPns { get; set; }
        public virtual ICollection<RemitMatchClaim> RemitMatchClaims { get; set; }
        public virtual ICollection<SalesRemit> SalesRemits { get; set; }
    }
}
