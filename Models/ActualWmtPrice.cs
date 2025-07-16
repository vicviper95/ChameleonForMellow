using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ActualWmtPrice
    {
        public int PriceId { get; set; }
        public int ItemNo { get; set; }
        public string CustSku { get; set; }
        public decimal Price { get; set; }
        public int? WmtItemNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime? CeatedTime { get; set; }
        public DateTime? LastModDate { get; set; }
        public int? ItemType { get; set; }
    }
}
