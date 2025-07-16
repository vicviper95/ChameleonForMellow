using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chameleon.Models;
using SuitetalkerService;
using Chameleon.Services.ServiceUtil;
using EFCore.BulkExtensions;
using System.Collections;
using System.Net.Http;

namespace Chameleon.Services.SuiteTalkerService.SuiteTalkLib
{
    public class SalesOrderProcess : SuiteTalkerUtil
    {
        private readonly KOALAContext _kc;
        private readonly UtilMethods _utilMethods;
        private readonly MellowAPI _mellowAPI;
        public SalesOrderProcess(bool isProduction, KOALAContext kc) : base(isProduction)
        {
            _kc = kc;

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            _mellowAPI = new MellowAPI("https://localhost:5001/", client);
        }

        //mellowAPi
        public async void CreateSOtoNS()
        {
            try
            {
                var cmd = new CreateSO()
                {
                    IsSandBoxMode = true,
                    Requester = "API System",
                };

                var result = await _mellowAPI.CreateSOAsync(cmd);
            }
            catch (Exception ex)
            {
                
            }
        }


        public async Task<Hashtable> CreateSalesOrder(List<KoSoT> koSots, Hashtable resCollector)
        {
            List<string> resultMsg = new List<string>();
            SalesOrder salesOrder = new SalesOrder();
            List<Models.Country> countries = _kc.Countries.ToList();

            foreach (KoSoT koSot in koSots)
            {
                var koSod = koSot.KoSoDs.FirstOrDefault();
                var shipVia = koSod.ShipVia;
                var bpmLocation = koSod.ShipFromWh;
                salesOrder.entity = new RecordRef() { internalId = koSot.Customer.NsIntId.ToString() };
                salesOrder.otherRefNum = koSot.PoNo;
                salesOrder.externalId = $"{koSot.CustomerId}_{koSot.PoNo}";
                salesOrder.shipIsResidential = koSod.ShipVia.NsIsResidential == 0 ? false : true;
                salesOrder.tranDate = koSot.SoDate;
                salesOrder.tranDateSpecified = true;
                salesOrder.shipComplete = false;
                salesOrder.shipCompleteSpecified = true;
                salesOrder.shipDate = koSot.ExpShipDate.Value;
                salesOrder.shipDateSpecified = true;

                // shippingAddress
                salesOrder.shippingAddress = new Address()
                {
                    addressee = koSot.ShipToName,
                    addr1 = AddressRegex(koSot.Address1),
                    addr2 = AddressRegex(koSot.Address2),
                    city = koSot.City,
                    state = koSot.State,
                    country = (SuitetalkerService.Country)CountryNameToCode(koSot.Country, countries),
                    zip = koSot.Zip,
                    addrPhone = koSot.PhoneNo,
                    countrySpecified = true,
                };

                if (koSot.CustomerId == 2 || koSot.CustomerId == 4 || koSot.CustomerId == 1) // 2 = Dir, 4 = DI, 1 = Canada
                {
                    var afcID = _kc.AdAfcids.Where(x => x.AmazonFcId == koSot.ShipToAfcId).FirstOrDefault();
                    List<CustomFieldRef> customFields = new List<CustomFieldRef>();

                    if (koSot.CustomerId == 1 || koSot.CustomerId == 2) // Amazon Direct
                    {
                        salesOrder.shipMethod = new RecordRef() { internalId = koSod.ShipVia.NsIntId.ToString() };
                        customFields = new List<CustomFieldRef>()
                        {
                            new StringCustomFieldRef() { scriptId = "custbody_sps_vendor", value =  koSot.VendorCode },						// Vendor Number
				            new StringCustomFieldRef() { scriptId = "custbody_sps_carrieralphacode", value = koSot.VendorCode },					// Standard Carrier Alpha Code
				        	new DateCustomFieldRef() { scriptId = "custbody_sps_purchaseorderdate", value =  koSot.SoDate },				// Order Date
				        	new DateCustomFieldRef() { scriptId = "custbody_ship_window_start", value = koSot.ShipWindowStart.Value},		// ShipWindowStart
				        	new DateCustomFieldRef() { scriptId = "custbody_ship_window_end", value = koSot.ShipWindowEnd.Value},			// Ship Window End Date
				        	new StringCustomFieldRef() { scriptId = "custbody_sps_st_addresslocationnumber", value = afcID.FcAid ?? ""  },	// Ship to Code
				        };
                    }
                    else if (koSot.CustomerId == 4) // Amazon DI
                    {
                        customFields = new List<CustomFieldRef>()
                        {
                            new StringCustomFieldRef() { scriptId = "custbody_sps_vendor", value =  koSot.VendorCode },
                            new DateCustomFieldRef() { scriptId = "custbody_sps_purchaseorderdate", value =  koSot.SoDate },				// Order Date
				        	new DateCustomFieldRef() { scriptId = "custbody_ship_window_start", value = koSot.ShipWindowStart.Value},		// ShipWindowStart
				        	new DateCustomFieldRef() { scriptId = "custbody_ship_window_end", value = koSot.ShipWindowEnd.Value},			// Ship Window End Date
				        	new StringCustomFieldRef() { scriptId = "custbody_sps_st_addresslocationnumber", value =  afcID.FcAid ?? ""  },	// Ship to Code
				        };
                    }
                    salesOrder.customFieldList = customFields.ToArray();
                }
                else if (koSot.CustomerId == 5) // Amazon Drop ship
                {
                    salesOrder.shipMethod = new RecordRef() { internalId = koSod.ShipVia.NsIntId.ToString() };
                    salesOrder.location = new RecordRef() { internalId = bpmLocation.NsIntId.ToString() };
                    List<CustomFieldRef> customFields = new List<CustomFieldRef>()
                    {
                        new StringCustomFieldRef() { scriptId = "custbody_sps_carrierrouting", value = koSod.ShipVia.SvcAmazon},				// CARRIER ROUTING DESCRIPTION
				    	new SelectCustomFieldRef() { scriptId = "cseg_order_type", value = new ListOrRecordRef() { internalId = "1" } },		// Order Type
				    	new StringCustomFieldRef() { scriptId = "custbody_sps_carrieralphacode", value = koSod.ShipVia.SvcAmazon },			// Standard Carrier Alpha Code
				    	new BooleanCustomFieldRef() { scriptId = "custbody_pj_sssigreq", value = koSod.ShipVia.NsIsSigReuired == 0 ? false : true },
                        new DateCustomFieldRef() { scriptId = "custbody_sps_purchaseorderdate", value =  koSot.SoDate },						// Order Date
				    	new SelectCustomFieldRef() { scriptId = "custbody_custom_location_main", value = new ListOrRecordRef() { internalId = koSod.ShipFromWh.NsIntId.ToString()} },	// Custom Location Main  
				    	new BooleanCustomFieldRef() { scriptId = "custbody_pacejet_autoimport", value = true },
                        new StringCustomFieldRef() { scriptId = "custbody_sps_customerordernumber", value =  koSot.IoNo},
                        new DateCustomFieldRef() { scriptId = "custbody_sps_date_010", value =  koSot.ExpShipDate.Value },					//REQUESTED SHIP DATE
				    	new DateCustomFieldRef() { scriptId = "custbody_sps_date_002", value =  koSot.ExpShipDate.Value },					//REQUESTED DELIVERY DATE
				    	new StringCustomFieldRef() { scriptId = "custbody_sps_buyerscurrency", value = "USD"},								// CARRIER ROUTING DESCRIPTION
				    };
                    salesOrder.customFieldList = customFields.ToArray();
                }

                List<SalesOrderItem> salesOrderItems = new List<SalesOrderItem>();
                foreach (KoSoD item in koSot.KoSoDs)
                {
                    if (item.QtyOrdered == 0)
                        continue;
                    salesOrderItems.Add(new SalesOrderItem()
                    {
                        expectedShipDate = koSot.ExpShipDate.Value,
                        expectedShipDateSpecified = true,
                        line = Convert.ToInt32(item.KoLineNo),
                        lineSpecified = true,
                        item = new RecordRef() { internalId = item.ItemNo.NsIntId.ToString() },
                        quantity = item.QtyOrdered,
                        quantitySpecified = true,
                        rate = item.UnitPrice.ToString(),
                        location = new RecordRef() { internalId = bpmLocation.NsIntId.ToString() },
                        price = new RecordRef() { internalId = "-1" },                                  // Price Level- Custom
                        customFieldList = new CustomFieldRef[]
                        {
                             new StringCustomFieldRef() { scriptId = "custcol_sps_bpn", value = item.CustSku},
                             new StringCustomFieldRef() { scriptId = "custcol_sps_vendorpartnumber", value = item.CustSku },
                             new StringCustomFieldRef() { scriptId = "custcol_sps_purchaseprice", value = $"{item.UnitPrice:0.00}"},
                             new StringCustomFieldRef() { scriptId = "custcol_sps_orderqtyuom", value = "EA" },
                             new StringCustomFieldRef() { scriptId = "custcol_sps_linesequencenumber", value = item.KoLineNo.Value.ToString() },
                        },
                    });
                    if (koSot.CustomerId == 1 || koSot.CustomerId == 2 || koSot.CustomerId == 4)
                    {
                        salesOrderItems.Last().commitInventory = SalesOrderItemCommitInventory._doNotCommit;
                        salesOrderItems.Last().commitInventorySpecified = true;
                    }
                }
                salesOrder.itemList = new SalesOrderItemList() { item = salesOrderItems.ToArray(), replaceAll = true };

                addResponse addRes = await Client.addAsync(CreateTokenPassport(), null, Partner, GetPreferences(), salesOrder);
                if (addRes.writeResponse.status.isSuccess)
                {
                    foreach (KoSoD koSoD in koSot.KoSoDs)
                        koSoD.NsSyncTime = DateTime.Now;
                    _kc.KoSoTs.Update(koSot);
                    _kc.SaveChanges();
                    ((List<List<string>>)resCollector["succeed"]).Add(new List<string>() { koSot.PoNo });
                    bool isSucced = await SOSyncNsToDb(((RecordRef)addRes.writeResponse.baseRef).internalId);
                }
                else
                {
                    ((Hashtable)resCollector["fail"]).Add(koSot.PoNo, addRes.writeResponse.status.statusDetail);
                }
            }
            return resCollector;
        }
        private async Task<bool> SOSyncNsToDb(string nsIntID)
        {
            SalesOrder nsSo = await GetSalesOrder(Convert.ToInt32(nsIntID));
            List<Models.Customer> koCustomers = _kc.Customers.ToList();
            List<Models.Country> countries = _kc.Countries.ToList();
            List<AdAfcid> koAdAFCID = _kc.AdAfcids.ToList();
            List<ShipVium> KoShipVia = _kc.ShipVia.ToList();
            List<SoStatusKo> KoSoStatus = _kc.SoStatusKos.ToList();
            List<BpmItem> koItems = _kc.BpmItems.ToList();
            List<BpmLocation> koLocations = _kc.BpmLocations.ToList();
            List<StatusItemAcpt> KoStatusItemAcpts = _kc.StatusItemAcpts.ToList();
            List<ItemPriceLevel> KoItemPriceLevels = _kc.ItemPriceLevels.ToList();

            var bodycustFields = nsSo.customFieldList.ToList();
            SoT soT = new SoT()
            {
                SoTId = Convert.ToInt32(nsIntID),
                CustomerId = koCustomers.Find(x => x.NsIntId == Convert.ToInt32(nsSo.entity.internalId)).CustomerId,
                PoNo = nsSo.otherRefNum,
                VendorCode = ((StringCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_sps_vendor"))?.value,
                PoType = ((StringCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_sps_potype"))?.value,
                IoNo = ((StringCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_web_order_number"))?.value,
                BulkBuy = (((BooleanCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_bulk_buy_po"))?.value ?? false) ? 1 : 0,
                SoNo = nsSo.tranId,
                SoDate = nsSo.tranDate,
                ShipWindowStart = ((DateCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_ship_window_start"))?.value,
                ShipWindowEnd = ((DateCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_ship_window_end"))?.value,
                ExpShipDate = nsSo.shipDate,
                ShipToName = nsSo.shippingAddress.addressee,
                Address1 = nsSo.shippingAddress.addr1,
                Address2 = nsSo.shippingAddress.addr2,
                Address3 = nsSo.shippingAddress.addr3,
                City = nsSo.shippingAddress.city,
                State = nsSo.shippingAddress.state,
                Zip = nsSo.shippingAddress.zip,
                Country = _utilMethods.CountryCodeToName(((int)nsSo.shippingAddress.country).ToString(), CountryMode.Alpha2, countries),
                PhoneNo = nsSo.shippingAddress.addrPhone,
                Email = nsSo.email,
                Memo = nsSo.memo,
                SoTotal = Convert.ToDecimal(nsSo.total),
                AddedTime = nsSo.createdDate,
                LastModTime = nsSo.lastModifiedDate,
            };
            var shipToAFC_id = koAdAFCID.Find(x => x.CustomerId == soT.CustomerId && x.FcAid == ((StringCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_sps_st_addresslocationnumber"))?.value)?.AmazonFcId;
            var shipSigReq = (((BooleanCustomFieldRef)bodycustFields.Find(x => x.scriptId == "custbody_pj_sssigreq"))?.value ?? false);
            var shipVia_id = GetShipVia(nsSo.shipMethod?.internalId, nsSo.shipIsResidential, shipSigReq, KoShipVia);
            var nsStatus = KoSoStatus.Find(s => s.StatusKo == nsSo.status)?.SoStatusKoId;

            List<SoD> soDs = new List<SoD>();
            int ksBackOrder = 3, ksCommit = 4, ksPicked = 5, ksShipped = 6, ksInvoiced = 7, ksPartial = 8, ksClosd = 9;
            foreach (var nsItem in nsSo.itemList.item)
            {
                List<CustomFieldRef> lineCustFields = nsItem.customFieldList.ToList();
                BpmItem koItem = koItems.Find(x => (x.ItemTypeId == 1 || x.ItemTypeId == 2) && x.NsIntId == Convert.ToInt32(nsItem.item.internalId));
                if (koItem == null)
                    continue;
                var sod = new SoD()
                {
                    SoTId = soT.SoTId,
                    SoDId = Convert.ToInt32(nsItem.lineUniqueKey),
                    SodLineNo = Convert.ToInt32(((StringCustomFieldRef)lineCustFields.Find(x => x.scriptId == "custcol_sps_linesequencenumber"))?.value ?? nsItem.line.ToString()),
                    SoDate = soT.SoDate,
                    ShipFromWhId = koLocations.Find(x => x.NsIntId == Convert.ToInt32(nsItem.location.internalId)).LocationId,
                    ShipToAfcId = shipToAFC_id,
                    ShipViaId = shipVia_id,
                    ShipWindowStart = soT.ShipWindowStart,
                    ShipWindowEnd = soT.ShipWindowEnd,
                    ExpShipDate = soT.ExpShipDate,
                    AcptStatusId = KoStatusItemAcpts.Find(s => s.ItAcptStatus == ((SelectCustomFieldRef)lineCustFields.Find(x => x.scriptId == "custcol_sps_itemstatuscode1"))?.value.internalId)?.AcptStatusId,
                    CommitInv = nsItem.commitInventory == SalesOrderItemCommitInventory._availableQty ? (byte)1 : (byte)0,
                    CustSku = ((StringCustomFieldRef)lineCustFields.Find(x => x.scriptId == "custcol_sps_bpn"))?.value,
                    ItemNoId = koItem.ItemNoId,
                    //ItemCat1 = koItem.Category1.Cat1,
                    //ItemCat2 = koItem.Category2.Cat2,
                    //ItemCat3 = koItem.Category3.Cat3,
                    //ItemCatZinus = koItem.CategoryZinu.CatZinus,
                    //CartLength = koItem.CartonLength,
                    //CartHeight = koItem.CartonHeight,
                    //CartWidth = koItem.CartonWidth,
                    //CartWeight = koItem.CartonWeight,
                    //PalletType_id = koItem.PalletType_id,
                    QtyOrdered = (int)nsItem.quantity,
                    QtyBackOrdered = (int)nsItem.quantityBackOrdered,
                    QtyCommitted = (int)nsItem.quantityCommitted,
                    QtyPicked = (int)nsItem.quantityPicked,
                    QtyShipped = (int)nsItem.quantityFulfilled,
                    QtyInvoiced = (int)nsItem.quantityBilled,
                    PriceLevelId = KoItemPriceLevels.Find(x => x.NsIntId == Convert.ToInt32(nsItem.price.internalId)).PriceLevelId,
                    UnitPrice = Convert.ToDecimal(nsItem.rate),
                    VatAmt = Convert.ToDecimal(nsItem.taxAmount),
                    LineTotal = Convert.ToDecimal(nsItem.amount),
                    BackOrderDate = ((DateCustomFieldRef)lineCustFields.Find(x => x.scriptId == "custcol_sps_itemscheduledate1"))?.value,
                    SoStatusNsId = nsStatus,
                    AddedTime = soT.AddedTime,
                    LastModTime = soT.LastModTime,
                };
                sod.DiscAmt = sod.LineTotal - (sod.UnitPrice * sod.QtyOrdered) - sod.VatAmt;


                if (sod.QtyOrdered == 0 || nsItem.isClosed)
                    sod.SoStatusKoId = ksClosd;       // Closed
                else if (sod.QtyBackOrdered > 0)
                    sod.SoStatusKoId = ksBackOrder;   // Partial Backorder is Backorder
                else if (sod.QtyInvoiced == sod.QtyOrdered)
                    sod.SoStatusKoId = ksInvoiced;    // Fully Invoiced
                else if (sod.QtyShipped == sod.QtyOrdered)
                    sod.SoStatusKoId = ksShipped;     // Fully Shipped
                else if (sod.QtyPicked == sod.QtyOrdered)
                    sod.SoStatusKoId = ksPicked;      // Fully Picked
                else if (sod.QtyCommitted == sod.QtyOrdered)
                    sod.SoStatusKoId = ksCommit;      // Fully Committed
                else
                    sod.SoStatusKoId = ksPartial;     // Partial

                soDs.Add(sod);
            }
            _kc.SoTs.Add(soT);
            _kc.SoDs.AddRange(soDs);
            _kc.SaveChanges();
            return true;
        }
        public async Task<SalesOrder> GetSalesOrder(int internalID)
        {
            // Set Search Preferences
            SetSearchPreferences(false, true);
            try
            {
                RecordRef recordRef = new RecordRef();
                recordRef.internalId = internalID.ToString();
                recordRef.type = RecordType.salesOrder;
                recordRef.typeSpecified = true;
                getResponse resopi = await Client.getAsync(CreateTokenPassport(), null, Partner, GetPreferences(), recordRef);
                if (resopi.readResponse.status.isSuccess)
                    return resopi.readResponse.record as SalesOrder;
                return null;
            }
            catch //(Exception ex)
            {
                return null;
            }
        }
        private int? GetShipVia(string shipMethod, bool isResd, bool isSigR, List<ShipVium> KoShipVia)
        {

            if (shipMethod == null)
                return null;
            ShippingMethod method = Enum.Parse<ShippingMethod>(shipMethod);
            if (method == ShippingMethod.ManualNoLabel)
                return KoShipVia.Find(s => s.NsShipItem == method.ToString()).ShipViaId;
            else
                return KoShipVia.Find(s => s.NsShipItem == method.ToString() && s.NsIsResidential == (isResd ? 1 : 0) && s.NsIsSigReuired == (isSigR ? 1 : 0)).ShipViaId;
        }
        public async Task<List<SearchRow>> GetDuplicateLineWalmart()
        {
            SetSearchPreferences(false, true);
            TransactionSearchAdvanced transactionSearchAdvanced = new TransactionSearchAdvanced();
            transactionSearchAdvanced.savedSearchId = "1749";

            //Define return columns
            TransactionSearchRow transactionSearchRow = new TransactionSearchRow();
            TransactionSearchRowBasic transactionSearchRowBasic = new TransactionSearchRowBasic();
            TransactionSearchRowBasic transactionjoin = new TransactionSearchRowBasic();

            transactionSearchRowBasic.internalId = new SearchColumnSelectField[] { new SearchColumnSelectField() };
            transactionSearchRowBasic.trackingNumbers = new SearchColumnStringField[] { new SearchColumnStringField() };        // Tracking#
            transactionSearchRowBasic.otherRefNum = new SearchColumnTextNumberField[] { new SearchColumnTextNumberField() };    // PO #
            transactionSearchRowBasic.shipMethod = new SearchColumnSelectField[] { new SearchColumnSelectField() };
            transactionSearchRowBasic.location = new SearchColumnSelectField[] { new SearchColumnSelectField() };
            transactionSearchRowBasic.status = new SearchColumnEnumSelectField[] { new SearchColumnEnumSelectField() };
            transactionSearchRow.fulfillingTransactionJoin = new TransactionSearchRowBasic();
            transactionjoin.customFieldList = new SearchColumnCustomField[]
            {

                new SearchColumnDateCustomField() { scriptId="custbody_bpm_if_ship_time"},		    // SW Start

            };
            transactionSearchRow.fulfillingTransactionJoin = transactionjoin;
            transactionSearchRow.basic = transactionSearchRowBasic;
            transactionSearchAdvanced.columns = transactionSearchRow;

            SearchRecord searchRecord = transactionSearchAdvanced;
            var response = await Client.searchAsync(CreateTokenPassport(), null, Partner, GetSearchPreferences(), searchRecord);

            SearchResult searchResult = response.searchResult;
            List<SearchRow> searchRows = new List<SearchRow>();
            if (searchResult.status.isSuccess)
            {
                if(searchResult.totalRecords > 0)
                {
                    for (int i = 1; i <= searchResult.totalPages; i++)
                    {

                        searchRows.AddRange(searchResult.searchRowList.ToList());
                        if (i+1 <= searchResult.totalPages)
                        {
                            searchMoreWithIdResponse responseMore = await Client.searchMoreWithIdAsync(CreateTokenPassport(), null, Partner, GetSearchPreferences(), response.searchResult.searchId, i + 1);
                            searchResult = responseMore.searchResult;
                        }
           
                    }
                }
            }
            //searchRows = searchRows.FindAll(x => ((TransactionSearchRow)x).basic.trackingNumbers != null && ((TransactionSearchRow)x).basic.status[0].searchValue != "fullyBilled");
            searchRows = searchRows.FindAll(x => ((TransactionSearchRow)x).basic.trackingNumbers != null && ((TransactionSearchRow)x).fulfillingTransactionJoin !=null);

            return searchRows;
        }

        //     public async Task<bool> TestHasPo()
        //     {

        //         DateTime date = DateTime.Now.AddMonths(-20);
        //         bool istrue = await GetSalesListByPo(date);
        //         return istrue;
        //     }
        //     public async Task<searchResponse> TestNsClient()
        //     {

        //         SetSearchPreferences(false, true);
        //         TransactionSearchAdvanced transactionSearchAdvanced = new TransactionSearchAdvanced();
        //         transactionSearchAdvanced.savedSearchId = "1292";

        //         //Define return columns
        //         TransactionSearchRow transactionSearchRow = new TransactionSearchRow();
        //         TransactionSearchRowBasic transactionSearchRowBasic = new TransactionSearchRowBasic();

        //         transactionSearchRowBasic.internalId = new SearchColumnSelectField[] { new SearchColumnSelectField() };
        //         transactionSearchRowBasic.entity = new SearchColumnSelectField[] { new SearchColumnSelectField() };                 // Customer
        //         transactionSearchRowBasic.otherRefNum = new SearchColumnTextNumberField[] { new SearchColumnTextNumberField() };    // PO #
        //         transactionSearchRowBasic.tranId = new SearchColumnStringField[] { new SearchColumnStringField() };                 // SO #
        //         transactionSearchRowBasic.tranDate = new SearchColumnDateField[] { new SearchColumnDateField() };                   // SO Date
        //         transactionSearchRowBasic.shipDate = new SearchColumnDateField[] { new SearchColumnDateField() };                   // Exp. Ship
        //         transactionSearchRowBasic.shipAddressee = new SearchColumnStringField[] { new SearchColumnStringField() };          // Ship To
        //         transactionSearchRowBasic.shipAddress1 = new SearchColumnStringField[] { new SearchColumnStringField() };           // Address 1
        //         transactionSearchRowBasic.shipAddress2 = new SearchColumnStringField[] { new SearchColumnStringField() };           // Address 2
        //         transactionSearchRowBasic.shipAddress3 = new SearchColumnStringField[] { new SearchColumnStringField() };           // Address 3
        //         transactionSearchRowBasic.shipCity = new SearchColumnStringField[] { new SearchColumnStringField() };               // City
        //         transactionSearchRowBasic.shipState = new SearchColumnStringField[] { new SearchColumnStringField() };              // State
        //         transactionSearchRowBasic.shipZip = new SearchColumnStringField[] { new SearchColumnStringField() };                // Zip
        //         transactionSearchRowBasic.shipCountry = new SearchColumnEnumSelectField[] { new SearchColumnEnumSelectField() };    // Country
        //         transactionSearchRowBasic.shipPhone = new SearchColumnStringField[] { new SearchColumnStringField() };              // Phone
        //         transactionSearchRowBasic.email = new SearchColumnStringField[] { new SearchColumnStringField() };                  // Email
        //         transactionSearchRowBasic.memo = new SearchColumnStringField[] { new SearchColumnStringField() };                   // Memo
        //         transactionSearchRowBasic.amount = new SearchColumnDoubleField[] { new SearchColumnDoubleField() };                 // SoTotal
        //         transactionSearchRowBasic.status = new SearchColumnEnumSelectField[] { new SearchColumnEnumSelectField() };         // Status
        //         transactionSearchRowBasic.dateCreated = new SearchColumnDateField[] { new SearchColumnDateField() };                // Date Created
        //         transactionSearchRowBasic.lastModifiedDate = new SearchColumnDateField[] { new SearchColumnDateField() };           // Last Modified
        //         transactionSearchRowBasic.customFieldList = new SearchColumnCustomField[]
        //         {
        //                  new SearchColumnStringCustomField() { internalId = "2124" },		// IO #
        //new SearchColumnDateCustomField() { internalId = "2122" },		    // SW Start
        //new SearchColumnDateCustomField() { internalId = "2123" },          // SW End
        //new SearchColumnBooleanCustomField() { internalId = "2632" },       // Bulk Buy PO	
        //new SearchColumnStringCustomField() { internalId = "1293" },        // PO Type
        //new SearchColumnStringCustomField() { internalId = "1309" },		// Ship To AFC
        //new SearchColumnStringCustomField() { internalId = "1234" },        // Vendor Number
        //         };
        //         //Apply search return columns
        //         transactionSearchRow.basic = transactionSearchRowBasic;
        //         transactionSearchAdvanced.columns = transactionSearchRow;

        //         SearchRecord searchRecord = transactionSearchAdvanced;
        //         var response = await Client.searchAsync(CreateTokenPassport(), null, Partner, GetSearchPreferences(), searchRecord);
        //         return response;
        //     }
    }
}


