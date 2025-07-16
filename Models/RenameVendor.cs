using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class RenameVendor
    {
        public string SageId { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public string Diff { get; set; }
    }
}
