using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvToT
    {
        public InvToT()
        {
            InvToDs = new HashSet<InvToD>();
            Way943s = new HashSet<Way943>();
            Way944s = new HashSet<Way944>();
        }

        public int ToTId { get; set; }
        public int? NsIntId { get; set; }
        public string ToNoNs { get; set; }
        public string ToNoTpl { get; set; }
        public int ShipFrId { get; set; }
        public int ShipToId { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime ShipEta { get; set; }
        public DateTime? RecvDate { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual BpmLocation ShipFr { get; set; }
        public virtual ICollection<InvToD> InvToDs { get; set; }
        public virtual ICollection<Way943> Way943s { get; set; }
        public virtual ICollection<Way944> Way944s { get; set; }
    }
}
