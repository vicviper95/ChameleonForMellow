using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AdInvValuationGl
    {
        public int AdInvValuationGlId { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }

        public virtual GlAccount Account { get; set; }
    }
}
