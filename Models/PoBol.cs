using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class PoBol
    {
        public PoBol()
        {
            BolFeet = new HashSet<BolFoot>();
            Containers = new HashSet<Container>();
            PoChangeds = new HashSet<PoChanged>();
        }

        public int PoBolId { get; set; }
        public int? NsIntId { get; set; }
        public string BoLno { get; set; }
        public string Voyage { get; set; }
        public int? ShipLineId { get; set; }
        public int? PortOriginId { get; set; }
        public int? PortDestId { get; set; }
        public DateTime BolEtd { get; set; }
        public DateTime BolEta { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModTime { get; set; }
        public DateTime? LastModKoT { get; set; }
        public int? LastModKoE { get; set; }
        public string Source { get; set; }
        public int? ForwarderId { get; set; }
        public bool? IsReviewDone { get; set; }

        public virtual Forwarder Forwarder { get; set; }
        public virtual PortDest PortDest { get; set; }
        public virtual PortOrigin PortOrigin { get; set; }
        public virtual ShipLine ShipLine { get; set; }
        public virtual ICollection<BolFoot> BolFeet { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
        public virtual ICollection<PoChanged> PoChangeds { get; set; }
    }
}
