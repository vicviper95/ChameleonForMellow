using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmToWayfairIc
    {
        public BpmToWayfairIc()
        {
            As2BpmToPartners = new HashSet<As2BpmToPartner>();
            BpmToWayfairTs = new HashSet<BpmToWayfairT>();
            EdiWayfair846Cs = new HashSet<EdiWayfair846C>();
            EdiWayfair850s = new HashSet<EdiWayfair850>();
            EdiWayfair860s = new HashSet<EdiWayfair860>();
            EdiWayfair870s = new HashSet<EdiWayfair870>();
            EdiWayfair943s = new HashSet<EdiWayfair943>();
            EdiWayfair944s = new HashSet<EdiWayfair944>();
            EdiWayfair945s = new HashSet<EdiWayfair945>();
        }

        public int InterchangeId { get; set; }
        public DateTime IcTime { get; set; }
        public string EdiString { get; set; }
        public string Fgc { get; set; }

        public virtual ICollection<As2BpmToPartner> As2BpmToPartners { get; set; }
        public virtual ICollection<BpmToWayfairT> BpmToWayfairTs { get; set; }
        public virtual ICollection<EdiWayfair846C> EdiWayfair846Cs { get; set; }
        public virtual ICollection<EdiWayfair850> EdiWayfair850s { get; set; }
        public virtual ICollection<EdiWayfair860> EdiWayfair860s { get; set; }
        public virtual ICollection<EdiWayfair870> EdiWayfair870s { get; set; }
        public virtual ICollection<EdiWayfair943> EdiWayfair943s { get; set; }
        public virtual ICollection<EdiWayfair944> EdiWayfair944s { get; set; }
        public virtual ICollection<EdiWayfair945> EdiWayfair945s { get; set; }
    }
}
