using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ToDoList
    {
        public int ToDoId { get; set; }
        public string ToDoGroup { get; set; }
        public string ToDoTitle { get; set; }
        public string ToDoDetail { get; set; }
        public int RequesterId { get; set; }
        public DateTime ReqDate { get; set; }
        public int? OwenerId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateDue { get; set; }
        public DateTime? DateFinish { get; set; }
        public int? Priority { get; set; }
        public string Note { get; set; }
        public int? Progress { get; set; }

        public virtual Employee Owener { get; set; }
        public virtual Employee Requester { get; set; }
    }
}
