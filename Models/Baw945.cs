using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class Baw945
    {
        public int Baw945Id { get; set; }
        public int IcId { get; set; }
        public int EdiIcId { get; set; }
        public int EdiTsId { get; set; }
        public string RxStatus { get; set; }
        public int AckIcId { get; set; }
        public int? SoTId { get; set; }
        public int? KoIftId { get; set; }

        public virtual BawB2pIc AckIc { get; set; }
        public virtual BawP2bIc Ic { get; set; }
        public virtual KoItemFft KoIft { get; set; }
        public virtual SoT SoT { get; set; }
    }
}
