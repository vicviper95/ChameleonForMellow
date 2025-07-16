using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class EdiServiceControl
    {
        public int EdiServiceId { get; set; }
        public int? RunAs2Server { get; set; }
        public int? RunAs2Client { get; set; }
        public int? RunEdiBotAs2 { get; set; }
        public int? RunEdiBotFtp { get; set; }
    }
}
