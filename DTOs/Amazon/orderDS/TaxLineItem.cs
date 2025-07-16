using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon.orderDS
{
  public class TaxLineItem
  {
    public string taxRate { get; set; }
    public Prices taxAmount { get; set; }
  }
}
