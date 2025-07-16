using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BawB2pIc
    {
        public BawB2pIc()
        {
            Baw846s = new HashSet<Baw846>();
            Baw944s = new HashSet<Baw944>();
            Baw945s = new HashSet<Baw945>();
            BawAs2s = new HashSet<BawAs2>();
            BawB2pTs = new HashSet<BawB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Baw846> Baw846s { get; set; }
        public virtual ICollection<Baw944> Baw944s { get; set; }
        public virtual ICollection<Baw945> Baw945s { get; set; }
        public virtual ICollection<BawAs2> BawAs2s { get; set; }
        public virtual ICollection<BawB2pT> BawB2pTs { get; set; }
    }
}
