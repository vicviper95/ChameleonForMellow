using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Chameleon.DTOs.Wayfair;
using GraphQL;


namespace Chameleon.Services.WayfairService.WayfairLib
{
    public class WayfairPO
	{
        private string _token;
        private WayfairLib wayfairLib = new WayfairLib();
        public WayfairPO()
        {
        }
		public string GetDropshipSOBySoNum(List<string> SoNums)
		{
			_token = wayfairLib.FetchToken();
			string strSoNums = string.Join("\",\"", SoNums.ToArray()).Insert(0, "\"") + "\"";
			var query = new GraphQLRequest
			{
				Query =
				@"
					query getDropshipPurchaseOrders($poNumbers: [String]){
					getDropshipPurchaseOrders (						
						poNumbers: $poNumbers,
					) {
						poNumber,
						poDate,
						estimatedShipDate,
						customerName,
						customerAddress1,
						customerAddress2,
						customerCity,
						customerState,
						customerPostalCode,
						orderType,
						shippingInfo {
							shipSpeed,
							carrierCode
						},
						packingSlipUrl,
						warehouse {
							id,
							name,
							address {
								name,
								address1,
								address2,
								address3,
								city,
								state,
								country,
								postalCode
							}
						},
						products {
							partNumber,
							quantity,
							price,
							event {
								id,
								type,
								name,
								startDate,
								endDate
							}
						},
						shipTo {
							name,
							address1,
							address2,
							address3,
							city,
							state,
							country,
							postalCode,
							phoneNumber
						}
					}
				}",
				Variables = $@"
						  {{
							""poNumbers"" : [{strSoNums}]
							}}"
			};
			string variables = query["variables"].ToString();
			string queryStr = (string)query["query"];
			string finalStr = queryStr.Replace("\r", "").Replace("\n", "").Replace("\t", "");
			string VarStr = variables.Replace("\r", "").Replace("\n", "").Replace("\t", "");
			string jsonContent = wayfairLib.SendGraphQLRequest(_token, finalStr, VarStr);
			return jsonContent;
		}
		public string GetDropshipSoByDate(DateTime dateTime)
		{
			_token = wayfairLib.FetchToken();
			var query = new GraphQLRequest
			{
				Query =
				@"
					query getDropshipPurchaseOrders($fromDate: IsoDateTime!){
					getDropshipPurchaseOrders (						
						fromDate: $fromDate,
						limit: 1000,
					) {
						poNumber,
						poDate,
						estimatedShipDate,
						customerName,
						customerAddress1,
						customerAddress2,
						customerCity,
						customerState,
						customerPostalCode,
						orderType,
						shippingInfo {
							shipSpeed,
							carrierCode
						},
						packingSlipUrl,
						warehouse {
							id,
							name,
							address {
								name,
								address1,
								address2,
								address3,
								city,
								state,
								country,
								postalCode
							}
						},
						products {
							partNumber,
							quantity,
							price,
							event {
								id,
								type,
								name,
								startDate,
								endDate
							}
						},
						shipTo {
							name,
							address1,
							address2,
							address3,
							city,
							state,
							country,
							postalCode,
							phoneNumber
						}
					}
				}",
				Variables = $@"
						  {{
							""fromDate"" : ""{dateTime.ToString("yyyy-MM-dd HH\\:mm\\:ss")}""
							}}"
			};

			string variables = query["variables"].ToString();
			string queryStr = (string)query["query"];
			string finalStr = queryStr.Replace("\r", "").Replace("\n", "").Replace("\t", "");
			string VarStr = variables.Replace("\r", "").Replace("\n", "").Replace("\t", "");
			string jsonContent = wayfairLib.SendGraphQLRequest(_token, finalStr, VarStr);
			return jsonContent;
		}
        public List<string> SendAccept(WafairDSOrder orders)
        {
            _token = wayfairLib.FetchToken();
            Getdropshippurchaseorder[] items = orders.data.getDropshipPurchaseOrders;
			List<string> invalidRes = new List<string>();
			foreach (var order in items)
            {
                StringBuilder variableStr = new StringBuilder();
                for (int i = 0; i < order.products.Length; i++)
                {
                    if (i != 0)
                    {
                        variableStr.Append(",");
                    }
                    variableStr.Append($@"	
					   {{
							""partNumber"": ""{order.products[i].partNumber}"",
							""quantity"": {order.products[i].quantity},
							""unitPrice"": {order.products[i].price},
							""estimatedShipDate"": ""{order.estimatedShipDate}""
							}}
						"
                        );
                }
                var query = new GraphQLRequest
                {
                    Query =
                    @"
						 mutation accept($poNumber: String!, $shipSpeed: ShipSpeed!, $lineItems: [AcceptedLineItemInput!]!){
						 purchaseOrders {
						    accept(
						      poNumber: $poNumber,
						      shipSpeed: $shipSpeed,
						      lineItems: $lineItems
						    ) {
						      	id,
								handle,
								status,
								submittedAt,
								completedAt,
								errors {
									key,
									message
								}
						    }
						  }
						}",
                    Variables = $@"						  
							  {{
								""poNumber"" : ""{order.poNumber}"",
								""shipSpeed"" : ""{order.shippingInfo.shipSpeed}"",
								""lineItems"" : [{variableStr.ToString()}]
							  }}"
                };

                string variables = query["variables"].ToString();
                string queryStr = (string)query["query"];
                string finalStr = queryStr.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string VarStr = variables.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string jsonContent = wayfairLib.SendGraphQLRequest(_token, finalStr, VarStr);
				if (jsonContent.Contains("errors"))
				{
					invalidRes.Add(jsonContent);
				}
			}
			return invalidRes;
		}
        public List<string> SendReject(WafairDSOrder roders)
        {
            _token = wayfairLib.FetchToken();
            Getdropshippurchaseorder[] items = roders.data.getDropshipPurchaseOrders;
			List<string> invalidRes = new List<string>();
			foreach (var order in items)
            {
                StringBuilder variableStr = new StringBuilder();
                for (int i = 0; i < order.products.Length; i++)
                {
                    if (i != 0)
                    {
                        variableStr.Append(",");
                    }
                    variableStr.Append($@"	
						{{
							""partNumber"": ""{order.products[i].partNumber}"",
							""quantity"": {order.products[i].quantity}
						}}
						"
                        );
                }
                var query = new GraphQLRequest
                {
                    Query =
                    @"
						 mutation reject($poNumber: String!, $lineItems: [RejectLineItemInput!]!){
						 purchaseOrders {
						    reject(
						      poNumber: $poNumber,
						      lineItems: $lineItems
						    ) {
						      	id,
								handle,
								status,
								submittedAt,
								completedAt,
								errors {
									key,
									message
								}
						    }
						  }
						}",
                    Variables = $@"						  
							  {{
								""poNumber"" : ""{order.poNumber}"",
								""lineItems"" : [{variableStr.ToString()}]
							  }}"
                };

                string variables = query["variables"].ToString();
                string queryStr = (string)query["query"];
                string finalStr = queryStr.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string VarStr = variables.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string jsonContent = wayfairLib.SendGraphQLRequest(_token, finalStr, VarStr);
				if (jsonContent.Contains("errors"))
				{
					invalidRes.Add(jsonContent);
				}
			}
			return invalidRes;
		}
        public List<string> SendBackOrder(WafairDSOrder orders)
        {
            _token = wayfairLib.FetchToken();
            Getdropshippurchaseorder[] items = orders.data.getDropshipPurchaseOrders;
			List<string> invalidRes = new List<string>();
            foreach (var order in items)
            {
                StringBuilder variableStr = new StringBuilder();
                for (int i = 0; i < order.products.Length; i++)
                {
                    if (i != 0)
                    {
                        variableStr.Append(",");
                    }
                    variableStr.Append($@"	
					   {{
							""partNumber"": ""{order.products[i].partNumber}"",
							""quantity"": {order.products[i].quantity},
							""unitPrice"": {order.products[i].price},
							""newShipDate"": ""{order.newShipDate}""							
						}}
						"
                        );
                }
                variableStr.Append("]");
                var query = new GraphQLRequest
                {
                    Query =
                    @"
						 mutation backorder($poNumber: String!, $shipSpeed: ShipSpeed!, $lineItems: [BackorderedLineItemInput!]!){
						 purchaseOrders {
						    backorder(
						      poNumber: $poNumber,
						      shipSpeed: $shipSpeed,
						      lineItems: $lineItems
						    ) {
						      	id,
								handle,
								status,
								submittedAt,
								completedAt,
								errors {
									key,
									message
								}
						    }
						  }
						}",
                    Variables = $@"						  
							  {{
								""poNumber"" : ""{order.poNumber}"",
								""shipSpeed"" : ""{order.shippingInfo.shipSpeed}"",
								""lineItems"" : [{variableStr.ToString()}]
							  }}"
                };

                string variables = query["variables"].ToString();
                string queryStr = (string)query["query"];
                string finalStr = queryStr.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string VarStr = variables.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string jsonContent = wayfairLib.SendGraphQLRequest(_token, finalStr, VarStr);
				if (jsonContent.Contains("errors"))
				{
					invalidRes.Add(jsonContent);
				}
			}
			return invalidRes;
		}
        public List<string> SendShipment(WafairDSOrder orders)
        {
            _token = wayfairLib.FetchToken();
            Getdropshippurchaseorder[] items = orders.data.getDropshipPurchaseOrders;
			List<string> invalidRes = new List<string>();
			foreach (Getdropshippurchaseorder order in items)
            {
                StringBuilder smallParcelShipmentStr = new StringBuilder();
				StringBuilder largeParcelShipmentStr = new StringBuilder();
				//build smallParcelShipments list type
				double totalWeight = 0;
                double totalVolume = 0;
                for (int i = 0; i < order.shippingInfo.parcelShipment.Count; i++)
                {
                    totalWeight += order.shippingInfo.parcelShipment[i].weight;
                    totalVolume += order.shippingInfo.parcelShipment[i].volume;
                    
					// build items list string
                    StringBuilder itemStr = new StringBuilder();
                    List<Product> shipItems = order.shippingInfo.parcelShipment[i].items;
                    for (int x = 0; x < shipItems.Count; x++)
                    {
                        if (x != 0)
                        {
                            itemStr.Append(",");
                        }

                        itemStr.Append($@"
									{{
										""partNumber"": ""{shipItems[x].partNumber}"",
										""quantity"": {shipItems[x].quantity}
									}}");
                    }

					if (order.shippingInfo.parcelShipment[i].size == ParcelSize.large)
					{
						if (i != 0)
						{
							largeParcelShipmentStr.Append(",");
						}
						largeParcelShipmentStr.Append($@"
											{{""package"":{{
													""code"":{{
														   		""type"": ""TRACKING_NUMBER"",
														   		""value"": ""{order.shippingInfo.parcelShipment[i].trackingNo}""
														     }},
																""weight"":{order.shippingInfo.parcelShipment[i].weight}
															 }},
												}}"
												);
					}
                    else
                    {
						if (i != 0)
						{
							smallParcelShipmentStr.Append(",");
						}
						smallParcelShipmentStr.Append($@"
											{{""package"":{{
													""code"":{{
														   		""type"": ""TRACKING_NUMBER"",
														   		""value"": ""{order.shippingInfo.parcelShipment[i]}""
														     }},
																""weight"":{order.shippingInfo.parcelShipment[i].weight}
													}},
													""items"":[
															{itemStr.ToString()}
														]
												}}"
												);
					}
                   
                }
                var query = new GraphQLRequest
                {
                    Query =
                    $@"
						 mutation backorder($notice: ShipNoticeInput!){{
						 purchaseOrders {{
						     shipment(notice: $notice){{
						      	id,
								handle,
								status,
								submittedAt,
								completedAt,
								errors {{
									key,
									message
								}}
						    }}
						  }}
						}}",
                    Variables = $@"						  
							  {{
								""notice"": {{
										""poNumber"" : ""{order.poNumber}"",
										""supplierId"": {order.warehouse.id},
										""packageCount"": {order.shippingInfo.parcelShipment.Count},
										""weight"":{totalWeight},
										""volume"": {totalVolume},
										""carrierCode"": ""{order.shippingInfo.carrierCode}"", 
										""shipSpeed"" : ""{order.shippingInfo.shipSpeed}"",  
										""trackingNumber"": ""{order.shippingInfo.parcelShipment[0].trackingNo}"",   
										""shipDate"": ""{order.estimatedShipDate}"",   
										""sourceAddress"": {{
															  ""name"": ""{order.warehouse.address.name}"",
															  ""streetAddress1"": ""{order.warehouse.address.address1}"",
															  ""city"": ""{order.warehouse.address.city}"",
															  ""state"": ""{order.warehouse.address.state}"",
															  ""postalCode"": ""{order.warehouse.address.postalCode}"",
															  ""country"": ""{order.warehouse.address.country}""
														   }},
										""destinationAddress"": {{  
																   ""name"": ""{order.shipTo.name}"",   
																   ""streetAddress1"": ""{order.shipTo.address1}"",   
																   ""city"": ""{order.shipTo.city}"",   
																   ""state"": ""{order.shipTo.state}"",   
																   ""postalCode"": ""{order.shipTo.postalCode}"",   
																   ""country"": ""{order.shipTo.country}""
																}},  
										""largeParcelShipments"" : [{largeParcelShipmentStr.ToString()}],
										""smallParcelShipments"" : [{smallParcelShipmentStr.ToString()}]
									}}
							  }}
								"
                };

                string variables = query["variables"].ToString();
                string queryStr = (string)query["query"];
                string finalStr = queryStr.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string VarStr = variables.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                string jsonContent = wayfairLib.SendGraphQLRequest(_token, finalStr, VarStr);
				if (jsonContent.Contains("errors"))
				{
					invalidRes.Add(jsonContent);
				}
			}
			return invalidRes;
		}
    }
}
