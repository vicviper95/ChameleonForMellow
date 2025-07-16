using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TgtB2pIc
    {
        public TgtB2pIc()
        {
            Tgt850s = new HashSet<Tgt850>();
            Tgt860s = new HashSet<Tgt860>();
            TgtB2pTs = new HashSet<TgtB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Tgt850> Tgt850s { get; set; }
        public virtual ICollection<Tgt860> Tgt860s { get; set; }
        public virtual ICollection<TgtB2pT> TgtB2pTs { get; set; }
    }
}
