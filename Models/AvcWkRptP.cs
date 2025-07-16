using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class AvcWkRptP
    {
        public int AvcWkRptPId { get; set; }
        public int AvcWkRptTId { get; set; }
        public int? ProbLevel { get; set; }
        public string CustAsin { get; set; }
        public int IcrId { get; set; }
        public int? Wk00 { get; set; }
        public int? Wk01 { get; set; }
        public int? Wk02 { get; set; }
        public int? Wk03 { get; set; }
        public int? Wk04 { get; set; }
        public int? Wk05 { get; set; }
        public int? Wk06 { get; set; }
        public int? Wk07 { get; set; }
        public int? Wk08 { get; set; }
        public int? Wk09 { get; set; }
        public int? Wk10 { get; set; }
        public int? Wk11 { get; set; }
        public int? Wk12 { get; set; }

        public virtual AvcWkRptT AvcWkRptT { get; set; }
        public virtual MkIcr Icr { get; set; }
    }
}
