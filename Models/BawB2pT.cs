using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BawB2pT
    {
        public BawB2pT()
        {
            Baw940s = new HashSet<Baw940>();
            Baw943s = new HashSet<Baw943>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual BawB2pIc EdiIc { get; set; }
        public virtual ICollection<Baw940> Baw940s { get; set; }
        public virtual ICollection<Baw943> Baw943s { get; set; }
    }
}
