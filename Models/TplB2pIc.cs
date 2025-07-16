using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplB2pIc
    {
        public TplB2pIc()
        {
            Tpl846s = new HashSet<Tpl846>();
            Tpl944s = new HashSet<Tpl944>();
            Tpl945s = new HashSet<Tpl945>();
            TplB2pTs = new HashSet<TplB2pT>();
        }

        public int EdiIcId { get; set; }
        public int PartnerId { get; set; }
        public int? LocationId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiFname { get; set; }
        public byte As2Status { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual EdiPatrnerInfo Partner { get; set; }
        public virtual ICollection<Tpl846> Tpl846s { get; set; }
        public virtual ICollection<Tpl944> Tpl944s { get; set; }
        public virtual ICollection<Tpl945> Tpl945s { get; set; }
        public virtual ICollection<TplB2pT> TplB2pTs { get; set; }
    }
}
