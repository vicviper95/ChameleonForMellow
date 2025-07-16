using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NotesRulesRmrkCat
    {
        public NotesRulesRmrkCat()
        {
            NotesAndRules = new HashSet<NotesAndRule>();
        }

        public int NoteRuleRmrkCatId { get; set; }
        public string RemarkCategory { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? ModifiedBy { get; set; }
        public byte[] ModifiedTime { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual ICollection<NotesAndRule> NotesAndRules { get; set; }
    }
}
