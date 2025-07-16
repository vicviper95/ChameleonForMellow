using Chameleon.Models;
using Chameleon.Services.AmazonService;
using Chameleon.Services.SuiteTalkerService;
using Chameleon.Services.WayfairService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Chameleon.Services.ServiceUtil;
using System.Collections;

namespace Chameleon.Controllers
{
    [Route("amazon")]
    [ApiController]
    public class AmazonController : Controller
    {
        private readonly ISuiteTalkerService _suiteTalkerService;
        private readonly IAmazonService _amazonService;
        private readonly KOALAContext _kc;
        public AmazonController(KOALAContext context, IAmazonService amazonService, ISuiteTalkerService suiteTalkerService)
        {
            _suiteTalkerService = suiteTalkerService;
            _kc = context;
            _amazonService = amazonService;
        }
        [Authorize]
        [HttpGet("amzReport")]
        public IActionResult Report()
        {
            return View();
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("syncAmz")]
        public async Task<IActionResult> InsertAmzOrderByDate()
        {
            JsonResult jsonData = Json(await _amazonService.InsertAmazonOrder(SearchType.Date, null));
            return jsonData;
        }
        [HttpGet("syncToNs")]
        public async Task<IActionResult> SyncToPoToNS()
        {
            JsonResult jsonData = Json(await _suiteTalkerService.InsertPoToNs());
            return jsonData;
        }
        [HttpGet("getPO")]
        public async Task<IActionResult> AmazonOrders(string startDate, string endDate)
        {
            JsonResult jsonData = Json(await _amazonService.GetAmazonOrders(startDate, endDate));
            return jsonData;
        }
        [HttpGet("getError")]
        public async Task<IActionResult> GetError()
        {
            JsonResult jsonData = Json(await _amazonService.GetErrorPo());
            return jsonData;
        }
        [HttpGet("getMiss")]
        public async Task<IActionResult> GetAmazonMissingPO()
        {
            JsonResult jsonData = Json(await _amazonService.GetAmazonMissingPO());
            return jsonData;
        }
        [HttpGet("retrySyncAmz")]
        public async Task<IActionResult> InsertAmazonPoByPo(string SoNums)
        {
            List<string> SoList = JsonSerializer.Deserialize<List<string>>(SoNums);
            JsonResult jsonData = Json(await _amazonService.InsertAmazonOrder(SearchType.PoNumber, SoList));
            return jsonData;
        }    
    }
}
