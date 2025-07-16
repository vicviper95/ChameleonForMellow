using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ChangeLog
    {
        public int ChId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string FilePath { get; set; }
        public byte? IsNew { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
    }
}
