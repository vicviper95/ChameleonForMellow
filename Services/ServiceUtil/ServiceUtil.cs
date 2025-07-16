using Chameleon.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text;

namespace Chameleon.Services.ServiceUtil
{
    public enum ErrorType
    {
        Unknown = 1,
        NotFoundFromDB = 2,
        ErrResponse = 3,
    }
    public enum SearchType
    {
        Date,
        PoNumber,
    }
    public enum ProcessType
    {
        GetOrder = 1,
		SendASN = 2,
		SendAck = 3,
    }
    public enum CountryMode
    {
        FullName,
        Alpha2,
        Alpha3,
    }


	public enum PurchaseOrderState
	{
		[System.Runtime.Serialization.EnumMember(Value = "New")]
		New = 0,

		[System.Runtime.Serialization.EnumMember(Value = "Acknowledged")]
		Acknowledged = 1,

		[System.Runtime.Serialization.EnumMember(Value = "Closed")]
		Closed = 2,

	}
	public enum ShippingMethod
	{
		[Display(Name = "Airborne")]
		Airborne = 2,
		[Display(Name = "FedEx")]
		FedEx = 3,
		[Display(Name = "UPS")]
		UPS = 4,
		[Display(Name = "FedEx 2 Day")]
		FedEx2Day = 7,
		[Display(Name = "FedEx 3 Day")]
		FedEx3Day = 8,
		[Display(Name = "FedEx Ground")]
		FedExGround = 9,
		[Display(Name = "FedEx Home Delivery")]
		FedExHomeDelivery = 10,
		[Display(Name = "FedEx Priority Overnight")]
		FedExPriorityOvernight = 11,
		[Display(Name = "FedEx Standard Overnight")]
		FedExStandardOvernight = 12,
		[Display(Name = "LTL Paperwork Only Carrier")]
		LTLPaperworkOnlyCarrier = 13,
		[Display(Name = "UPS 2nd Day Air")]
		UPS2ndDayAir = 14,
		[Display(Name = "UPS 3 Day Select")]
		UPS3DaySelect = 15,
		[Display(Name = "UPS Ground")]
		UPSGround = 16,
		[Display(Name = "UPS Next Day Air")]
		UPSNextDayAir = 17,
		[Display(Name = "UPS Next Day Air Saver")]
		UPSNextDayAirSaver = 18,
		[Display(Name = "USPS First Class")]
		USPSFirstClass = 19,
		[Display(Name = "USPS Parcel Ground Select")]
		USPSParcelGroundSelect = 20,
		[Display(Name = "USPS Priority")]
		USPSPriority = 21,
		[Display(Name = "USPS Priority Mail Express")]
		USPSPriorityMailExpress = 22,
		[Display(Name = "LTL Paperwork Only Carrier Other")]
		LTLPaperworkOnlyCarrierOther = 2534,
		[Display(Name = "Manual-No-Label")]
		ManualNoLabel = 2541,
		[Display(Name = "Other – Standard")]
		OtherStandard = 2543,
		[Display(Name = "LTL AMZL")]
		LTLAMZL = 4497,
		[Display(Name = "3P LTL")]
		_3PLTL = 4699,
		[Display(Name = "EU BJS Distribution")]
		EUBJSDistribution = 5101,
		[Display(Name = "EU DHL Parcel UK GR")]
		EUDHLParcelUKGR = 5102,
		[Display(Name = "WMT_BULK_LTL")]
		WMT_BULK_LTL = 5815,
		[Display(Name = "UPS - UK GR")]
		UPS_UK_GR = 6016,
		[Display(Name = "UPS - DEU GR")]
		UPS_DEU_GR = 6017,
	}
	public class UtilMethods
    {
		private readonly KOALAContext _kc;
		public UtilMethods(KOALAContext kc)
        {
			_kc = kc;
        }
		public void AddInvalidation(List<SoError> errorApis, string detail, string PoNo, string partNumber, ErrorType errorType, int? CustomerId, ProcessType processType)
		{
			SoError errorSo = new SoError();
			errorSo.ProcessId = (int)processType;
			errorSo.Detail = detail;
			errorSo.ErrorCatId = ((int)errorType);
			errorSo.IsResolved = false;
			errorSo.CeatedTime = DateTime.Now;
			errorSo.CustomerId = CustomerId.Value;
			errorSo.PoNo = PoNo;
			errorSo.CustSku = partNumber;
			errorApis.Add(errorSo);
		}
		public void CheckResolved(List<SoError> errorApis, string detail, string PoNo, string partNumber, ErrorType errorType, int? CustomerId, ProcessType processType)
		{
			SoError errorSo = new SoError();
			errorSo.ProcessId = (int)processType;
			errorSo.Detail = detail;
			errorSo.ErrorCatId = ((int)errorType);
			errorSo.IsResolved = false;
			errorSo.CeatedTime = DateTime.Now;
			errorSo.CustomerId = CustomerId.Value;
			errorSo.PoNo = PoNo;
			errorSo.CustSku = partNumber;
			errorApis.Add(errorSo);
		}
		public string CountryCodeToName(string code, CountryMode isRerunMode, List<Models.Country> _Countries)
		{
			try
			{
				var country = _Countries.Find(x => x.FullName == code || x.Alpha2 == code || x.Alpha3 == code|| x.NsIntId.ToString() == code);
				if (country == null)
					return null;

				switch (isRerunMode)
				{
					case CountryMode.FullName:
						return country.FullName;
					case CountryMode.Alpha2:
						return country.Alpha2;
					case CountryMode.Alpha3:
						return country.Alpha3;
				}
			}
			catch
			{
			}
			return null;
		}
		public void BuildSyncResData(Hashtable res, object key, string msg) 
        {
			List<string> values = new List<string>();
            if (res.ContainsKey(key))
            {
				((List<string>)res[key]).Add(msg);
			}
			else
            {
				values.Add(msg);
				res.Add(key, values);
            }
        }
		public string BuildEmailLine(string original, string msg)
        {
			if (original == "")
				return original += msg;
			else
				return original += $"<br/>{msg}";
        }


		#region Pick Warehouse
		private class AvlLocation
		{
			public int Location { get; set; }
			public int OriginZIP { get; set; }
			public decimal Distance { get; set; }
		}
		private class AvailByLoc
		{
			public int ItemNo_id { get; set; }    // ItemNo_id
			public List<QtyByLoc> QtyAvlByLoc { get; set; }
			public int QtyTotal => QtyAvlByLoc.Sum(x => x.Qty);

			public class QtyByLoc
			{
				public int Location { get; set; }
				public int Qty { get; set; }
			}
		}
		public class ZipCodeAPIModel
		{
			[JsonProperty("post code")]
			public int PostCode { get; set; }
			[JsonProperty("country")]
			public string Country { get; set; }
			[JsonProperty("country abbreviation")]
			public string CountryAbbreviation { get; set; }
			[JsonProperty("places")]
			public List<Place> Places { get; set; }

			public class Place
			{
				[JsonProperty("place name")]
				public string PlaceName { get; set; }
				[JsonProperty("longitude")]
				public decimal Longitude { get; set; }
				[JsonProperty("latitude")]
				public decimal Latitude { get; set; }
				[JsonProperty("state")]
				public string State { get; set; }
				[JsonProperty("state abbreviation")]
				public string StateAbbreviation { get; set; }
			}
		}
		private void GetFedexZoneToDestZip(int dzip, List<ZipToLocation> zipInfos, List<AvlLocation> locations)
		{
			var toLocation = zipInfos.Find(x => x.ZipCode == dzip);
			foreach (var loc in locations)
			{
				var fromLocation = zipInfos.Find(x => x.ZipCode == loc.OriginZIP);
				loc.Distance = CalculateBetweenZipCodes(fromLocation, toLocation);
			}
		}
		#region CalculateBetweenZipCode
		/// <summary>
		/// Calculate Distance Between ZipCodes
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns>Distance(Miles)</returns>
		private decimal CalculateBetweenZipCodes(ZipToLocation from, ZipToLocation to)
		{
			var latitudeFrom = Convert.ToDouble(from.Latitude < 0 ? from.Latitude + 360 : from.Latitude);
			var longitudeFrom = Convert.ToDouble(from.Longitude < 0 ? from.Longitude + 360 : from.Longitude);
			var latitudeTo = Convert.ToDouble(to.Latitude < 0 ? to.Latitude + 360 : to.Latitude);
			var longitudeTo = Convert.ToDouble(to.Longitude < 0 ? to.Longitude + 360 : to.Longitude);

			var differenceLatitude = Math.Abs(latitudeFrom - latitudeTo);
			if (differenceLatitude > 180)
				differenceLatitude = 360 - differenceLatitude;
			var differenceLongitude = Math.Abs(longitudeFrom - longitudeTo);
			if (differenceLongitude > 180)
				differenceLongitude = 360 - differenceLongitude;

			var flatEarth = CalculateFlatEarthMethod(latitudeFrom, longitudeFrom, latitudeTo, longitudeTo);
			var haversine = CalculateHaversineMethod(latitudeFrom, longitudeFrom, latitudeTo, longitudeTo);
			return Convert.ToDecimal(haversine);
		}

		#region CalculateFlatEarthMethod
		private double CalculateFlatEarthMethod(double fromLatitude, double fromLongitude, double toLatitude, double toLongitude)
		{
			var differenceLatitude = Math.Abs(fromLatitude - toLatitude);
			if (differenceLatitude > 180)
				differenceLatitude = 360 - differenceLatitude;

			var differenceLongitude = Math.Abs(fromLongitude - toLongitude);
			if (differenceLongitude > 180)
				differenceLongitude = 360 - differenceLongitude;

			var x = 69.1 * differenceLatitude;
			var y = 53.0 * differenceLongitude;

			return Math.Sqrt(x * x + y * y);
		}
		#endregion

		#region CalculateHaversineMethod
		private const double EARTH_RADIUS = 3958.756;
		private double CalculateHaversineMethod(double fromLatitude, double fromLongitude, double toLatitude, double toLongitude)
		{
			double differenceLatitude = GetRadian(toLatitude - fromLatitude);
			double differenceLongitude = GetRadian(toLongitude - fromLongitude);

			double a = Math.Sin(differenceLatitude / 2) * Math.Sin(differenceLatitude / 2) +
					 Math.Cos(GetRadian(fromLatitude)) * Math.Cos(GetRadian(toLatitude)) *
					 Math.Sin(differenceLongitude / 2) * Math.Sin(differenceLongitude / 2);

			return 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)) * EARTH_RADIUS;
		}
		private double GetRadian(double degree)
		{
			return degree / 180 * Math.PI;
		}
		#endregion
		#endregion
		private string CleanUpZipCode(string zip)
		{
			if (zip.Contains("-"))
				return zip.Split('-')[0];
			return zip;
		}

        private List<int> BALocations = new List<int>() { 4, 62 };
        private List<int> NoPickBAItems = new List<int>
        {
            2789,2791,2790,2788,1614,1613,1612,1611,1610,2793,2795,2794,2792,2209,1609,1608,1607,1606,1605,2208,1716,1717,1718,1719,2222,2218,2221,2220,2219,2216,2217,1604,1603,1602,1601,1600,1599,1598,2777,2779,2778,2776,2781,2783,2782,2780,2785,2787,2786,2784,1597,1596,1595,1594,1593,1592,1591,1590,1589,1588,1587,1586
        };

        public async Task<SoT> SetPickWarehouse(SoT sot)
		{
			int MinimumQty = 5;

			//KOALAContext _kc = new KOALAContext();
			//sot = _kc.SoTs.Include(x => x.SoDs).ThenInclude(x => x.ItemNo).ThenInclude(x => x.BomParentItems).ThenInclude(x => x.ChildItem)
			//		.AsNoTracking()
			//		.Where(x => x.SoTId == sot.SoTId).FirstOrDefault();
			//if (sot == null)
			//	return sot;

			//int gItidUNK = (from a in _kc.BpmItems where a.ItemName == "UNKNOWN" select a.ItemNoId).Single();
			//List<SoD> sods = sot.SoDs.Where(x => x.ShipFromWhId == whidTBD && x.ItemNoId != gItidUNK && x.ItemNo.ItemTypeId < 3).ToList();
			//if (sods.Count == 0)
			//	return sot;

			#region Define Warehouses
			List<AvlLocation> pickWHs = null;						
			if (sot.SoDs.Any(x => NoPickBAItems.Contains(x.ItemNoId)))
			{
			    pickWHs = _kc.BpmLocations.Where(x => x.IsDropShip == true && BALocations.Contains(x.LocationId) == false)
			                .Select(x => new AvlLocation
			                {
			                    Location = x.LocationId,
			                    OriginZIP = Convert.ToInt32(x.Zip),
			                }).AsNoTracking().ToList();
			}
			else
			{
			    pickWHs = _kc.BpmLocations.Where(x => x.IsDropShip == true)
			                .Select(x => new AvlLocation
			                {
			                    Location = x.LocationId,
			                    OriginZIP = Convert.ToInt32(x.Zip),
			                }).AsNoTracking().ToList();
			}
            #endregion

            #region Get Qty Avail of Warehouses
            // get item list Signal/Kit

            var oItems = sot.SoDs.Where(x => x.ItemNo.ItemTypeId == 1).Select(x => x.ItemNo.ItemNoId).ToList();
			oItems.AddRange(sot.SoDs.Where(x => x.ItemNo.ItemTypeId == 2).SelectMany(x => x.ItemNo.BomParentItems).Select(x => x.ChildItem.ItemNoId));
			var currentInvs = _kc.InvRealTimes.Where(x => oItems.Contains(x.ItemNoId)).ToList();
			List<AvailByLoc> qavailAllItem = new List<AvailByLoc>();
			foreach (var inv in currentInvs.GroupBy(x => x.ItemNoId))
			{
				qavailAllItem.Add(new AvailByLoc
				{
					ItemNo_id = inv.Key,
					QtyAvlByLoc = inv.ToList().Select(x => new AvailByLoc.QtyByLoc { Location = x.LocationId, Qty = x.QtyAvail }).ToList(),
				});
			}
			var avlAllLocs = qavailAllItem.FindAll(x => oItems.Contains(x.ItemNo_id) && x.QtyAvlByLoc.Any(z => z.Qty > MinimumQty));
			if (avlAllLocs == null || avlAllLocs.Count < oItems.Count)
			{
                // No inventory in all location
                foreach (var line in sot.SoDs)
                {
                    line.ShipFromWhId = 32;
                }
                return sot;
			}
			#endregion

			#region Make Zip Code Table
			var soZipCode = Convert.ToInt32(CleanUpZipCode(sot.Zip));
			var koZip = _kc.ZipToLocations.FirstOrDefault(x => x.ZipCode == soZipCode);
			if (koZip == null)
			{
				#region Add Zip code info with API
				try
				{
					using (var httpClient = new HttpClient())
					{
						using (var response = await httpClient.GetAsync($"https://api.zippopotam.us/us/{soZipCode}"))
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							var zipResult = JsonConvert.DeserializeObject<ZipCodeAPIModel>(apiResponse);
							if (zipResult != null && zipResult.PostCode > 0 && zipResult.Places.Count > 0)
							{
								_kc.ZipToLocations.Add(new ZipToLocation
								{
									ZipCode = soZipCode,
									Latitude = zipResult.Places.First().Latitude,
									Longitude = zipResult.Places.First().Longitude,
								});
								_kc.SaveChanges();
							}
						}
					}
				}
				catch (Exception ex)
				{
					//Log.Error("Add Zip Code {ex}", ex.InnerException?.Message ?? ex.Message);
				}
				#endregion
			}
			var zips = pickWHs.Select(x => Convert.ToInt32(x.OriginZIP)).ToList();
			zips.Add(soZipCode);
			zips = zips.Distinct().ToList();
			var zipInfos = _kc.ZipToLocations.Where(x => zips.Contains(x.ZipCode)).ToList();
			if (zips.Count != zipInfos.Count)
			{
				StringBuilder ebody = new StringBuilder();
				foreach (var zip in zips.FindAll(x => zipInfos.Select(z => z.ZipCode).Contains(x) == false))
				{
					if (zipInfos.Find(x => x.ZipCode == zip) == null)
					{
						var zipInfo = _kc.ZipToLocations.FirstOrDefault(x => x.ZipCode < zip);
						if (zipInfo == null)
							zipInfo = _kc.ZipToLocations.FirstOrDefault(x => x.ZipCode > zip);
						if (zipInfo != null)
							zipInfos.Add(new ZipToLocation() { ZipCode = zip, Latitude = zipInfo.Latitude, Longitude = zipInfo.Longitude });
						ebody.AppendLine($"Zip Code: {zip}");
					}
				}
				//Email.Send("Unknown ZIP Code", ebody.ToString(), "minkyung.yi@mellow-home.com", "");
				MailService.Send("Unknown ZIP Code", ebody.ToString(), "minkyung.yi@mellow-home.com", "");

			}
			#endregion

			#region Set Warehouse
			GetFedexZoneToDestZip(soZipCode, zipInfos, pickWHs);
			var zoneLocation = pickWHs.OrderBy(x => x.Distance).ToList();
			int? sfwid = null;
			List<int> expLocation_id = new List<int>();
		relocation:
			foreach (var line in sot.SoDs)
			{
				#region Find Ship from location
				if (line.ItemNo.ItemTypeId == 1)
				{
					#region Single Item
					var avlItem = avlAllLocs.Find(x => x.ItemNo_id == line.ItemNoId);
					var avlLocations = avlItem.QtyAvlByLoc.OrderByDescending(x => x.Qty).ToList();
					avlLocations.RemoveAll(x => expLocation_id.Contains(x.Location));
					if (sfwid == null)
					{
						foreach (var zoneLoc in zoneLocation)
						{
							var avlLoc = avlLocations.Find(x => x.Location == zoneLoc.Location && x.Qty > MinimumQty && x.Qty > line.QtyOrdered);
							if (avlLoc != null)
							{
								sfwid = avlLoc.Location;
								avlLoc.Qty -= line.QtyOrdered;
								break;
							}
						}
					}
					else
					{
						var zoneLoc = zoneLocation.Find(x => x.Location == sfwid);
						var avlLoc = avlLocations.Find(x => x.Location == zoneLoc.Location && x.Qty > MinimumQty && x.Qty > line.QtyOrdered);
						if (avlLoc != null)
						{
							sfwid = avlLoc.Location;
							avlLoc.Qty -= line.QtyOrdered;
						}
						else if (sfwid != null)
						{
							expLocation_id.Add(sfwid.Value);
							sfwid = null;
							goto relocation;
						}
						else
						{
							sfwid = null;
							break;
						}
					}
					#endregion
				}
				else if (line.ItemNo.ItemTypeId == 2)
				{
					#region Kit Item
					foreach (var bom in line.ItemNo.BomParentItems)
					{
						var avlItem = avlAllLocs.Find(x => x.ItemNo_id == bom.ChildItemId);
						var avlLocations = avlItem.QtyAvlByLoc.OrderByDescending(x => x.Qty).ToList();
						if (sfwid == null)
						{
							foreach (var zoneLoc in zoneLocation)
							{
								var avlLoc = avlLocations.Find(x => x.Location == zoneLoc.Location && x.Qty > MinimumQty && x.Qty > line.QtyOrdered);
								if (avlLoc != null)
								{
									sfwid = avlLoc.Location;
									avlLoc.Qty -= bom.KittingQty * line.QtyOrdered;
									break;
								}
							}
						}
						else
						{
							var zoneLoc = zoneLocation.Find(x => x.Location == sfwid);
							var avlLoc = avlLocations.Find(x => x.Location == zoneLoc.Location && x.Qty > MinimumQty && x.Qty > line.QtyOrdered);
							if (avlLoc != null)
							{
								sfwid = avlLoc.Location;
								avlLoc.Qty -= bom.KittingQty * line.QtyOrdered;
							}
							else
							{
								sfwid = null;
								break;
							}
						}
					}
					#endregion
				}
				#endregion
			}
			if (sfwid != null)
			{
				foreach (var line in sot.SoDs)
				{
					line.ShipFromOrigId = sfwid.Value;
					line.ShipFromWhId = sfwid.Value;
				}
				//_kc.BulkUpdate(sods);
			}
			#endregion
			return sot;
		}
		#endregion
	}

}
