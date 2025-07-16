using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoCoT
    {
        public KoCoT()
        {
            EdiTs = new HashSet<EdiT>();
            KoCoDs = new HashSet<KoCoD>();
        }

        public int KoCoTId { get; set; }
        public int SoTId { get; set; }
        public string PoNo { get; set; }
        public DateTime AddedDate { get; set; }
        public string CustRef { get; set; }

        public virtual SoT SoT { get; set; }
        public virtual ICollection<EdiT> EdiTs { get; set; }
        public virtual ICollection<KoCoD> KoCoDs { get; set; }
    }
}
