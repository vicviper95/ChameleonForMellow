using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ErrorCategory
    {
        public ErrorCategory()
        {
            SoErrors = new HashSet<SoError>();
        }

        public int ErrorCatId { get; set; }
        public string CatType { get; set; }

        public virtual ICollection<SoError> SoErrors { get; set; }
    }
}
