using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class WayPoTkN
    {
        public int TkNoteId { get; set; }
        public int TicketDId { get; set; }
        public string Note { get; set; }
        public DateTime AddedDate { get; set; }

        public virtual WayPoTkD TicketD { get; set; }
    }
}
