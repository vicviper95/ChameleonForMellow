using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplP2bIc
    {
        public TplP2bIc()
        {
            Tpl846s = new HashSet<Tpl846>();
            Tpl940s = new HashSet<Tpl940>();
            Tpl943s = new HashSet<Tpl943>();
            Tpl944s = new HashSet<Tpl944>();
            Tpl945s = new HashSet<Tpl945>();
        }

        public int IcId { get; set; }
        public int PartnerId { get; set; }
        public int? LocationId { get; set; }
        public int EdiIcId { get; set; }
        public DateTime IcTime { get; set; }
        public short Fgc { get; set; }
        public string EdiFname { get; set; }

        public virtual BpmLocation Location { get; set; }
        public virtual EdiPatrnerInfo Partner { get; set; }
        public virtual ICollection<Tpl846> Tpl846s { get; set; }
        public virtual ICollection<Tpl940> Tpl940s { get; set; }
        public virtual ICollection<Tpl943> Tpl943s { get; set; }
        public virtual ICollection<Tpl944> Tpl944s { get; set; }
        public virtual ICollection<Tpl945> Tpl945s { get; set; }
    }
}
