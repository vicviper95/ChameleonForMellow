using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AmzMfgCode
    {
        public AmzMfgCode()
        {
            PromoEds = new HashSet<PromoEd>();
        }

        public int MfgCodeId { get; set; }
        public string MfgCode { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<PromoEd> PromoEds { get; set; }
    }
}
