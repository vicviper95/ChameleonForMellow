using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToContainer
    {
        public ToContainer()
        {
            ToTs = new HashSet<ToT>();
        }

        public int ToContainerId { get; set; }
        public int ToBolId { get; set; }
        public string ContainerNo { get; set; }

        public virtual ToBol ToBol { get; set; }
        public virtual ICollection<ToT> ToTs { get; set; }
    }
}
