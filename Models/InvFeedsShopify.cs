using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvFeedsShopify
    {
        public long InvFeedsShopifyId { get; set; }
        public int? CustomerId { get; set; }
        public int? NsIcrid { get; set; }
        public string Handle { get; set; }
        public string Title { get; set; }
        public string HsCode { get; set; }
        public string Coo { get; set; }
        public bool? IsFeedable { get; set; }
        public int? ItemNoId { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Sku { get; set; }
        public long? InvFeedsShopifyOption1Id { get; set; }
        public long? InvFeedsShopifyOption2Id { get; set; }
        public long? InvFeedsShopifyOption3Id { get; set; }
        public string Option1Name { get; set; }
        public string Option1Value { get; set; }
        public string Option2Name { get; set; }
        public string Option2Value { get; set; }
        public string Option3Name { get; set; }
        public string Option3Value { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BpmItem ItemNo { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
        public virtual NsIcr NsIcr { get; set; }
    }
}
