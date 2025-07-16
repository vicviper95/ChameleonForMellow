using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ApisoStatus
    {
        public int PoStatusId { get; set; }
        public int? SoTId { get; set; }
        public int CustId { get; set; }
        public string PoNo { get; set; }
        public bool IsAcked { get; set; }
        public bool SentAsn { get; set; }
        public DateTime? Ackedtime { get; set; }
        public DateTime? SentAsnTime { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
