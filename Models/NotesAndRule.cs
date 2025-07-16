using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NotesAndRule
    {
        public int NotesAndRulesId { get; set; }
        public string NoteRule { get; set; }
        public bool? IsActivated { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public int? NoteCategory { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee LastModifiedByNavigation { get; set; }
        public virtual NotesRulesRmrkCat NoteCategoryNavigation { get; set; }
    }
}
