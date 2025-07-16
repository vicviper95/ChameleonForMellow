using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsCurrencyRate
    {
        public int Id { get; set; }
        public int BaseCurrencyId { get; set; }
        public int FromCurrencyId { get; set; }
        public double Rate { get; set; }
        public DateTime EffectiveDate { get; set; }

        public virtual NsCurrency BaseCurrency { get; set; }
        public virtual NsCurrency FromCurrency { get; set; }
    }
}
