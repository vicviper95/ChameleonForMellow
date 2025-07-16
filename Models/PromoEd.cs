using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PromoEd
    {
        public int PromoEdId { get; set; }
        public int PromoEtId { get; set; }
        public int ItemNoId { get; set; }
        public decimal? PromoAmt { get; set; }
        public int? PromoQty { get; set; }
        public decimal? RegularPrice { get; set; }
        public int? MfgCodeId { get; set; }
        public decimal? DiscPrice { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual AmzMfgCode MfgCode { get; set; }
        public virtual PromoEt PromoEt { get; set; }
    }
}
