using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class KoCoD
    {
        public int KoCoDId { get; set; }
        public int KoCoTId { get; set; }
        public int SoDId { get; set; }
        public int QtyOrder { get; set; }
        public int QtyCcReq { get; set; }
        public int QtyCcAcpt { get; set; }
        public DateTime? AcptTime { get; set; }
        public int? AcptEmp { get; set; }
        public DateTime LastModTime { get; set; }
        public DateTime? NsSyncTime { get; set; }
        public string CustSku { get; set; }
        public int StatusId { get; set; }

        public virtual KoCoT KoCoT { get; set; }
        public virtual SoD SoD { get; set; }
        public virtual WithdrawalStatus Status { get; set; }
    }
}
