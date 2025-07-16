using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class ZinusCust
    {
        public ZinusCust()
        {
            Customers = new HashSet<Customer>();
        }

        public int ZinusCustId { get; set; }
        public string CompCode { get; set; }
        public string CompName { get; set; }
        public string BpNumber { get; set; }
        public string CustName { get; set; }
        public string G1Code { get; set; }
        public string G1Name { get; set; }
        public int G1Order { get; set; }
        public string G2Code { get; set; }
        public string G2Name { get; set; }
        public int G2Order { get; set; }
        public string G3Code { get; set; }
        public string G3Name { get; set; }
        public int G3Order { get; set; }
        public string Area { get; set; }
        public bool IsDomestic { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
