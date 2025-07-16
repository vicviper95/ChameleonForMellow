using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToStatus
    {
        public ToStatus()
        {
            ToTs = new HashSet<ToT>();
        }

        public int ToStatusId { get; set; }
        public string StatusTo { get; set; }

        public virtual ICollection<ToT> ToTs { get; set; }
    }
}
