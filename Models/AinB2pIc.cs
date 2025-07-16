using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AinB2pIc
    {
        public AinB2pIc()
        {
            Ain754s = new HashSet<Ain754>();
            Ain850s = new HashSet<Ain850>();
            Ain860s = new HashSet<Ain860>();
            AinB2pTs = new HashSet<AinB2pT>();
        }

        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short? Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual ICollection<Ain754> Ain754s { get; set; }
        public virtual ICollection<Ain850> Ain850s { get; set; }
        public virtual ICollection<Ain860> Ain860s { get; set; }
        public virtual ICollection<AinB2pT> AinB2pTs { get; set; }
    }
}
