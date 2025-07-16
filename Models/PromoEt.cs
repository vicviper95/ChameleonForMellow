using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PromoEt
    {
        public PromoEt()
        {
            PromoEds = new HashSet<PromoEd>();
        }

        public int PromoEtId { get; set; }
        public int CustomerId { get; set; }
        public string PromoId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string PromoName { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<PromoEd> PromoEds { get; set; }
    }
}
