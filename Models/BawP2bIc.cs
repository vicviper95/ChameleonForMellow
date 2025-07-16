using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BawP2bIc
    {
        public BawP2bIc()
        {
            Baw846s = new HashSet<Baw846>();
            Baw944s = new HashSet<Baw944>();
            Baw945s = new HashSet<Baw945>();
        }

        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Baw846> Baw846s { get; set; }
        public virtual ICollection<Baw944> Baw944s { get; set; }
        public virtual ICollection<Baw945> Baw945s { get; set; }
    }
}
