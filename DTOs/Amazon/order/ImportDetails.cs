using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon.order
{
  public class ImportDetails
  {
    public string methodOfPayment { get; set; }
    public string internationalCommercialTerms { get; set; }
    public string portOfDelivery { get; set; }
    public string importContainers { get; set; }


  }
}
