using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ain810
    {
        public int Ain810Id { get; set; }
        public int EdiTsId { get; set; }
        public string TxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int InvTId { get; set; }
        public int ArnId { get; set; }

        public virtual AinP2bIc AckIc { get; set; }
        public virtual AdArn Arn { get; set; }
        public virtual AinB2pT EdiTs { get; set; }
        public virtual InvT InvT { get; set; }
    }
}
