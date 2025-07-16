using Chameleon.DTOs.Amazon.order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chameleon.DTOs.Amazon.order
{
	public class OrderDetails
	{
		public DateTime purchaseOrderDate { get; set; }
		public DateTime POLocalDate => purchaseOrderDate.ToLocalTime();
		public DateTime? purchaseOrderChangedDate { get; set; }
		public DateTime purchaseOrderStateChangedDate { get; set; }
		public string purchaseOrderType { get; set; }
		public ImportDetails importDetails { get; set; }
		public string paymentMethod { get; set; }
		public PartyIds buyingParty { get; set; }
		public PartyIds sellingParty { get; set; }
		public PartyIds shipToParty { get; set; }
		public PartyIds billToParty { get; set; }
		public string shipWindow { get; set; }
		public List<Items> items { get; set; }

		public OrderDetails()
		{
			buyingParty = new PartyIds();
			sellingParty = new PartyIds();
			shipToParty = new PartyIds();
			billToParty = new PartyIds();
			items = new List<Items>();
		}
	}


}
