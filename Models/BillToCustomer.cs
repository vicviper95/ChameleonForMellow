using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class BillToCustomer
    {
        public int BillToCustomerId { get; set; }
        public string BillToName { get; set; }
        public string BillingAddr1 { get; set; }
        public string BillingAddr2 { get; set; }
        public string BillingAddr3 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Ccnumber { get; set; }
        public string Cctype { get; set; }
        public string CcexpDate { get; set; }
    }
}
