using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chameleon.DTOs.Inventory;
using Chameleon.Models;
using Chameleon.Services.InventoryService;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Net.Mail;
using System.Net;
using System.Text.Json.Serialization;
using Org.BouncyCastle.Ocsp;
using Chameleon.Services.UtilityService;
using Chameleon.DTOs.Utility;

namespace Chameleon.Controllers
{
  [Route("Inventory")]
  [ApiController]
  public class InventoryController : Controller
  {
    private readonly KOALAContext _kc;

    private readonly IInventoryService _invService;
    private readonly IUtilityService _utilService;
    private class MainFeedsStatus
    {
      public int feedsStatus { get; set; }
      public string customMessage { get; set; }
    }
    // Initialize
    public InventoryController(KOALAContext context, IInventoryService inventoryService, IUtilityService utilityService)
    {
      _kc = context;
      _invService = inventoryService;
      _utilService = utilityService;
    }

    private class InvFeedersEmail
    {
      public string LoginID { get; set; }
    }


    // GET: InventoryItemDTOes
    // For Inventory Main Index
    // By Brian Yi on 04/23/2021
    [Authorize]
    [HttpGet]
    public ViewResult Index()
    {
      return View();
    }

    // GET: InventoryItemDTOes
    // For Inventory Mainsl & BANC Index
    // By Brian Yi on 04/28/2021
    [Authorize]
    [HttpGet("InvMainslBancIdx")]
    public ViewResult InvMainslBancIdx()
    {
      return View();
    }


    //
    // GET: InventoryItemDTOes
    // For Inventory Mainsl & BANC Index
    // By Brian Yi on 05/05/2021
    // For TEST ONLY!!!!
    [HttpGet("InvMainslBancCnddIndx")]
    public ViewResult InvMainslBancCnddIndx()
    {
      return View();
    }


    // GET: InventoryItemDTOes
    // For Inventory Sales History Index
    // By Brian Yi on 04/29/2021
    [Authorize]
    [HttpGet("InvSalesHistoryIdx")]
    public ViewResult InvSalesHistoryIdx()
    {
      return View();
    }

    // GET: InventoryItemDTOes
    // For Inventory Feeds Index
    // By Brian Yi on 04/30/2021
    [Authorize]
    [HttpGet("InvFeedsIdx")]
    public ViewResult InvFeedsIdx()
    {
      return View();
    }


    // For Inventory Feeds Wayfair
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvFeedsWyfrIdx")]
    public ViewResult InvFeedsWyfrIdx()
    {
      return View();
    }

    // For Inventory Feeds Walmart
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvFeedsWlmrtIdx")]
    public ViewResult InvFeedsWlmrtIdx()
    {
      return View();
    }

    // For Inventory Feeds Overstock
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvFeedsOstIdx")]
    public ViewResult InvFeedsOstIdx()
    {
      // For Test Page
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 0) 
      //  return View("InvRedirect");
      return View();
    }

    // For Inventory Feeds Amazon
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvFeedsAmzIdx")]
    public ViewResult InvFeedsAmzIdx()
    {
      return View();
    }

    // For Inventory Feeds eBay
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvFeedeBayIdx")]
    public ViewResult InvFeedeBayIdx()
    {
      return View();
    }


    // For Inventory Feeds others(BPM & Mellow)
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvFeedeOthersIdx")]
    public ViewResult InvFeedeOthersIdx()
    {
      return View();
    }

    // For Inventory Feeds etc(BPM & Mellow)
    // By Brian Yi on 06/01/2021
    [Authorize]
    [HttpGet("InvRemarkCategoryIdx")]
    public ViewResult InvRemarkCategoryIdx()
    {
      return View();
    }

    // For Inventory Feeds BPM Web
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("InvFeedsBPMWebIdx")]
    public ViewResult InvFeedsBPMWebIdx()
    {
      return View();
    }

    // For Inventory Feeds Mellow Home
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("InvFeedsMellowHomeIdx")]
    public ViewResult InvFeedsMellowHomeIdx()
    {
      return View();
    }

    // For Inventory Feeds Houzz
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("InvFeedsHouzzIdx")]
    public ViewResult InvFeedsHouzzIdx()
    {
      return View();
    }

    // For Inventory Feeds eBay
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("InvFeedseBayIdx")]
    public ViewResult InvFeedseBayIdx()
    {
      return View();
    }

    // For Inventory Feeds Home Depot
    // By Brian Yi on 06/10/2022
    [Authorize]
    [HttpGet("InvFeedsHomeDepotIdx")]
    public ViewResult InvFeedsHomeDepotIdx()
    {
      return View();
    }

    // For Inventory Feeds Home Depot
    // By Brian Yi on 06/10/2022
    [Authorize]
    [HttpGet("InvFeedsTargetIdx")]
    public ViewResult InvFeedsTargetIdx()
    {
      return View();
    }

    //InvFeedsSetsStatusIdx

    // For Inventory Feeds Sets Status
    // By Brian Yi on 06/15/2022
    [Authorize]
    [HttpGet("InvFeedsSetsStatusIdx")]
    public ViewResult InvFeedsSetsStatusIdx()
    {
      return View();
    }

    // Getting BPM Web & Mellow Home Feeding list
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("GetShopifyInvFeeds")]
    public async Task<IActionResult> GetShopifyInvFeedsHistory(string customerId, string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      int custId = int.Parse(customerId);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsShopify(custId, today));
      return jsonData;
    }

    // Getting eBay Feeding list
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("GeteBayInvFeeds")]
    public async Task<IActionResult> GeteBayInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedseBay(today));

      return jsonData;
    }

    // Getting eBay Feeding list
    // By Brian Yi on 06/07/2022
    [Authorize]
    [HttpGet("GeteBayMIPInvFeeds")]
    public async Task<IActionResult> GeteBayMIPInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedseBay(today));

      return jsonData;
    }

    //GetTargetInvFeeds

    // Getting Target Feeding list
    // By Brian Yi on 06/07/2022
    [Authorize]
    [HttpGet("GetTargetInvFeeds")]
    public async Task<IActionResult> GetTargetInvFeeds(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetTargetInvFeeds(today));

      return jsonData;
    }

    // GetTargetPastInvFeeds
    // By Brian Yi on 06/07/2022
    [Authorize]
    [HttpGet("GetTargetPastInvFeeds")]
    public async Task<IActionResult> GetTargetPastInvFeeds(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetTargetPastInvFeeds(today));

      return jsonData;
    }


    // Getting Home Depot Feeding list
    // By Brian Yi on 06/07/2022
    [Authorize]
    [HttpGet("GetHomeDepotInvFeeds")]
    public async Task<IActionResult> GetHomeDepotInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetHomeDepotInvFeeds(today));

      return jsonData;
    }

    // Getting Houzz Feeding list
    // By Brian Yi on 09/17/2021
    [Authorize]
    [HttpGet("GetHouzzInvFeeds")]
    public async Task<IActionResult> GetHouzzInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsHouzz(today));
      return jsonData;
    }


    //For Inventory Feeds Setting
    // By Brian Yi on 06/30/2021
    [Authorize]
    [HttpGet("InvFeedsSetting")]
    public async Task<ViewResult> InvFeedsSetting()
    {
      InvFeedsGeneralSettingDTO invFeedsGeneralSettingDTO = await _invService.GetInvFeedsGeneralSetting();
      return View(invFeedsGeneralSettingDTO);
    }

    //For Inventory Feeds Setting
    // By Brian Yi on 06/30/2021
    [Authorize]
    [HttpPost("UpdateInvFeedsSetting")]
    public async Task<IActionResult> UpdateInvFeedsSetting(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      //InvFeedsGeneralSettingDTO
      //UpdateInvFeedsSetting
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      InvFeedsGeneralSettingDTO invFeedsGeneralSettingDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsGeneralSettingDTO>(json);

      bool result = await _invService.UpdateInvFeedsSetting(empId, invFeedsGeneralSettingDTO);

      if (result == true) return Ok(StatusCode(200));

      /*
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      string tmp = json.Remove(json.IndexOf("["),1);
      tmp = tmp.Remove(tmp.LastIndexOf("]"),1);

      InvFeedsRemarkSKUGroupListDTO updatedList = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsRemarkSKUGroupListDTO>(tmp);
      

      bool result = await _invService.UpdateInvFeedsRemarkGroupList(empId, updatedList);
      
      if(result == true) return Ok(StatusCode(200));*/
      return View(invFeedsGeneralSettingDTO);
    }


    // Getting Inventory Feeds Remark
    // By Brian Yi on 06/18/21
    //[Authorize]
    [HttpGet("GetInvFeedsRemarkCategory")]
    public async Task<IActionResult> GetInvFeedsRemarkCategory(string option)
    {
      int op = int.Parse(option);
      List<InvFeedsRmrkCtgry> result = null;
      if (op == 0) // Everything
      {
        result = await _kc.InvFeedsRmrkCtgries
          .ToListAsync();
      }
      else if (op == 1) // Only for activated ones
      {
        result = await _kc.InvFeedsRmrkCtgries
          .Where(i => i.IsActivated == true)
          .ToListAsync();
      }
      else // in case
      {
        result = await _kc.InvFeedsRmrkCtgries
          .ToListAsync();
      }

      var jsonData = Json(result);
      return jsonData;
    }


    // Getting Amazon feeds history
    // By Brian Yi on 06/12/21
    [Authorize]
    [HttpGet("GetAmazonInvFeeds")]
    public async Task<IActionResult> GetAmazonInvFeedsHistory(string historyDate)
    {
      // For test
      //string strDate = "May 10, 2021";
      DateTime today = DateTime.Parse(historyDate);

      //DateTime today = this.getLatestDateForInventory(DateTime.Now);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazon(today));
      return jsonData;
    }

    // Getting Amazon feeds history(BANC)
    // By Brian Yi on 06/25/2021
    [Authorize]
    [HttpGet("GetAmazonBancInvFeeds")]
    public async Task<IActionResult> GetAmazonBancInvFeedsHistory(string historyDate)
    {
      // For test
      //string strDate = "May 10, 2021";
      DateTime today = DateTime.Parse(historyDate);

      int locId = 4; // For Banc
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }

    // Getting Amazon feeds history(BASC)
    // By Brian Yi on 06/07/2022
    [Authorize]
    [HttpGet("GetAmazonBascInvFeeds")]
    public async Task<IActionResult> GetAmazonBascInvFeedsHistory(string historyDate)
    {
      // For test
      //string strDate = "May 10, 2021";
      DateTime today = DateTime.Parse(historyDate);

      int locId = 62; // For Basc
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }

    // Getting Amazon feeds history(Mainsl)
    // By Brian Yi on 06/25/2021
    [Authorize]
    [HttpGet("GetAmazonMainslInvFeeds")]
    public async Task<IActionResult> GetAmazonMainslInvFeedsHistory(string historyDate)
    {
      // For test
      //string strDate = "May 10, 2021";
      DateTime today = DateTime.Parse(historyDate);

      int locId = 25; // For Mainsl
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }

    // Getting Amazon feeds history(SWCAFT)
    // By Brian Yi on 12/22/2021
    [Authorize]
    [HttpGet("GetAmazonSWCAFTInvFeeds")]
    public async Task<IActionResult> GetAmazonSWCAFTInvFeedsHistory(string historyDate)
    {
      // For test
      //string strDate = "May 10, 2021";
      DateTime today = DateTime.Parse(historyDate);

      int locId = 54; // For SWCA-FT
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }


    // Getting Amazon feeds history(PRISM-CAST)
    // By Brian Yi on 06/09/2023
    [Authorize]
    [HttpGet("GetAmazonPrismCastInvFeeds")]
    public async Task<IActionResult> GetAmazonPrismCastInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      int locId = 51; // For PRISM-CAST
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }

    // Getting Amazon feeds history(PRISM-CALT)
    // By Brian Yi on 06/09/2023
    [Authorize]
    [HttpGet("GetAmazonPrismCaltInvFeeds")]
    public async Task<IActionResult> GetAmazonPrismCaltInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      int locId = 67; // For PRISM-CAST
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }


    // Getting Amazon feeds history(ZINUS-TRACY)
    // By Brian Yi on 03/12/2024
    [Authorize]
    [HttpGet("GetAmazonZinusTracyInvFeeds")]
    public async Task<IActionResult> GetAmazonZinusTracyInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      int locId = 57; // For ZINUS-TRACY
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }


    // Getting Amazon feeds history(ZINUS-CHS)
    // By Brian Yi on 03/12/2024
    [Authorize]
    [HttpGet("GetAmazonZinusChsInvFeeds")]
    public async Task<IActionResult> GetAmazonZinusChsInvFeedsHistory(string historyDate)
    {
      DateTime today = DateTime.Parse(historyDate);

      int locId = 108; // For ZINUS-CHS
      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetInvFeedsAmazonRev(locId, today));
      return jsonData;
    }



    // For all inventory items
    // Need to fix 
    [Authorize]
    [HttpGet("GetAllItems")]
    public async Task<IActionResult> GetAll()
    {
      // For test
      //string strDate = "May 10, 2021";
      //DateTime today = DateTime.Parse(strDate);

      DateTime today = this.getLatestDateForInventory(DateTime.Now);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetAllInventory(today));
      return jsonData;
    }

    // For MAINSL & BANC Inventory only
    // By Brian Yi on 04/29/2021
    [Authorize]
    [HttpGet("GetMainslBancInvItems")]
    public async Task<IActionResult> GetMainslBancInv(string today)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      // For test
      //string strDate = "May 10, 2021";
      DateTime todayDate = DateTime.Parse(today);

      //DateTime today = this.getLatestDateForInventory(DateTime.Now);

      // For future reference: On this way, you can get Json with data section
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });

      var jsonData = Json(await _invService.GetMainslBancInv(empId, todayDate));
      //var jsonData = Json(await _invService.GetAdvInv(today));

      return jsonData;

    }

    // For Notes & Rules for Inventory only
    // By Brian Yi on 05/06/2021
    //[Authorize]
    [HttpGet("GetAllMainslBancInvNotes")]
    public async Task<IActionResult> GetMainslBancInvNotes()
    {
      // 1: Inventory related
      int notesRulesCategory = 1;

      var jsonData = Json(await _invService.GetAllAvailableInventoryNotesRules(notesRulesCategory));
      return jsonData;
    }

    // For Notes & Rules for Inventory only
    // By Brian Yi on 05/10/2021
    [Authorize]
    [HttpGet("GetAMainslBancInvNote")]
    public async Task<IActionResult> GetMainslBancInvNote(int id)
    {
      var jsonData = Json(await _invService.GetAvailableInventoryNotesRules(id));
      return jsonData;
    }

    // For Rules for Inventory Feeding
    // By Brian Yi on 05/11/2021
    [Authorize]
    [HttpGet("GetAllMainslBancInvFeedRules")]
    public async Task<IActionResult> GetMainslBancInvFeedsRules()
    {
      var jsonData = Json(await _invService.GetAvailableInvFeedRules());
      return jsonData;
    }

    // For Getting Fast Moving SKUs
    // By Brian Yi on 06/05/2024
    [Authorize]
    [HttpGet("GetFastMovingSkus")]
    public async Task<IActionResult> GetFastMovingSkus(string today, string fromClick)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      DateTime todayDate = DateTime.Parse(today);

      //var jsonData = Json(await _invService.GetAvailableInvFeedRules());

      var jsonData = Json(await _invService.GetFastMovingSkus(empId, todayDate, fromClick));

      return jsonData;

    }

    [Authorize]
    [HttpGet("GetInvSalesHistory")]
    public async Task<IActionResult> GetInvSalesHistory(string startDate, string endDate)
    {
      // For test
      //DateTime today = DateTime.Today;
      //string strDate = "May 10, 2021";
      //DateTime today = DateTime.Parse(strDate);
      //string strDate = "January 1, 2021";
      //DateTime today = this.getLatestDateForInventory(DateTime.Now);
      //DateTime startDate01 = DateTime.Parse(strDate);

      //DateTime fromDate = DateTime.Parse(startDate);
      //DateTime toDate = DateTime.Parse(endDate);


      DateTime startHisDate = DateTime.Parse(startDate);
      DateTime endHisDate = DateTime.Parse(endDate);



      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });
      var jsonData = Json(await _invService.GetInvSalesHist(startHisDate, endHisDate));
      return jsonData;
      //return Json(new { data = await _invService.GetAllInventoryItem(today) });
    }

    // For Inventory Feeds jQuery Datatabale
    [Authorize]
    [HttpGet("GetInvFeeds")]
    public async Task<IActionResult> GetInvFeeds(string today, string startDate, string endDate)
    {
      //DateTime today = this.getLatestDateForInventory(DateTime.Now);

      //string strDate = "January 1, 2021";
      //DateTime startDate = DateTime.Parse(strDate);

      // For test
      //string strDate = "May 10, 2021";
      //DateTime today = DateTime.Parse(strDate);
      //var jsonData = Json(new { data = await _invService.GetAllInventoryItem(today) });
      //DateTime todayDate = DateTime.Parse(today);
      //DateTime startHisDate = DateTime.Parse(startDate);
      //DateTime endHisDate = DateTime.Parse(endDate);

      // Old
      //var jsonData = Json(await _invService.GetInvFeeds(today, today));

      //var jsonData = Json(await _invService.GetInvAdvFeeds(startHisDate, endHisDate, todayDate));
      //var jsonData = Json(await _invService.GetInvFeeds(startHisDate, endHisDate, todayDate));
      //return jsonData;
      //return Json(new { data = await _invService.GetAllInventoryItem(today) });
      //DateTime testDate = DateTime.Now.AddDays(-2);

      DateTime todayDate = DateTime.Parse(today);
      DateTime startHisDate = DateTime.Parse(startDate);
      DateTime endHisDate = DateTime.Parse(endDate);
      DateTime tmpStartHisDate = DateTime.Parse(startDate);
      DateTime tmpEndHisDate = DateTime.Parse(endDate);
      while (tmpStartHisDate.DayOfWeek != 0)
      {
        tmpStartHisDate = tmpStartHisDate.AddDays(-1.0);
      }
      while (tmpEndHisDate.DayOfWeek != DayOfWeek.Saturday)
      {
        tmpEndHisDate = tmpEndHisDate.AddDays(1.0);
      }

      return Json(await _invService.GetNewInvFeeds(startHisDate, endHisDate, todayDate));
      //return Json(await _invService.GetNewInvFeeds(startHisDate, endHisDate, testDate));
    }

    // For Inventory Feeds Detail Edit
    [Authorize]
    [HttpGet("/Inventory/inv_feeds_edit/{today}/{id}")]
    public async Task<IActionResult> InvFeedsDetails(string today, string id)
    {
      //DateTime todayDate = DateTime.Parse(today, "MM-dd-yyyy");
      DateTime todayDate = new DateTime(int.Parse(today.Substring(4, 4)), int.Parse(today.Substring(0, 2)), int.Parse(today.Substring(2, 2)));
      int itemNoId = int.Parse(id);

      //var jsonData = Json(await _invService.GetInvFeedsDetail(todayDate, itemNoId));
      GetInventoryFeedsItemDTO result = await _invService.GetInvFeedsDetail(todayDate, itemNoId);

      return View(result);
      //      return jsonData;
      //return Json(new { data = await _invService.GetAllInventoryItem(today) });
    }

    // Saving nventory Feeds Detail
    // By Brian Yi on 09/11/2021
    [Authorize]
    [HttpPost("/Inventory/inv_feeds_qty_edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateInvFeedsSKUFeedingStatus([FromForm] GetInventoryFeedsItemDTO tmpDTO)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      bool result = await _invService.UpdateInvFeedItemDetail(empId, tmpDTO);

      //DateTime todayDate = new DateTime(int.Parse(today.Substring(4,4)), int.Parse(today.Substring(0,2)), int.Parse(today.Substring(2,2))) ;
      //int itemNoId = int.Parse(id);
      //string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["),1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"),1);
      //return Ok();
      
      return await Task.FromResult(RedirectToAction("InvFeedsIdx", "Inventory"));
    }


    [Authorize]
    [HttpGet("GetInvFeedsWayfair")]
    public async Task<IActionResult> GetInvFeedsWayfair(string historyDate)
    {
      DateTime hisDate = DateTime.Parse(historyDate);

      //string strDate = "January 1, 2021";
      //DateTime startDate = DateTime.Parse(strDate);

      var jsonData = Json(await _invService.GetInvFeedsWayfairRev(hisDate));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetInvFeedsOstBanc")]
    public async Task<IActionResult> GetInvFeedsOstBanc(string historyDate)
    {
      int banc = 4;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(banc, hisDate));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetInvFeedsOstBasc")]
    public async Task<IActionResult> GetInvFeedsOstBasc(string historyDate)
    {
      int basc = 62;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(basc, hisDate));

      return jsonData;
    }
    // For Overstock 
    [Authorize]
    [HttpGet("GetInvFeedsOstMainsl")]
    public async Task<IActionResult> GetInvFeedsOstMainsl(string historyDate)
    {
      int mainsl = 25;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(mainsl, hisDate));

      return jsonData;
    }
      
    // For Overstock 
    [Authorize]
    [HttpGet("GetInvFeedsOstSWCAFT")]
    public async Task<IActionResult> GetInvFeedsOstSWCAFT(string historyDate)
    {
      int swcaftId = 54;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(swcaftId, hisDate));

      return jsonData;
    }

    // For Overstock 
    [Authorize]
    [HttpGet("GetInvFeedsOstPrismCast")]
    public async Task<IActionResult> GetInvFeedsOstPrismCast(string historyDate)
    {
      int prismCastId = 51;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(prismCastId, hisDate));

      return jsonData;
    }


    // For Overstock (ZINUS-Tracy) 
    // Was added on 3/12/2024 by Brian Yi
    [Authorize]
    [HttpGet("GetInvFeedsOstZinusTracy")]
    public async Task<IActionResult> GetInvFeedsOstZinusTracy(string historyDate)
    {
      int zinusTracyId = 57;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(zinusTracyId, hisDate));

      return jsonData;
    }


    // For Overstock (ZINUS-CHS)
    // Was added on 3/12/2024 by Brian Yi
    [Authorize]
    [HttpGet("GetInvFeedsOstZinusChs")]
    public async Task<IActionResult> GetInvFeedsOstZinusChs(string historyDate)
    {
      int zinusChsId = 108;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsOverstockRev(zinusChsId, hisDate));

      return jsonData;
    }



    [Authorize]
    [HttpGet("GetInvFeedsWlmrtBanc")]
    public async Task<IActionResult> GetInvFeedsWlmrtBanc(string historyDate)
    {
      int banc = 4;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(banc, hisDate));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetInvFeedsWlmrtBasc")]
    public async Task<IActionResult> GetInvFeedsWlmrtBasc(string historyDate)
    {
      int basc = 62;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(basc, hisDate));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetInvFeedsWlmrtMainsl")]
    public async Task<IActionResult> GetInvFeedsWlmrtMainsl(string historyDate)
    {
      int mainsl = 25;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(mainsl, hisDate));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetInvFeedsWlmrtSWCAFT")]
    public async Task<IActionResult> GetInvFeedsWlmrtSWCAFT(string historyDate)
    {
      int swcaftId = 54;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(swcaftId, hisDate));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetInvFeedsWlmrtPrismCast")]
    public async Task<IActionResult> GetInvFeedsWlmrtPrismCast(string historyDate)
    {
      int swcaftId = 51;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(swcaftId, hisDate));

      return jsonData;
    }

    // For ZINUS Tracy
    // Was added by Brian Yi on 03/12/2024
    [Authorize]
    [HttpGet("GetInvFeedsWlmrtZinusTracy")]
    public async Task<IActionResult> GetInvFeedsWlmrtZinusTracy(string historyDate)
    {
      int zinusTracyId = 57;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(zinusTracyId, hisDate));

      return jsonData;
    }

    // For ZINUS CHS
    // Was added by Brian Yi on 03/12/2024
    [Authorize]
    [HttpGet("GetInvFeedsWlmrtZinusChs")]
    public async Task<IActionResult> GetInvFeedsWlmrtZinusChs(string historyDate)
    {
      int zinusChsId = 108;
      DateTime hisDate = DateTime.Parse(historyDate);
      // TESTING ONLY
      //hisDate = hisDate.AddDays(-1);

      var jsonData = Json(await _invService.GetInvFeedsWalmartRev(zinusChsId, hisDate));

      return jsonData;
    }


    //For a list of SKU Feedsing Status;InvFeedsSKUMarketStatusIdx
    // By Brian Yi on 07/22/2021
    [Authorize]
    [HttpGet("InvFeedsSKUMarketStatusIdx")]
    public ViewResult InvFeedsSKUMarketStatusIdx()
    {
      return View();
    }

    // Get a list of SKU Feedsing Status;
    // By Brian Yi on 07/22/2021
    [Authorize]
    [HttpGet("GetInvFeedsSKUFeedingStatusList")]
    public async Task<IActionResult> GetInvFeedsSKUFeedingStatusList(string customerId)
    {
      int custId = int.Parse(customerId);
      JsonResult jsonData = null;
      bool returnConflictedList = false;

      switch (custId)
      {
        case 0:
          jsonData = Json(await _invService.GetSKUFeedingStatusList());
          break;
        case 5: // Amazon
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 55: // Amazon Conflicted SKU List
          returnConflictedList = true;
          custId = 5;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 9: // BPM
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 99: // BPM Conflicted SKU List
          returnConflictedList = true;
          custId = 9;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 12: // eBay
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 1212: // eBay Conflicted SKU List
          returnConflictedList = true;
          custId = 12;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 14: // Houzz
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 1414: // Houzz Conflicted SKU List
          returnConflictedList = true;
          custId = 14;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 18: // Mellow
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 1818: // Mellow Conflicted SKU List
          returnConflictedList = true;
          custId = 18;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 21: // Overstock
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 2121: // Overstock Conflicted SKU List
          returnConflictedList = true;
          custId = 21;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 26: // Walmart
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 2626: // Walmart Conflicted SKU List
          returnConflictedList = true;
          custId = 26;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 29: // Wayfair
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 2929: // Wayfair Conflicted SKU List
          returnConflictedList = true;
          custId = 29;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 40: // Home Depot
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 4040: // Home Depot Conflicted SKU List
          returnConflictedList = true;
          custId = 40;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 51: // Target
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 5151: // Target Conflicted SKU List
          returnConflictedList = true;
          custId = 51;
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
        case 10000: // Sets
          jsonData = Json(await _invService.GetInvFeedsSKUFeedingStatusList(custId, returnConflictedList));
          break;
      }
      //var jsonData = Json(await _invService.GetAmazonSKUFeedingStatusList(custId));
      //var jsonData = Json(await _invService.GetSKUFeedingStatusList());
      jsonData.StatusCode = 200;
      return jsonData;
    }

    // Get a SKU Feedsing Status;
    // By Brian Yi on 07/29/2021
    [Authorize]
    [HttpGet("GetInvFeedsSKUFeedingStatus")]
    public async Task<IActionResult> GetInvFeedsSKUFeedingStatus(string itemNoId)
    {
      //string json = System.Text.Json.JsonSerializer.Serialize(body);
      int itemId = int.Parse(itemNoId);
      //int itemId = 1725;
      JsonResult jsonData = Json(await _invService.GetSKUFeedingStatus(itemId));

      return jsonData;
      //return View(await _invService.GetSKUFeedingStatus(itemId));
      //return await Task.FromResult(RedirectToAction("InvFeedsSKUMarketStatusIdx", "Inventory"));
    }

    // Get a list of SKU Feedsing Status;
    // By Brian Yi on 07/22/2021
    [Authorize]
    [HttpPost("/inventory/UpdateInvFeedsSKUFeedingStatus/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateInvFeedsSKUFeedingStatus([FromForm] InvFeedsSKUStatusDTO tmpDTO)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      //string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["),1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"),1);
      //return Ok();

      return await Task.FromResult(RedirectToAction("InvFeedsSKUMarketStatusIdx", "Inventory"));
    }

    // Update a list of SKU Feeds Status;
    // By Brian Yi on 07/22/2021
    [Authorize]
    [HttpPost("UpdateInvFeedsSKUFeedingStatusList")]
    public async Task<IActionResult> UpdateInvFeedsSKUFeedingStatusList(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      string tmp = json.Remove(json.IndexOf("["), 1);
      tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      InvFeedsStatusUpdatingListDTO updatedList = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsStatusUpdatingListDTO>(tmp);

      bool result = await _invService.UpdateCustomerSKUFeedingStatusList(empId, updatedList);

      if (result == true) return Ok(StatusCode(200));

      return await Task.FromResult(RedirectToAction("InvFeedAmzFeedStatusIdx", "Inventory"));
    }


    // Update a list of HomeDepot SKU Feeds Status
    // By Brian Yi on 



    //For a list of Amazon SKU Feedsing Status;
    // By Brian Yi on 07/22/2021
    [Authorize]
    [HttpGet("InvFeedsAmzFeedsStatusIdx")]
    public ViewResult InvFeedsAmzFeedsStatusIdx()
    {
      return View();
    }

    //For a list of Overstock SKU Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedsOstFeedsStatusIdx")]
    public ViewResult InvFeedsOstFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }

    //For a list of Walmart SKU Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedsWlmrtFeedsStatusIdx")]
    public ViewResult InvFeedsWlmrtFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }

    //For a list of Wayfair SKU Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedsWyfrFeedsStatusIdx")]
    public ViewResult InvFeedsWyfrFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      //return View("InvRedirect");
      return View();
    }

    //For a list of eBay SKUs Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedseBayFeedsStatusIdx")]
    public ViewResult InvFeedseBayFeedsStatusIdx()
    {
      // int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }

    //For a list of BPM SKUs Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedsBPMFeedsStatusIdx")]
    public ViewResult InvFeedsBPMFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      // if(empId != 210) 
      //  return View("InvRedirect");
      return View();
    }

    //For a list of Mellow SKUs Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedsMellowFeedsStatusIdx")]
    public ViewResult InvFeedsMellowFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }

    //For a list of Houzz SKUs Feedsing Status;
    // By Brian Yi on 08/10/2021
    [Authorize]
    [HttpGet("InvFeedsHouzzFeedsStatusIdx")]
    public ViewResult InvFeedsHouzzFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }

    //For a list of Home Depot SKUs Feedsing Status;
    // By Brian Yi on 06/10/2022
    [Authorize]
    [HttpGet("InvFeedsHomeDepotFeedsStatusIdx")]
    public ViewResult InvFeedsHomeDepotFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }

    //For a list of Home Depot SKUs Feedsing Status;
    // By Brian Yi on 06/10/2022
    [Authorize]
    [HttpGet("InvFeedsTargetFeedsStatusIdx")]
    public ViewResult InvFeedsTargetFeedsStatusIdx()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      //if(empId != 210) 
      // return View("InvRedirect");
      return View();
    }


    //Layout of Grouping SKUs for Remark 
    // By Brian Yi on 07/30/2021
    [Authorize]
    [HttpGet("InvFeedsRemarkGrouping")]
    public ViewResult InvFeedsRemarkGrouping()
    {
      return View();
    }


    //For Inventory Feeds Setting
    // By Brian Yi on 06/30/2021
    [Authorize]
    [HttpGet("InvFeedsRemarkGroupList")]
    public async Task<ViewResult> InvFeedsRemarkGroupList(string categoryId)
    {
      int remarkCategoryId = int.Parse(categoryId);

      //InvFeedsGeneralSettingDTO invFeedsGeneralSettingDTO = await _invService.GetRemarkGroupItems(remarkCategoryId);
      return View();
    }

    // Update a list of remark group;
    // By Brian Yi on 0/03/2021
    //[Authorize]
    [HttpPost("UpdateInvFeedsRemarkGroupList")]
    public async Task<IActionResult> UpdateInvFeedsRemarkGroupList(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      //int empId = 210;
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      string tmp = json.Remove(json.IndexOf("["), 1);
      tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      InvFeedsRemarkSKUGroupListDTO updatedList = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsRemarkSKUGroupListDTO>(tmp);


      bool result = await _invService.UpdateInvFeedsRemarkGroupList(empId, updatedList);

      if (result == true) return Ok(StatusCode(200));

      return await Task.FromResult(RedirectToAction("InvFeedsRemarkGrouping", "Inventory"));
    }

    // Update a list of left over at warehouses;
    // By Brian Yi on 02/24/2023
    //[Authorize]
    [HttpPost("UpdateInvFeedsLeftOverList")]
    public async Task<IActionResult> UpdateInvFeedsLeftOverList(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      //int empId = 210;
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      string tmp = json.Remove(json.IndexOf("["), 1);
      tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      LeftOverWarehouseQtyListDTO updatedList = Newtonsoft.Json.JsonConvert.DeserializeObject<LeftOverWarehouseQtyListDTO>(tmp);


      bool result = await _invService.UpdateInvFeedsLeftOverAtWarehousesList(empId, updatedList);

      if (result == true) return Ok(StatusCode(200));

      return await Task.FromResult(RedirectToAction("InvFeedsRemarkGrouping", "Inventory"));
    }



    // Inventory Feeds SKU Edit
    //[HttpGet("/inventory/mainsl_banc_feeds_remark/{id}")]
    //public async Task<IActionResult> InvFeedsSKUEdit (int? id)
    //{

    //  return await Task.FromResult(RedirectToAction("InvFeedsIdx", "Inventory"));
    // }


    ///Inventory/ImportInvFeeds
    ///
    // Import User's Inventory Feeds
    // By Brian Yi on 04/22/2022
    [Authorize]
    [HttpPost("ImportInvFeeds")]
    public async Task<IActionResult> ImportInvFeeds(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<UserRevisedInvFeedsDTO> invFeedsByUserList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserRevisedInvFeedsDTO>>(json);

      JsonResult jsonData = Json(await _invService.ReviseInventoryFeedsByUser(empId, invFeedsByUserList));

      return jsonData;
    }


    ///Inventory/ImportWarehouseQty
    ///
    // Import User's Warehouse Qty
    // By Brian Yi on 05/27/2022
    [Authorize]
    [HttpPost("ImportWarehouseQty")]
    public async Task<IActionResult> ImportWarehouseQty(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<UserRevisedWarehouseQtyDTO> warehouseQtyByUserList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserRevisedWarehouseQtyDTO>>(json);

      JsonResult jsonData = Json(await _invService.ReviseWarehouseQtyByUser(empId, warehouseQtyByUserList));

      return jsonData;
    }



    // POST: InventoryItemDTOes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("InventoryItemId,ItemNoId,ItemName,QtyOnHand,QtyAvail,LocId,LocName")] GetInventoryItemDTO getInventoryItemDTO)
    {
      if (ModelState.IsValid)
      {
        _kc.Add(getInventoryItemDTO);
        await _kc.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(getInventoryItemDTO);
    }

    // Use THIS ONE!!!
    [HttpPost("/inventory/Edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] GetInventoryItemDTO tmpDto)
    {

      if (tmpDto.InventoryItemId == null)
      {
        return NotFound();
      }
      return await Task.FromResult(RedirectToAction("Index", "Inventory"));
    }

    // For Mainsl & BANC inventory Edit
    // By Brian Yi on 05/21/2021
    [Authorize]
    [HttpGet("/inventory/mainsl_banc_edit/{id}")]
    public async Task<IActionResult> InvMainslBancEdit(int? id)
    {
      long tmpId = (long)id;
      GetMainslBancInvItemDetailDTO getMainslBancInvItemDetailDTO = await _invService.GetMainslBANCInventoryItem(tmpId);
      if (getMainslBancInvItemDetailDTO.GetMainslBancInvItemDTO.InventoryItemId == null)
      {
        return NotFound();
      }
      return View(getMainslBancInvItemDetailDTO);
    }

    // Need to work
    // 06/11/2021
    [Authorize]
    [HttpPost("/inventory/mainsl_banc_edit/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InvMainslBancEdit([FromForm] GetMainslBancInvItemDetailDTO tmpDto)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      bool result = await _invService.UpdateInvFeedsItem(empId, tmpDto);
      if (tmpDto.GetMainslBancInvItemDTO.InventoryItemId == null)
      {
        return NotFound();
      }
      return await Task.FromResult(RedirectToAction("InvMainslBancIdx", "Inventory"));
    }

    // For Mainsl & BANC inventory Note Edit
    // By Brian Yi on 05/29/2021
    [Authorize]
    [HttpGet("/inventory/mainsl_banc_feeds_note/{id}")]
    public async Task<IActionResult> InvNoteUpsert(int? id)
    {
      GetAvailableInventoryNotesDTO getAvailableInventoryNotesDTO = await _invService.GetAvailableInventoryNotesRules((int)id);

      if (getAvailableInventoryNotesDTO.NotesRulesId == null)
      {
        return NotFound();
      }
      return View(getAvailableInventoryNotesDTO);
    }

    // For Mainsl & BANC Inventory Feeds Note Create Blank Page;
    // Adding a new note
    [Authorize]
    [HttpGet("/inventory/mainsl_banc_feeds_note/")]
    public async Task<IActionResult> InvNoteUpsert()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      GetAvailableInventoryNotesDTO getAvailableInventoryNotesDTO = new GetAvailableInventoryNotesDTO()
      {
        isActivated = true,
        CreatedBy = empId.ToString()
      };

      return View(getAvailableInventoryNotesDTO);
    }


    [Authorize]
    [HttpPost("/inventory/mainsl_banc_feeds_note/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InvNoteUpsert([FromForm] GetAvailableInventoryNotesDTO tmpDto)
    {
      NotesAndRule tmpModel = await _kc.NotesAndRules
        .Where(nar => nar.NotesAndRulesId == tmpDto.NotesRulesId)
        .FirstOrDefaultAsync();
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      if (tmpModel == null)
      {
        tmpModel = new NotesAndRule()
        {
          CreatedTime = DateTime.Now,
          CreatedBy = empId,
          NoteRule = tmpDto.NoteRule,
          IsActivated = tmpDto.isActivated,
          NoteCategory = 1
        };
        await _kc.AddAsync(tmpModel);
      }
      else
      {
        tmpModel.IsActivated = tmpDto.isActivated;
        tmpModel.NoteRule = tmpDto.NoteRule;
        tmpModel.LastModifiedTime = DateTime.Now;
        tmpModel.LastModifiedBy = empId;

        _kc.Update(tmpModel);
      }
      await _kc.SaveChangesAsync();
      return await Task.FromResult(RedirectToAction("InvMainslBancIdx", "Inventory"));
    }


    // For Mainsl & BANC inventory rules Edit
    // By Brian Yi on 05/29/2021
    [Authorize]
    [HttpGet("/inventory/mainsl_banc_feeds_rules/{id}")]
    public async Task<IActionResult> InvFeedsRules(int? id)
    {
      GetInventoryFeedMarketRule getInventoryFeedMarketRule = await _invService.GetInventoryFeedingRule((int)id);

      if (getInventoryFeedMarketRule.InvFeedRuleId == null)
      {
        return NotFound();
      }

      return View(getInventoryFeedMarketRule);
    }


    [Authorize]
    [HttpPost("/inventory/mainsl_banc_feeds_rules/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InvFeedsRules([FromForm] GetInventoryFeedMarketRule tmpDto)
    {
      InvFeedsRule tmpModel = await _kc.InvFeedsRules
        .Where(i => i.InvFeedRuleId == tmpDto.InvFeedRuleId)
        .FirstOrDefaultAsync();

      int empId = GetUserId(User.Identity as ClaimsIdentity);
      string tmpStr = "";

      if (tmpModel.CustomerId == null)
      {
        return NotFound();
      }
      else
      {
        tmpModel.LastModifiedTime = DateTime.Now;
        tmpModel.IsActivated = tmpDto.IsActivated;
        tmpModel.ZeroOutAt = tmpDto.ZeroOutAt;
        tmpModel.LastModifiedBy = empId;
        tmpStr = Regex.Match(tmpDto.CustomFeedRatioText, @"\d+").Value;
        if (tmpStr != "") tmpModel.CustomFeedRatio = Int32.Parse(tmpStr);

        _kc.Update(tmpModel);
        await _kc.SaveChangesAsync();
      }
      return await Task.FromResult(RedirectToAction("InvFeedsSetting", "Inventory"));
    }


    // For Remark Category
    // For Mainsl & BANC inventory Remark Category Edit
    // By Brian Yi on 06/17/2021
    [Authorize]
    [HttpGet("/inventory/mainsl_banc_feeds_remark/{id}")]
    public async Task<IActionResult> InvRemarkCategoryUpsrt(long? id)
    {
      InvFeedsRmrkCtgry invFeedsRemarkCategory = await _kc.InvFeedsRmrkCtgries
        .Where(i => i.InvFeedsRmrkCtgryId == (long)id)
        .Include(i => i.LastModifiedByNavigation)
        .FirstOrDefaultAsync();
      if (invFeedsRemarkCategory == null)
      {
        return NotFound();
      }
      InvFeedsRemarkCategory result = new InvFeedsRemarkCategory()
      {
        categoryId = invFeedsRemarkCategory.InvFeedsRmrkCtgryId,
        categoryName = invFeedsRemarkCategory.CategoryName,
        isActivatedOnThisSKU = (bool)invFeedsRemarkCategory.IsActivated,
        MainslDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromMainsl == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromMainsl),
        SwcaftDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromSwcaft == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromSwcaft),
        BancDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromBanc == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromBanc),
        BascDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromBasc == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromBasc),
        PrismCastDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromPrismCast == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromPrismCast),
        PrismCaltDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromPrismCalt == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromPrismCalt),
        ZinusTracyDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromZinusTracy == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromZinusTracy),
        ZinusChsDoNotFeed = (invFeedsRemarkCategory.DoNotFeedFromZinusChs == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedFromZinusChs),
        AmazonDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToAmazon == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToAmazon),
        eBayDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToeBay == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToeBay),
        OverstockDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToOverstock == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToOverstock),
        WalmartDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToWalmart == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToWalmart),
        WayfairDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToWayfair == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToWayfair),
        BPMDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToBpm == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToBpm),
        MellowDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToMellow == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToMellow),
        HouzzDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToHouzz == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToHouzz),
        TargetDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToTarget == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToTarget),
        HomeDepotDoNotFeed = (invFeedsRemarkCategory.DoNotFeedToHomeDepot == null ? false : (bool)invFeedsRemarkCategory.DoNotFeedToHomeDepot),
        LastModifiedBy = (invFeedsRemarkCategory.LastModifiedByNavigation != null ? invFeedsRemarkCategory.LastModifiedByNavigation.EmployeeName : ""),
        LastModifiedDate = (invFeedsRemarkCategory.LastModifiedDate != null ?
          ((DateTime)invFeedsRemarkCategory.LastModifiedDate).ToString("MM/dd/yyyy h:mm tt") : null)
      };
      return View(result);
    }

    // For Mainsl & BANC Inventory Feeds Note Create Blank Page;
    // Adding a new note
    [Authorize]
    [HttpGet("/inventory/mainsl_banc_feeds_remark/")]
    public async Task<IActionResult> InvRemarkCategoryUpsrt()
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      InvFeedsRemarkCategory result = new InvFeedsRemarkCategory()
      {

        isActivatedOnThisSKU = true
      };

      return View(result);
    }


    [Authorize]
    [HttpPost("/inventory/mainsl_banc_feeds_remark/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InvRemarkCategoryUpsrt([FromForm] InvFeedsRemarkCategory tmpDto)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      InvFeedsRmrkCtgry fromDBDModel = await _kc.InvFeedsRmrkCtgries
        .Where(i => i.InvFeedsRmrkCtgryId == tmpDto.categoryId)
        .FirstOrDefaultAsync();

      if (fromDBDModel == null)
      {
        fromDBDModel = new InvFeedsRmrkCtgry()
        {
          IsActivated = tmpDto.isActivatedOnThisSKU,
          CategoryName = tmpDto.categoryName,
          DoNotFeedFromMainsl = tmpDto.MainslDoNotFeed,
          DoNotFeedFromSwcaft = tmpDto.SwcaftDoNotFeed,
          DoNotFeedFromBanc = tmpDto.BancDoNotFeed,
          DoNotFeedFromBasc = tmpDto.BascDoNotFeed,
          DoNotFeedFromPrismCast = tmpDto.PrismCastDoNotFeed,
          DoNotFeedFromPrismCalt = tmpDto.PrismCaltDoNotFeed,
          DoNotFeedFromZinusTracy = tmpDto.ZinusTracyDoNotFeed,
          DoNotFeedFromZinusChs = tmpDto.ZinusChsDoNotFeed,
          DoNotFeedToAmazon = tmpDto.AmazonDoNotFeed,
          DoNotFeedToeBay = tmpDto.eBayDoNotFeed,
          DoNotFeedToOverstock = tmpDto.OverstockDoNotFeed,
          DoNotFeedToWalmart = tmpDto.WalmartDoNotFeed,
          DoNotFeedToWayfair = tmpDto.WayfairDoNotFeed,
          DoNotFeedToBpm = tmpDto.BPMDoNotFeed,
          DoNotFeedToMellow = tmpDto.MellowDoNotFeed,
          DoNotFeedToHouzz = tmpDto.HouzzDoNotFeed,
          DoNotFeedToTarget = tmpDto.TargetDoNotFeed,
          DoNotFeedToHomeDepot = tmpDto.HomeDepotDoNotFeed,
          LastModifiedBy = empId,
          LastModifiedDate = DateTime.Now

        };
        await _kc.AddAsync(fromDBDModel);
      }
      else
      {
        fromDBDModel.IsActivated = tmpDto.isActivatedOnThisSKU;
        fromDBDModel.CategoryName = tmpDto.categoryName;
        fromDBDModel.DoNotFeedFromMainsl = tmpDto.MainslDoNotFeed;
        fromDBDModel.DoNotFeedFromSwcaft = tmpDto.SwcaftDoNotFeed;
        fromDBDModel.DoNotFeedFromBanc = tmpDto.BancDoNotFeed;
        fromDBDModel.DoNotFeedFromBasc = tmpDto.BascDoNotFeed;
        fromDBDModel.DoNotFeedFromPrismCast = tmpDto.PrismCastDoNotFeed;
        fromDBDModel.DoNotFeedFromPrismCalt = tmpDto.PrismCaltDoNotFeed;
        fromDBDModel.DoNotFeedFromZinusTracy = tmpDto.ZinusTracyDoNotFeed;
        fromDBDModel.DoNotFeedFromZinusChs = tmpDto.ZinusChsDoNotFeed;
        fromDBDModel.DoNotFeedToAmazon = tmpDto.AmazonDoNotFeed;
        fromDBDModel.DoNotFeedToeBay = tmpDto.eBayDoNotFeed;
        fromDBDModel.DoNotFeedToOverstock = tmpDto.OverstockDoNotFeed;
        fromDBDModel.DoNotFeedToWalmart = tmpDto.WalmartDoNotFeed;
        fromDBDModel.DoNotFeedToWayfair = tmpDto.WayfairDoNotFeed;
        fromDBDModel.DoNotFeedToBpm = tmpDto.BPMDoNotFeed;
        fromDBDModel.DoNotFeedToMellow = tmpDto.MellowDoNotFeed;
        fromDBDModel.DoNotFeedToHouzz = tmpDto.HouzzDoNotFeed;
        fromDBDModel.DoNotFeedToTarget = tmpDto.TargetDoNotFeed;
        fromDBDModel.DoNotFeedToHomeDepot = tmpDto.HomeDepotDoNotFeed;
        fromDBDModel.LastModifiedBy = empId;
        fromDBDModel.LastModifiedDate = DateTime.Now;

        _kc.Update(fromDBDModel);
      }
      await _kc.SaveChangesAsync();
      return await Task.FromResult(RedirectToAction("InvRemarkCategoryIdx", "Inventory"));
    }

    //Remark Category End here



    // This is for updating inventory in real time
    // By Brian Yi on 06/15/2021
    [Authorize]
    [HttpPost("updateInventory")]
    public async Task<IActionResult> updateInv()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      DateTime today = DateTime.Now;
      //Process proc = new Process();
      //string tmpStr = System.AppDomain.CurrentDomain.BaseDirectory;
      //proc.StartInfo.FileName = tmpStr + "updInv\\NSInvUpdate.exe";
      //proc.Start();
      //await proc.WaitForExitAsync();      //await _invService.GetUpdatedMainslBancInv(empId, today);
      //await _invService.GetUpdatedAllWarehousesInv(empId, today, 0);
      List<BpmItem> nullCOOs = await _kc.BpmItems.Where(b => b.IsCoOmasterSku.HasValue == false).ToListAsync();
      if(nullCOOs != null && nullCOOs.Count != 0)
      {
        nullCOOs.All(i => { i.IsCoOmasterSku = true; return true; });
        _kc.Update(nullCOOs);
      }
      return await Task.FromResult(RedirectToAction("InvMainslBancIdx", "Inventory"));
    }

    [HttpGet("scheduledUpdateInventory")]
    public async void scheduledUpdateInv()
    {
      int empId = 0;
      DateTime today = DateTime.Now;
      Process proc = new Process();
      string tmpStr = System.AppDomain.CurrentDomain.BaseDirectory;
      proc.StartInfo.FileName = tmpStr + "updInv\\NSInvUpdate.exe";
      proc.Start();
      await proc.WaitForExitAsync();
      //await _invService.GetUpdatedMainslBancInv(empId, today);
      await _invService.GetUpdatedAllWarehousesInv(empId, today, 0); 
    }


    // This is for updating inventory in real time
    // By Brian Yi on 06/15/2021
    [Authorize]
    [HttpGet("updateInventoryDefinedPeriod")]
    public async Task<IActionResult> updateInventoryDefinedPeriod(string sel)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      int selection = int.Parse(sel);
      DateTime today = DateTime.Now;
      Process proc = new Process();
      string tmpStr = System.AppDomain.CurrentDomain.BaseDirectory;
      proc.StartInfo.FileName = tmpStr + "updInv\\NSInvUpdate.exe";
      proc.Start();
      await proc.WaitForExitAsync();
      await _invService.GetUpdatedAllWarehousesInv(empId, today, selection);
      List<BpmItem> nullCOOs = await _kc.BpmItems.Where(b => b.IsCoOmasterSku.HasValue == false).ToListAsync();
      if (nullCOOs.Any())
      {
        nullCOOs.All(i => { i.IsCoOmasterSku = true; return true; });
        await _kc.SaveChangesAsync();
      }
			List<BpmItem> nullItemStatus = await _kc.BpmItems.Where(b => b.ItemStatusId.HasValue == false).ToListAsync();
			if (nullItemStatus.Any())// != null && nullItemStatus.Count != 0)
			{
				nullItemStatus.All(i => { i.ItemStatusId = 1; return true; });
				await _kc.SaveChangesAsync();
			}
			return Ok(StatusCode(200));
    }



    // This is for approving the inventory feeds
    // By Brian Yi on 06/17/2021
    [Authorize]
    [HttpPost("approveInventory")]
    public async Task<IActionResult> approveInvFeeds()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      // For test only
      DateTime date = DateTime.Now;

      DateTime beforeDate = new DateTime(date.AddDays(-1).Year, date.AddDays(-1).Month, date.AddDays(-1).Day, 23, 59, 59);
      DateTime afterDate = new DateTime(date.AddDays(1).Year, date.AddDays(1).Month, date.AddDays(1).Day, 0, 0, 0);

      InvFeedsReport invFeedReport = await _kc.InvFeedsReports
        .Where(ifr => (DateTime)ifr.CreatedDate > beforeDate && (DateTime)ifr.CreatedDate < afterDate)
        .Include(x => x.InvFeedsItems)
        .OrderByDescending(x => x.CreatedDate)
        .FirstOrDefaultAsync();

      if (invFeedReport == null) return null;
      try
      {
        invFeedReport.IsApproved = true;
        invFeedReport.ApprovedBy = empId;
        invFeedReport.FeedingDate = DateTime.Now;
        _kc.Update(invFeedReport);
        await _kc.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        JsonResult jsonReturn = Json(ex);
        return jsonReturn;
      }
      //return View();
      JsonResult jsonData = Json(true);
      return jsonData;
      //return await Task.FromResult(RedirectToAction("InvFeedsIdx", "Inventory"));
    }


    // This is for approving the inventory feeds
    // By Brian Yi on 06/17/2021
    [Authorize]
    [HttpPost("approveInventoryWithMessage")]
    public async Task<IActionResult> approveInventoryWithMessage(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      string messageFromUser = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(json);
      // For test only
      DateTime date = DateTime.Now;

      DateTime beforeDate = new DateTime(date.AddDays(-1).Year, date.AddDays(-1).Month, date.AddDays(-1).Day, 23, 59, 59);
      DateTime afterDate = new DateTime(date.AddDays(1).Year, date.AddDays(1).Month, date.AddDays(1).Day, 0, 0, 0);
      JsonResult jsonData;


      InvFeedsReport invFeedReport = await _kc.InvFeedsReports
        .Where(ifr => (DateTime)ifr.CreatedDate > beforeDate && (DateTime)ifr.CreatedDate < afterDate)
        .Where(ifr => ifr.IsApproved == false)
        .Include(x => x.InvFeedsItems)
        .OrderByDescending(x => x.CreatedDate)
        .FirstOrDefaultAsync();
      if (invFeedReport == null)
      {
        jsonData = Json(false);
        return jsonData;
      }
      
      List<InvFeedersEmail> invFeedersEmails = await _kc.Employees
        .Where(i => i.IsInventoryFeeder == true)
        .Select(n => new InvFeedersEmail
        {
          LoginID = n.LoginId
        }).ToListAsync();

      InvFeedersEmail orderProcess = new InvFeedersEmail()
      {
        LoginID = "orderprocess@mellow-home.com"
      };
      invFeedersEmails.Add(orderProcess);

      // For testing
      /*
      List<InvFeedersEmail> invFeedersEmails = new List<InvFeedersEmail>();

      InvFeedersEmail orderProcess = new InvFeedersEmail()
      {
        LoginID = "brian.yi@mellow-home.com"
      };
      invFeedersEmails.Add(orderProcess);
      */
      string recipients = "";

      foreach(InvFeedersEmail tmpDto in invFeedersEmails)
      {
        if(recipients == "")
        { recipients = tmpDto.LoginID; }
        else 
        { recipients = recipients + "," + tmpDto.LoginID; }
        
      }

      //For test
      //recipients = "bpm.automated.process@gmail.com, brian.yi@mellow-home.com";
      if (invFeedReport == null) return null;
      try
      {
        invFeedReport.IsApproved = true;
        invFeedReport.ApprovedBy = empId;
        invFeedReport.FeedingDate = DateTime.Now;
        _kc.Update(invFeedReport);
        await _kc.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        JsonResult jsonReturn = Json(ex);
        return jsonReturn;
      }
      //#if !DEBUG
      using (SmtpClient client = new SmtpClient()
      {
        Host = "smtp.office365.com",
        Port = 587,
        UseDefaultCredentials = false, // This require to be before setting Credentials property
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential("bpmadmin@bpmatt.com", "Bpm@94577!"), // you must give a full email address for authentication 
        TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
        EnableSsl = true // Set to avoid secure connection exception
      })

      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress("bpmadmin@bpmatt.com"), // sender must be a full email address
          Subject = "Today("+date.ToString("MM/dd/yyyy")+")'s inventory feeds were approved!",
          IsBodyHtml = true,
          Body = "Today(" + date.ToString("MM/dd/yyyy") + ")'s inventory feeds are ready!\n" + emp.LoginId+" would like to say\n"+"<h2>\""+ messageFromUser + "\"</h2>",
          BodyEncoding = System.Text.Encoding.UTF8,
          SubjectEncoding = System.Text.Encoding.UTF8,
           
        };
        var toAddresses = recipients.Split(',');
        foreach (var to in toAddresses)
        {
          message.To.Add(to.Trim());
        }

        try
        {
          client.Send(message);
        }
        catch (Exception ex)
        {
          Debug.WriteLine(ex.Message);
        }
      }

//#endif

      //return View();
      jsonData = Json(true);
      return jsonData;
      //return await Task.FromResult(RedirectToAction("InvFeedsIdx", "Inventory"));
    }





    // This is for getting last update info. from various table
    // By Brian Yi on 09/13/2021
    [Authorize]
    [HttpGet("getLastUpdateInfo")]
    public async Task<IActionResult> getLastUpdateInfo(string sel, string today)
    {
      // 1: BANC & MainSL Page - 
      // 2: Inventory Feeding Page
      int selection = int.Parse(sel);
      string serviceResponse = "";
      MainFeedsStatus mainFeeds = new MainFeedsStatus();


      DateTime date = DateTime.Parse(today);
      DateTime beforeDate = new DateTime(date.AddDays(-1).Year, date.AddDays(-1).Month, date.AddDays(-1).Day, 23, 59, 59);
      DateTime afterDate = new DateTime(date.AddDays(1).Year, date.AddDays(1).Month, date.AddDays(1).Day, 0, 0, 0);
      InvFeedsReport invFeedReport;

      switch (selection)
      {
        case 1:
          invFeedReport = await _kc.InvFeedsReports
          .Where(ifr => (DateTime)ifr.CreatedDate > beforeDate && (DateTime)ifr.CreatedDate < afterDate)
          .Include(ifr => ifr.CreatedByNavigation)
          .OrderByDescending(x => x.CreatedDate)
          .FirstOrDefaultAsync();
          if (invFeedReport == null)
          {
            mainFeeds.feedsStatus = -1;
            mainFeeds.customMessage = "No update in today.";
          } 
          else
          {
            mainFeeds.feedsStatus = -1;
            mainFeeds.customMessage = "Last Update By: " + invFeedReport.CreatedByNavigation.LoginId.ToString()
              + "\n&nbsp;&nbsp;on " + ((DateTime)invFeedReport.CreatedDate).ToString("MM/dd/yyyy h:mm tt");
            //serviceResponse = "Last Update By: " + invFeedReport.CreatedByNavigation.LoginId.ToString()
            //+ "\n&nbsp;&nbsp;on " + ((DateTime)invFeedReport.CreatedDate).ToString("MM/dd/yyyy h:mm tt");
          }
          break;

        case 2:
          invFeedReport = await _kc.InvFeedsReports
          .Where(ifr => (DateTime)ifr.CreatedDate > beforeDate && (DateTime)ifr.CreatedDate < afterDate)
          .Include(ifr => ifr.CreatedByNavigation)
          .Include(ifr => ifr.ApprovedByNavigation)
          .OrderByDescending(x => x.CreatedDate)
          .FirstOrDefaultAsync();
          if (invFeedReport == null) 
          {
            mainFeeds.feedsStatus = -1;
            mainFeeds.customMessage = "No feeding was made.";
            //serviceResponse = "No feeding was made.";
          } 
          else
          {
            mainFeeds.feedsStatus = (invFeedReport.IsApproved == true ? 1: 0);
            mainFeeds.customMessage = (invFeedReport.IsApproved == true ? ("&nbsp;&nbsp;&nbsp;This feeding has been approved by " + invFeedReport.ApprovedByNavigation.LoginId + ".\n") : "&nbsp;&nbsp;&nbsp;This feeding has not been approved.");
            mainFeeds.customMessage = mainFeeds.customMessage + "\nCreated Time: " + ((DateTime)invFeedReport.CreatedDate).ToString("MM/dd/yyyy h:mm tt")
              + "\n by " + invFeedReport.CreatedByNavigation.LoginId.ToString();
            //serviceResponse = (invFeedReport.IsApproved == true ? ("&nbsp;&nbsp;&nbsp;This feeding has been approved by " + invFeedReport.ApprovedByNavigation.LoginId + ".\n") : "&nbsp;&nbsp;&nbsp;This feeding has not been approved.");
            //serviceResponse = serviceResponse + "\nCreated Time: " + ((DateTime)invFeedReport.CreatedDate).ToString("MM/dd/yyyy h:mm tt")
            //  + "\n by " + invFeedReport.CreatedByNavigation.LoginId.ToString();
          }

          break;
      }

      //var jsonData = Json(serviceResponse);
      var jsonData = Json(mainFeeds);
      return jsonData;
    }



    // GET: InventoryItemDTOes/Edit/5
    //[HttpGet("{id}")]
    // Goint to Edit screen
    // This 'id' is ItemNoId, not InventoryItemId
    [Authorize]
    [HttpGet("/inventory/Edit/{id}")]
    public async Task<IActionResult> Edit(int? id)
    {
      //return View();
      if (id == null)
      {
        return NotFound();
      }

      // var getInventoryItemDTO = await _kc.GetInventoryItemDTO.FindAsync(id);

      GetInventoryItemDTO getInventoryItemDTO = await _invService.GetInventoryItem(id);

      if (getInventoryItemDTO == null)
      {
        return NotFound();
      }
      return View(getInventoryItemDTO);
    }

    private DateTime getLatestDateForInventory(DateTime today)
    {
      int checkHour = 16; // 4:00pm
      if (today.Hour.CompareTo(checkHour) < 0) today.AddDays(-1);

      return today;
    }


    // By Brian Yi on 06/06/2021
    // Get Employee ID from cookie
    public int GetUserId(ClaimsIdentity claimsIdentity)
    {
      string result = "";
      foreach (var claim in claimsIdentity.Claims)
      {
        if (claim.Type == ClaimTypes.SerialNumber)
        { result = claim.Value; break; }
      }
      return Int32.Parse(result);
    }


    // For inventory feeds Detail & Edit
    // By Brian Yi on 07/06/2021
    // You need to finish THIS!!!!!!!
    [Authorize]
    [HttpGet("/inventory/inv_feeds_edit/{id}")]
    public async Task<IActionResult> InvFeedsSKUEdit(int? id)
    {
      GetAvailableInventoryNotesDTO getAvailableInventoryNotesDTO = await _invService.GetAvailableInventoryNotesRules((int)id);

      if (getAvailableInventoryNotesDTO.NotesRulesId == null)
      {
        return NotFound();
      }
      return View(getAvailableInventoryNotesDTO);
    }


    // Save the 
    [Authorize]
    [HttpPost("/inventory/inv_feeds_edit/")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> InvFeedsSKUEdit([FromForm] GetAvailableInventoryNotesDTO tmpDto)
    {
      NotesAndRule tmpModel = await _kc.NotesAndRules
        .Where(nar => nar.NotesAndRulesId == tmpDto.NotesRulesId)
        .FirstOrDefaultAsync();
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      if (tmpModel == null)
      {
        tmpModel = new NotesAndRule()
        {
          CreatedTime = DateTime.Now,
          CreatedBy = empId,
          NoteRule = tmpDto.NoteRule,
          IsActivated = tmpDto.isActivated,
          NoteCategory = 1
        };
        await _kc.AddAsync(tmpModel);
      }
      else
      {
        tmpModel.NoteRule = tmpDto.NoteRule;
        tmpModel.LastModifiedTime = DateTime.Now;
        tmpModel.LastModifiedBy = empId;

        _kc.Update(tmpModel);
      }
      await _kc.SaveChangesAsync();
      return await Task.FromResult(RedirectToAction("InvMainslBancIdx", "Inventory"));
    }


    // Updating Amazon Feeds List
    // By Brian Yi on 07/13/2021
    [HttpPost("UpdateMarketFeedsList")]
    public async Task<IActionResult> UpdateMarketSKUFeedsList(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      //int empId = 210;
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["),1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"),1);
      bool result = false;
      List<MarketFeedsListItemImportDTO> marketFeedsListItemImportDTOs = new List<MarketFeedsListItemImportDTO>();
      //AmazonFeedsListImportDTO amazonFeedsListImportDTO = System.Text.Json.JsonSerializer.Deserialize<AmazonFeedsListImportDTO>(tmp);
      InvFeedsListImportDTO tmpDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsListImportDTO>(json);

      switch (Int32.Parse(tmpDTO.customerId))
      {
        case 5: // Amazon Drop Ship
          AmazonFeedsListImportDTO amzFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<AmazonFeedsListImportDTO>(json);
          result = await _invService.UpdateAmazonFeedsList(empId, amzFeedsList);
          break;
        case 9: // BPM Website
          BpmMellowFeedsListImportDTO bpmFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<BpmMellowFeedsListImportDTO>(json);
          result = await _invService.UpdateBpmMellowFeedsList(empId, bpmFeedsList);
          break;
        case 12: // eBay
          eBayFeedsListImportDTO ebayFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<eBayFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = ebayFeedsList.skuList.Select(el =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = el.eBaySKU
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;

        case 14: // Houzz Drop Ship 
          HouzzFeedsListImportDTO houzzFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<HouzzFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = houzzFeedsList.skuList.Select(hl =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = hl.HouzzSKU
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;

        case 18: // Mellow Website
          BpmMellowFeedsListImportDTO mellowFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<BpmMellowFeedsListImportDTO>(json);
          result = await _invService.UpdateBpmMellowFeedsList(empId, mellowFeedsList);
          break;

        case 21: // Overstock Drop Ship
          OverstockFeedsListImportDTO ostFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<OverstockFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = ostFeedsList.skuList.Select(ol =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = ol.SupplierSku
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;

        case 26: // Walmart DSV
          WalmartFeedsListImportDTO walmartFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<WalmartFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = walmartFeedsList.skuList.Select(wl =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = wl.WalmartSKU
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;

        case 29: // Wayfair Drop Ship
          WayfairFeedsListImportDTO wayfairFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<WayfairFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = wayfairFeedsList.skuList.Select(wl =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = wl.SupplierPartNo
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;

        case 40: // Home Depot
          HomeDepotFeedsListImportDTO homeDepotFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<HomeDepotFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = homeDepotFeedsList.skuList.Select(hl =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = hl.yourSku,
            CustomerASIN = hl.custSku
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;

        case 51: // Target
          TargetFeedsListImportDTO targetFeedsList = Newtonsoft.Json.JsonConvert.DeserializeObject<TargetFeedsListImportDTO>(json);
          marketFeedsListItemImportDTOs = targetFeedsList.skuList.Select(tl =>
          new MarketFeedsListItemImportDTO()
          {
            CustomerSKU = tl.sku
          }).ToList();
          result = await _invService.UpdateMarketFeedsList(empId, Int32.Parse(tmpDTO.customerId), marketFeedsListItemImportDTOs);
          break;
      }

      //      int custId = Int32.Parse(customerId);

      //await _kc.SaveChangesAsync();
      //       var jsonData = Json(await _invService.GetInvAdvFeeds(startHisDate, endHisDate, todayDate));

      //return null;

      //return await Task.FromResult(RedirectToAction("InvMainslBancIdx", "Inventory"));
      //jsonData.StatusCode = 200;
      return Ok(StatusCode(200));
    }





    // For comparing inventory feeds
    // By Brian Yi on 09/23/2021
    [Authorize]
    [HttpGet("InvFeedsComparingIdx")]
    public ViewResult InvFeedsComparingIdx()
    {
      return View();
    }

    
    // For Stop All feeding from a certain warehouse
    // By Brian Yi on 03/21/2023
    [Authorize]
    [HttpGet("InvFeedsAllStopFeedingFrom")]
    public ViewResult InvFeedsAllStopFeedingFrom()
    {
      return View();
    }

    // /Inventory/GetAllStopWHsList
    [Authorize]
    [HttpGet("GetAllStopWHsList")]
    public async Task<IActionResult> GetAllStopWHsList()
    {
      var jsonData = Json(await _invService.GetAllStopWHsList());

      return jsonData;
    }



    // For comparing inventory feeds
    // By Brian Yi on 09/23/2021
    [Authorize]
    [HttpPost("CompareInventoryFeeds")]
    public async Task<IActionResult> CompareInventoryFeeds(JsonElement body)//string custId, string warehouseId, string compDate)
    {
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //List<MarketFeedsListItemImportDTO> marketFeedsListItemImportDTOs = new List<MarketFeedsListItemImportDTO>();
      //AmazonFeedsListImportDTO amazonFeedsListImportDTO = System.Text.Json.JsonSerializer.Deserialize<AmazonFeedsListImportDTO>(tmp);
      InvFeedsFromUserDTO tmpDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsFromUserDTO>(json);

      var jsonData = Json(await _invService.CompareInvFeeds(tmpDTO));
      return jsonData;
    }

    // For comparing inventory feeds(Wayfair Only)
    // By Brian Yi on 09/23/2021
    [Authorize]
    [HttpPost("CompareWayfairInventoryFeeds")]
    public async Task<IActionResult> CompareWayfairInventoryFeeds(JsonElement body)//string custId, string warehouseId, string compDate)
    {
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //List<MarketFeedsListItemImportDTO> marketFeedsListItemImportDTOs = new List<MarketFeedsListItemImportDTO>();

      //AmazonFeedsListImportDTO amazonFeedsListImportDTO = System.Text.Json.JsonSerializer.Deserialize<AmazonFeedsListImportDTO>(tmp);
      InvFeedsWayfairFromUserDTO tmpDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsWayfairFromUserDTO>(json);

      var jsonData = Json(await _invService.CompareWayfairInvFeeds(tmpDTO));
      return jsonData;
    }

    // For comparing inventory feeds(HomeDepot Only)
    // By Brian Yi on 09/05/2022
    [Authorize]
    [HttpPost("CompareHomeDepotInventoryFeeds")]
    public async Task<IActionResult> CompareHomeDepotInventoryFeeds(JsonElement body)//string custId, string warehouseId, string compDate)
    {
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //List<MarketFeedsListItemImportDTO> marketFeedsListItemImportDTOs = new List<MarketFeedsListItemImportDTO>();

      //AmazonFeedsListImportDTO amazonFeedsListImportDTO = System.Text.Json.JsonSerializer.Deserialize<AmazonFeedsListImportDTO>(tmp);
      InvFeedsHomeDepotFromUserDTO tmpDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsHomeDepotFromUserDTO>(json);

      var jsonData = Json(await _invService.CompareHomeDepotInvFeeds(tmpDTO));
      return jsonData;
    }


    // Get a Inventory SKU Detail
    // By Brian Yi on 09/29/2021
    [Authorize]
    [HttpGet("GetInvFeedsSKUStockRule")]
    public async Task<IActionResult> GetInvFeedsSKUStockRule(string inventoryItemId)
    {
      //string json = System.Text.Json.JsonSerializer.Serialize(body);
      long inventoryId = long.Parse(inventoryItemId);
      //int itemId = 1725;
      JsonResult jsonData = Json(await _invService.GetInvFeedsSKUStockRule(inventoryId));

      return jsonData;
      //return View(await _invService.GetSKUFeedingStatus(itemId));
      //return await Task.FromResult(RedirectToAction("InvFeedsSKUMarketStatusIdx", "Inventory"));
    }


    // Get a Inventory SKU Detail
    // By Brian Yi on 09/29/2021
    [Authorize]
    [HttpPost("UpdateInvFeedsSKUStockRule")]
    public async Task<IActionResult> UpdateInvFeedsSKUStockRule(JsonElement body)//string custId, string warehouseId, string compDate)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //List<MarketFeedsListItemImportDTO> marketFeedsListItemImportDTOs = new List<MarketFeedsListItemImportDTO>();
      //AmazonFeedsListImportDTO amazonFeedsListImportDTO = System.Text.Json.JsonSerializer.Deserialize<AmazonFeedsListImportDTO>(tmp);
      InvFeedsStockItemDetailDTO tmpDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<InvFeedsStockItemDetailDTO>(json);

      bool result = await _invService.UpdateInvFeedsSKUStockRule(empId, tmpDTO);
      if (result == true) return Ok(StatusCode(200));
      else return Ok(StatusCode(500));
      return Ok(StatusCode(200));
      //return View(await _invService.GetSKUFeedingStatus(itemId));
      //return await Task.FromResult(RedirectToAction("InvFeedsSKUMarketStatusIdx", "Inventory"));
    }

    // Reset all the feeding rules on SKUs
    // By Brian Yi on 05/20/2022
    [Authorize]
    [HttpPost("ResetAllTheRulesOnSKUs")]
    public async Task<IActionResult> ResetAllTheRulesOnSKUs()//string custId, string warehouseId, string compDate)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      bool result = await _invService.ResetAllTheRulesOnSKUs(empId);
      if (result == true) return Ok(StatusCode(200));
      else return Ok(StatusCode(500));
      return Ok(StatusCode(200));
      //return View(await _invService.GetSKUFeedingStatus(itemId));
      //return await Task.FromResult(RedirectToAction("InvFeedsSKUMarketStatusIdx", "Inventory"));
    }

    // This is for sending Target feeds to EDI
    // By Brian Yi on 06/18/2022
    [Authorize]
    [HttpPost("sendTargetFeedsToEDI")]
    public async Task<IActionResult> sendTargetFeedsToEDI()
    {
      DateTime today = DateTime.Now;

      int empId = GetUserId(User.Identity as ClaimsIdentity);

      int result = await _invService.InvFeedsQtyToTargetEDI(empId, today);
      if (result > 0) return Ok(StatusCode(200));
      else return Ok(StatusCode(500));
      return Ok(StatusCode(200));
    }

    // This is for getting Set SKU detail
    // By Brian Yi on 10/24/2022
    [Authorize]
    [HttpGet("GetSetSKUDetail")]
    public async Task<IActionResult> GetSetSKUDetail(string itemNoId)
    {
      int itemId = int.Parse(itemNoId);
      JsonResult jsonData = Json(await _invService.GetSetSKUDetail(itemId));

      return jsonData;
    }

    // This is for getting Left Over Qty. in Warehouses
    // By Brian Yi on 2/24/2023
    [Authorize]
    [HttpGet("GetLeftOverQty")]
    public async Task<IActionResult> GetLeftOverQty(string today)
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      // For test
      //string strDate = "May 10, 2021";
      DateTime todayDate = DateTime.Parse(today);
      //int itemId = int.Parse(itemNoId);
      JsonResult jsonData = Json(await _invService.GetLeftOverQty(todayDate));

      return jsonData;
    }

    // This is for getting Left Over Qty. in Warehouses
    // By Brian Yi on 3/23/2023
    [Authorize]
    [HttpGet("GetLeftOverQtyAfterFeeding")]
    public async Task<IActionResult> GetLeftOverQtyAfterFeeding(string today)
    {
      //int empId = GetUserId(User.Identity as ClaimsIdentity);
      // For test
      //string strDate = "May 10, 2021";
      DateTime todayDate = DateTime.Parse(today);
      //int itemId = int.Parse(itemNoId);
      JsonResult jsonData = Json(await _invService.GetLeftOverQty(todayDate));

      return jsonData;
    }

    [Authorize]
    [HttpPost("ProcessDailyZeroOutSkus")]
    public async Task<IActionResult> ProcessDailyZeroOutSkus(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      string json = System.Text.Json.JsonSerializer.Serialize(body);

      List<ZeroOutSKU> zeroOutSkuList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZeroOutSKU>>(json);

      JsonResult jsonData = Json(await _invService.ProcessDailyZeroOutSkus(empId, zeroOutSkuList));

      return jsonData;
    }

    // Email Notification Manual
    [Authorize]
    [HttpPost("FastMovingSKUsNotification")]
    public async Task<IActionResult> FastMovingSKUsNotification(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      string json = System.Text.Json.JsonSerializer.Serialize(body);

      List<ImportedFastMovingSKUDTO> fastMovingSKUsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImportedFastMovingSKUDTO>>(json);

      JsonResult jsonData = Json(await _invService.DailyFastMovingSKUs(empId, fastMovingSKUsList, _utilService));

      return jsonData;
    }
                    
    //SendFastMovingNotification
    // Send the fast moving notification
    // By Brian Yi on 06/26/2024
    [Authorize]
    [HttpPost("SendFastMovingNotification")]
    public async Task<IActionResult> SendFastMovingNotification()//string custId, string warehouseId, string compDate)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);

      JsonResult jsonData = Json(await _invService.AutoFastMovingNotification(empId, _utilService));

      return jsonData;
      //string json = System.Text.Json.JsonSerializer.Serialize(body);

      //List<ImportedFastMovingSKUDTO> fastMovingSKUsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ImportedFastMovingSKUDTO>>(json);


      //List<ImportedFastMovingSKUDTO> fastMovingSKUsList =

      //JsonResult jsonData = Json(await _invService.DailyFastMovingSKUs(empId, fastMovingSKUsList, _utilService));

      //return jsonData;
      //return View(await _invService.GetSKUFeedingStatus(itemId));
      //return await Task.FromResult(RedirectToAction("InvFeedsSKUMarketStatusIdx", "Inventory"));
    }


  }
}
