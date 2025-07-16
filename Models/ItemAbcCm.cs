using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ItemAbcCm
    {
        public int ItemAbcCmId { get; set; }
        public DateTime FcstDate { get; set; }
        public int FcstChannelId { get; set; }
        public int ItemNoId { get; set; }
        public string Abc00 { get; set; }
        public string Abc01 { get; set; }
        public string Abc02 { get; set; }
        public string Abc03 { get; set; }
        public string Abc04 { get; set; }
        public string Abc05 { get; set; }
        public string Abc06 { get; set; }
        public string Abc07 { get; set; }
        public string Abc08 { get; set; }
        public string Abc09 { get; set; }
        public string Abc10 { get; set; }
        public string Abc11 { get; set; }

        public virtual FcstChannel FcstChannel { get; set; }
        public virtual BpmItem ItemNo { get; set; }
    }
}
