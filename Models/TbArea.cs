using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class TbArea
    {
        public int TbAreaId { get; set; }
        public int TakeBackerId { get; set; }
        public string TbAreaType { get; set; }
        public string TbAreaCode { get; set; }

        public virtual TakeBacker TakeBacker { get; set; }
    }
}
