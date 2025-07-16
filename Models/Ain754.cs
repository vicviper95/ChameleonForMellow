using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Ain754
    {
        public int Ain754Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int? AckIcId { get; set; }
        public int ArnId { get; set; }

        public virtual AinB2pIc AckIc { get; set; }
        public virtual AdArn Arn { get; set; }
        public virtual AinP2bIc Ic { get; set; }
    }
}
