using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class NsCurrency
    {
        public NsCurrency()
        {
            NsCurrencyRateBaseCurrencies = new HashSet<NsCurrencyRate>();
            NsCurrencyRateFromCurrencies = new HashSet<NsCurrencyRate>();
            VendorBillTs = new HashSet<VendorBillT>();
        }

        public int Id { get; set; }
        public int NsIntId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public virtual ICollection<NsCurrencyRate> NsCurrencyRateBaseCurrencies { get; set; }
        public virtual ICollection<NsCurrencyRate> NsCurrencyRateFromCurrencies { get; set; }
        public virtual ICollection<VendorBillT> VendorBillTs { get; set; }
    }
}
