using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BpmBegInventory
    {
        public int BegInvId { get; set; }
        public DateTime TimeRecord { get; set; }
        public int LocationId { get; set; }
        public int ItemNoId { get; set; }
        public int QtyOnHand { get; set; }
        public int? QtyAvail { get; set; }
        public int? QtyAvailKoala { get; set; }
        public int? QoHTpl { get; set; }
        public int? QavTpl { get; set; }
        public int? QtyReserved { get; set; }
        public DateTime DateRecord { get; set; }

        public virtual BpmItem ItemNo { get; set; }
        public virtual BpmLocation Location { get; set; }
    }
}
