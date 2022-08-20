using Buisness.CouponService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    //public class CouponCodeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
    [ApiController]
    [Route("[controller]")]
    public class CouponCodeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CouponCodeController> _logger;
        private readonly ICouponCodeService _CouponCodeService;

        
        public CouponCodeController(ILogger<CouponCodeController> logger, ICouponCodeService CouponCodeService)
        {
            _logger = logger;
            _CouponCodeService = CouponCodeService;
        }
        [HttpGet("getallbycount")]
        public IActionResult GetAllByCount(int count)
        {

            var codeList = new List<String>();
            //for(int i=0;i<count; i++)
            //{
            //    var code = _CouponCodeService.Generate(new Buisness.DTO.CouponCodeOptions{ Parts = 4, PartLength = 2 });
            //    if(codeList.Any(x => x != code))
            //    {
            //        codeList.Add(code);
            //    }
                
            //}

            do
            {
                var code = _CouponCodeService.Generate(new Buisness.DTO.CouponCodeOptions { Parts = 4, PartLength = 2 });
                if (codeList.Count == 0 || codeList.Any(x => x != code))
                {
                    codeList.Add(code);
                }

            } while (codeList.Count <= count);


            //var result = _colorService.GetAll();
            //if (result.Success) return Ok(result);

            //return BadRequest(result);
            return Ok(codeList);
        }
        [HttpPost("checkallcopoun")]
        public IActionResult checkallcopoun(List<string> codeJson)
        {
            
            //var codeList = new List<String>();
            //var codeList = codeJson.Split(',').ToList();
            var codeList = codeJson;
            var result = false;
            var codeListDisc = codeList.Distinct().ToList();
            
            var duplicateKeys = codeList.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key).ToList();

            if (codeListDisc.Count() == codeList.Count())
            {
                result = true;
            }
            //for (int i = 0; i < count; i++)
            //{
            //    var code = _CouponCodeService.Generate(new Buisness.DTO.CouponCodeOptions { Parts = 4, PartLength = 2 });
            //}


            //var result = _colorService.GetAll();
            //if (result.Success) return Ok(result);

            //return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("validate")]
        public IActionResult Validate(string code)
        {

            var output = _CouponCodeService.Validate(code, new Buisness.DTO.CouponCodeOptions { Parts = 4, PartLength = 2 });
            return Ok(output);
        }
    }
}
