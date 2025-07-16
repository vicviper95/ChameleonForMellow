using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TplB2pT
    {
        public TplB2pT()
        {
            Tpl940s = new HashSet<Tpl940>();
            Tpl943s = new HashSet<Tpl943>();
        }

        public int EdiTsId { get; set; }
        public int EdiIcId { get; set; }

        public virtual TplB2pIc EdiIc { get; set; }
        public virtual ICollection<Tpl940> Tpl940s { get; set; }
        public virtual ICollection<Tpl943> Tpl943s { get; set; }
    }
}
