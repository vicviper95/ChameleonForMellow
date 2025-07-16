using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chameleon.DTOs.SalesReports;
using Chameleon.Models;
using Chameleon.Services.SalesReportsService;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Net.Mail;
using System.Net;
using Chameleon.Services.InventoryService;
using Chameleon.DTOs.Purchase;
using System.Collections;
using System.IO;
using System.Net.Http;

namespace Chameleon.Controllers
{
  [Route("SalesReports")]
  [ApiController]
  public class SalesReportsController : Controller
  {
    private readonly KOALAContext _kc;


    private readonly ISalesReportsService _salesReportsService;


    class scrappedData
    {
      string productTitle;
      double price;
      int ranking;
    }
    // Initialize
    public SalesReportsController(KOALAContext context, ISalesReportsService saleReportsService)
    {
      _kc = context;
      _salesReportsService = saleReportsService;
    }

    public ViewResult Index()
    {
      return View();
    }

    // For Amazon Performance Marketing Report
    // By Brian Yi on 01/25/2023
    [Authorize]
    [HttpGet("AmazonPerformanceMarketingReport")]
    public ViewResult AmazonPerformanceMarketingReport()
    {
      return View();
    }


    //ImportAmzPerfMrktRep
    [Authorize]
    [HttpPost("ImportAmzPerfMrktRep")]
    public async Task<IActionResult> ImportPrePOs(JsonElement body)
    {
      int empId = GetUserId(User.Identity as ClaimsIdentity);
      Employee emp = await _kc.Employees.Where(e => e.EmployeeId == empId).FirstOrDefaultAsync();
      string json = System.Text.Json.JsonSerializer.Serialize(body);
      //string tmp = json.Remove(json.IndexOf("["), 1);
      //tmp = tmp.Remove(tmp.LastIndexOf("]"), 1);

      List<AmzPerfMrktngRepImportDTO> amzRepList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AmzPerfMrktngRepImportDTO>>(json);

      JsonResult jsonData = Json(await _salesReportsService.ImportAmzPerfMrktReport(emp, amzRepList));

      return jsonData;
    }

    // Get Amazon Performance Marketing Report
    // By Brian Yi on 1/26/2023
    [Authorize]
    [HttpGet("GetAmazonAdReports")]
    public async Task<IActionResult> GetAmazonAdReports()
    {
      JsonResult jsonData = Json(await _salesReportsService.GetAmazonAdReports());

      return jsonData;
    }


    // Get Amazon Performance Marketing Report SKU History
    // By Brian Yi on 1/26/2023
    [Authorize]
    [HttpGet("GetAmzAdSkuHistory")]
    public async Task<IActionResult> GetAmzAdSkuHistory(string amzAdSkuId)
    {
      int amzAdSkuNo = 0;
      if (amzAdSkuId != null) { amzAdSkuNo = int.Parse(amzAdSkuId); }
      JsonResult jsonData = Json(await _salesReportsService.GetAmzAdSkuHistory(amzAdSkuNo));

      return jsonData;
    }

    //Task<AmazonAdRepDetail> GetAmzAdSkus(int amzAdRepNo);

    // Get Amazon Performance Marketing Report SKU History
    // By Brian Yi on 1/26/2023
    [Authorize]
    [HttpGet("GetAmzAdSkus")]
    public async Task<IActionResult> GetAmzAdSkus(string amzAdRepId)
    {
      int amzAdRepNo = 0;
      if (amzAdRepId != null) { amzAdRepNo = int.Parse(amzAdRepId); }
      JsonResult jsonData = Json(await _salesReportsService.GetAmzAdSkus(amzAdRepNo));

      return jsonData;
    }

    [HttpGet("TestCrawler")]
    public async Task<bool> TestCrawler ()
    {
      //string url = "https://www.amazon.com/Inch-Twin-XL-NapQueen-Mattress/dp/B09KDNYCYR/ref=sr_1_17?crid=79RL9EM5VWHW&keywords=Napqueen&qid=1677607255&sprefix=napqueen%2Caps%2C179&sr=8-17&ufe=app_do%3Aamzn1.fos.304cacc1-b508-45fb-a37f-a2c47c48c32f";

      //var httpClient = new HttpClient();
      //var html = await httpClient.GetStringAsync(url);
      //var htmlDocument = new HtmlDocument();
      //htmlDocument.LoadHtml(html);

      //scrappedData sData  = new scrappedData();



      return true;

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
