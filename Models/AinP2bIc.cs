using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AinP2bIc
    {
        public AinP2bIc()
        {
            Ain753s = new HashSet<Ain753>();
            Ain754s = new HashSet<Ain754>();
            Ain810s = new HashSet<Ain810>();
            Ain850s = new HashSet<Ain850>();
            Ain855s = new HashSet<Ain855>();
            Ain856s = new HashSet<Ain856>();
            Ain860s = new HashSet<Ain860>();
            Ain865s = new HashSet<Ain865>();
        }

        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiStr { get; set; }
        public string EdiFname { get; set; }

        public virtual ICollection<Ain753> Ain753s { get; set; }
        public virtual ICollection<Ain754> Ain754s { get; set; }
        public virtual ICollection<Ain810> Ain810s { get; set; }
        public virtual ICollection<Ain850> Ain850s { get; set; }
        public virtual ICollection<Ain855> Ain855s { get; set; }
        public virtual ICollection<Ain856> Ain856s { get; set; }
        public virtual ICollection<Ain860> Ain860s { get; set; }
        public virtual ICollection<Ain865> Ain865s { get; set; }
    }
}
