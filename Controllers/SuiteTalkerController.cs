using Chameleon.Models;
using Chameleon.Services.SuiteTalkerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Controllers
{
    [Route("ns")]
    [ApiController]
    public class SuitetalkerController : Controller
    {
        private readonly ISuiteTalkerService _suiteTalkerService;
        private readonly KOALAContext _kc = new KOALAContext();

        public SuitetalkerController(KOALAContext context, ISuiteTalkerService suiteTalkerService)
        {
            _kc = context;
            _suiteTalkerService = suiteTalkerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("test")]
        public async void TestSuiteTalk()
        {
            //_suiteTalkerService.CreateSO();

            //_suiteTalkerService.TestNsClient();
        }
    }
}
