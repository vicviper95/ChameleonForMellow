using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Chameleon.DTOs.Inventory;
using Chameleon.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text.Json;
using Chameleon.Services.PurchaseService;
using Chameleon.DTOs.Purchase;

namespace Chameleon.Controllers
{
  [Route("Purchase")]
  [ApiController]
  public class PurchaseController : Controller
  {
    private readonly KOALAContext _kc;
    private readonly IPurchaseService _purchaseService;

    // Initialize
    public PurchaseController(KOALAContext context, IPurchaseService purchaseService)
    {
      _kc = context;
      _purchaseService = purchaseService;
    }


    [Authorize]
    [HttpGet("POAcceptanceDashboard")]
    public ViewResult POAcceptanceDashboard()
    {
      return View();
    }

    [Authorize]
    [HttpGet("SKUStausUpdate")]
    public ViewResult SKUStausUpdate()
    {
      return View();
    }

    [Authorize]
    [HttpGet("GetPOAccptDB")]
    public async Task<IActionResult> GetPOAccptDB(string startDate, string endDate)
    {
      DateTime FromDate = DateTime.Parse(startDate);
      DateTime ToDate = DateTime.Parse(endDate).AddDays(1);

      var jsonData = Json(await _purchaseService.GetAllPrePOsForDashboard(FromDate, ToDate));
      return jsonData;
    }

    [Authorize]
    [HttpGet("GetPrePODetail")]
    public async Task<IActionResult> GetPrePODetail(string prePOId)
    {
      long prePONo = long.Parse(prePOId);
      JsonResult jsonData = Json(await _purchaseService.GetPrePODetail(prePONo));

      return jsonData;
    }

    [Authorize]
    [HttpGet("GetPrePOHistory")]
    public async Task<IActionResult> GetPrePOHistory(string prePOId)
    {
      long prePONo = 0;
      if (prePOId != null) { prePONo = long.Parse(prePOId); }
      JsonResult jsonData = Json(await _purchaseService.GetPrePOHistory(prePONo));

      return jsonData;
    }//


    [Authorize]
    [HttpGet("GetPrePOHistoryDetail")]
    public async Task<IActionResult> GetPrePOHistoryDetail(string prePOHistoryId)
    {
      long prePONo = long.Parse(prePOHistoryId);
      JsonResult jsonData = Json(await _purchaseService.GetPrePOHistoryDetail(prePONo));

      return jsonData;
    }


    // Get a list of vendors
    // By Brian Yi on 01/12/2022
    [Authorize]
    [HttpGet("GetPrePOVendorList")]
    public async Task<IActionResult> GetPrePOVendorList()
    {
      JsonResult jsonData = Json(await _purchaseService.GetVendorList());

      return jsonData;
    }


    // Get a list of BPM Item
    // By Brian Yi on 01/12/2022
    [Authorize]
    [HttpGet("GetPrePOBPMItemList")]
    public async Task<IActionResult> GetPrePOBPMItemList()
    {
      JsonResult jsonData = Json(await _purchaseService.GetPrePOBPMItemList());

      return jsonData;
    }

    //
    [Authorize]
    [HttpGet("GetPrePOSKUList")]
    public async Task<IActionResult> GetPrePOSKUList()
    {
      JsonResult jsonData = Json(await _purchaseService.GetPrePOSKUList());

      return jsonData;
    }

    // Get a list of BPM Item
    // By Brian Yi on 01/12/2022
    //[Authorize]
    [HttpPost("UpsertPrePO")]
    public async Task<IActionResult> UpdatePrePO(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      PrePOItemDTO tmpDTO = new PrePOItemDTO();
      try
      {
        tmpDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<PrePOItemDTO>(json);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      //JsonResult jsonData = Json(await _purchaseService.GetPrePOBPMItemList());
      JsonResult jsonData;
      if (tmpDTO.prePOStatus == 0)  // Adding 
      {
        jsonData = Json(await _purchaseService.CreatePrePO(emp, tmpDTO));
      }
      else // Updating
      {
        jsonData = Json(await _purchaseService.UpdatePrePO(emp, tmpDTO));
      }
      return jsonData;
    }

    // All Buttons by Brian Yi on 1/21/2022
    
    // Accept/Approve
    [Authorize]
    [HttpPost("GetAcceptApprovePrePOs")]
    public async Task<IActionResult> GetAcceptApprovePrePOs(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<string> prePOList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);

      JsonResult jsonData = Json(await _purchaseService.GetAcceptApprovePrePOs(emp, prePOList));

      return jsonData;
    }
    //DeletePrePOs


    // Delete PrePOs
    // By Brian Yi on 02/02/2022
    [Authorize]
    [HttpPost("GetDeletedPrePOs")]
    public async Task<IActionResult> GetDeletedPrePOs(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<string> prePOList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);

      JsonResult jsonData = Json(await _purchaseService.GetDeletedPrePOs(emp, prePOList));

      return jsonData;
    }

    // Accept/Approve
    [Authorize]
    [HttpPost("GetClosedDeclinedPrePOs")]
    public async Task<IActionResult> GetClosedDeclinedPrePOs(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<string> prePOList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);

      JsonResult jsonData = Json(await _purchaseService.GetClosedDeclinedPrePOs(emp, prePOList));

      return jsonData;
    }

    //Import PrePOs from user
    // By Brian Yi on 01/24/2022
    [Authorize]
    [HttpPost("ImportPrePOs")]
    public async Task<IActionResult> ImportPrePOs(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<PrePOImportDTO> prePOList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PrePOImportDTO>>(json);

      JsonResult jsonData = Json(await _purchaseService.ImportPrePOs(emp, prePOList));

      return jsonData;
    }

    // ImportPrePOLogistics from user
    // By Brian Yi on 02/08/2022
    [Authorize]
    [HttpPost("ImportPrePOLogistics")]
    public async Task<IActionResult> ImportPrePOLogistics(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);

      List<PrePOLogisticsImportDTO> prePOLogisticsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PrePOLogisticsImportDTO>>(json);

      JsonResult jsonData = Json(await _purchaseService.ImportPrePOLogistics(emp, prePOLogisticsList));

      return jsonData;
    }


    //Import PrePOs from user
    // By Brian Yi on 01/26/2022
    [Authorize]
    [HttpGet("PrePODashboardAuth")]
    public async Task<IActionResult> PrePODashboardAuth()
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      //string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      //List<PrePOImportDTO> prePOList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PrePOImportDTO>>(json);

      JsonResult jsonData = Json(_purchaseService.PrePODashboardAuth(emp));

      return jsonData;
    }

    // Get a list of SKUs
    // By Brian Yi on 08/30/2022
    [Authorize]
    [HttpGet("GetSKUList")]
    public async Task<IActionResult> GetSKUList()
    {
      JsonResult jsonData = Json(await _purchaseService.GetSKUList());

      return jsonData;
    }


    // Import SKU status list from user
    // By Brian Yi on 08/30/2022
    [Authorize]
    [HttpPost("ImportSKUStatus")]
    public async Task<IActionResult> ImportSKUStatus(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);

      List<SKUStatusImportDTO> prePOLogisticsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SKUStatusImportDTO>>(json);

      JsonResult jsonData = Json(await _purchaseService.ImportSKUStatus(emp, prePOLogisticsList));

      return jsonData;
    }


    // By Brian Yi on 06/06/2021
    // Get Employee ID from cookie
    // ex) int empId = GetUserId(User.Identity as ClaimsIdentity);
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




  }
}
