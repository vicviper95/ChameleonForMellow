using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ErrorLog
    {
        public int ErrorId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string FilePath { get; set; }
        public string Traceback { get; set; }
        public string ErrorMsg { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
    }
}
