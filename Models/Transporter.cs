using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Transporter
    {
        public Transporter()
        {
            Containers = new HashSet<Container>();
            TranspCharges = new HashSet<TranspCharge>();
        }

        public int TransporterId { get; set; }
        public string TranspName { get; set; }
        public int? ChargeId { get; set; }
        public string ShortName { get; set; }
        public int? NsIntId { get; set; }

        public virtual TranspCharge Charge { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
        public virtual ICollection<TranspCharge> TranspCharges { get; set; }
    }
}
