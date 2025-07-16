using Chameleon.DTOs.Amazon.order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.DTOs.Amazon.orderDS
{
	public class OrderDetailsDS
	{
		public string customerOrderNumber { get; set; }
		public DateTime orderDate { get; set; }
		public DateTime POLocalDate => orderDate.ToLocalTime();
		public string orderStatus { get; set; }
		public ShipDetail shipmentDetails { get; set; }
		public Tax taxTotal { get; set; }
		public PartyIds sellingParty { get; set; }
		public PartyIds shipFromParty { get; set; }
		public ShipToParty shipToParty { get; set; }
		public PartyIds billToParty { get; set; }
		public List<ItemDetail> items { get; set; }
		public OrderDetailsDS()
		{
			shipmentDetails = new ShipDetail();
			sellingParty = new PartyIds();
			shipFromParty = new PartyIds();
			items = new List<ItemDetail>();
		}
	}
}
