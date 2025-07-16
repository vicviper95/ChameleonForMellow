using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VendorReturnT
    {
        public VendorReturnT()
        {
            VendorReturnDs = new HashSet<VendorReturnD>();
        }

        public int VendorReturnTId { get; set; }
        public int NsIntId { get; set; }
        public int? PoTId { get; set; }
        public string DocNo { get; set; }
        public DateTime Date { get; set; }
        public int VrstatusId { get; set; }
        public string Memo { get; set; }
        public DateTime AddedTime { get; set; }
        public int? PoBillTId { get; set; }

        public virtual PoBillT PoBillT { get; set; }
        public virtual PoT PoT { get; set; }
        public virtual Vrstatus Vrstatus { get; set; }
        public virtual ICollection<VendorReturnD> VendorReturnDs { get; set; }
    }
}
