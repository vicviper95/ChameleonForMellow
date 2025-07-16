using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AinB2pT
    {
        public AinB2pT()
        {
            Ain753s = new HashSet<Ain753>();
            Ain810s = new HashSet<Ain810>();
            Ain855s = new HashSet<Ain855>();
            Ain856s = new HashSet<Ain856>();
            Ain865s = new HashSet<Ain865>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual AinB2pIc EdiIc { get; set; }
        public virtual ICollection<Ain753> Ain753s { get; set; }
        public virtual ICollection<Ain810> Ain810s { get; set; }
        public virtual ICollection<Ain855> Ain855s { get; set; }
        public virtual ICollection<Ain856> Ain856s { get; set; }
        public virtual ICollection<Ain865> Ain865s { get; set; }
    }
}
