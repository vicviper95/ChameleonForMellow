using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AccInvOutCoG
    {
        public int AccInvOutId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string Location { get; set; }
        public int ItemNoId { get; set; }
        public int Qty { get; set; }
        public decimal CoGs { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
