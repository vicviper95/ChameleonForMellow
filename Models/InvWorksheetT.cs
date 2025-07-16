using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class InvWorksheetT
    {
        public InvWorksheetT()
        {
            InvWorksheetDs = new HashSet<InvWorksheetD>();
        }

        public int InvWorksheetTId { get; set; }
        public int NsIntId { get; set; }
        public string Iwno { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? LastModDate { get; set; }

        public virtual ICollection<InvWorksheetD> InvWorksheetDs { get; set; }
    }
}
