using Chameleon.Models;
using Chameleon.Services.SuiteTalkerService;
using Chameleon.Services.WayfairService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Chameleon.Services.ServiceUtil;
using SuitetalkerService;

namespace Chameleon.Controllers
{
    [Route("wayfair")]
    [ApiController]
    public class WayfairController : Controller
    {
        private readonly ISuiteTalkerService _suiteTalkerService;
        private readonly IWayfairService _wayfairService;
        private readonly KOALAContext _kc;
        public WayfairController(KOALAContext context, IWayfairService wayfairService, ISuiteTalkerService suiteTalkerService)
        {
            _suiteTalkerService = suiteTalkerService;
            _kc = context;
            _wayfairService = wayfairService;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet("syncWF")]
        public async Task<IActionResult> InsertWayfiarItemByDate()
        {
            bool isSucceed = await _wayfairService.InsertWayfairOrder(SearchType.Date, null);
            JsonResult jsonData = Json(isSucceed);
            return jsonData;
        }
        [HttpGet("retrySyncWF")]
        public async Task<IActionResult> InsertWayfiarItemByPo(string SoNums)
        {
            List<string> SoList = JsonSerializer.Deserialize<List<string>>(SoNums);
            bool isSucceed = await _wayfairService.InsertWayfairOrder(SearchType.PoNumber, SoList);
            JsonResult jsonData = Json(isSucceed);
            return jsonData;
        }
        [HttpGet("getSO")]
        public async Task<IActionResult> WFOrders(string startDate, string endDate)
        {
            JsonResult jsonData = Json(await _wayfairService.GetWFOrders(startDate, endDate));
            return jsonData;
        }
        [HttpGet("getError")]
        public async Task<IActionResult> GetError()
        {
            JsonResult jsonData = Json(await _wayfairService.GetErrorSo());
            return jsonData;
        }
    }
}
