using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class SpcInvT
    {
        public SpcInvT()
        {
            SpcInvDs = new HashSet<SpcInvD>();
        }

        public int SpcInvTId { get; set; }
        public int CarrierId { get; set; }
        public string AccountNo { get; set; }
        public DateTime InvDate { get; set; }
        public DateTime? InvDueDate { get; set; }
        public string InvNo { get; set; }
        public decimal Amount { get; set; }

        public virtual ShipCarrier Carrier { get; set; }
        public virtual ICollection<SpcInvD> SpcInvDs { get; set; }
    }
}
