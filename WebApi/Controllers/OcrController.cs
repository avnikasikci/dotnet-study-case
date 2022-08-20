using Infrastructure.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcrController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OcrController> _logger;

        public OcrController(ILogger<OcrController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            //OcrResult ocrResult = JsonConvert.DeserializeObject<OcrResult>(JSONResult);

            //StringBuilder sb = new StringBuilder();

            //if (!ocrResult.Language.Equals("unk"))
            //{
            //    foreach (OcrLine ocrLine in ocrResult.Regions[0].Lines)
            //    {
            //        foreach (OcrWord ocrWord in ocrLine.Words)
            //        {
            //            sb.Append(ocrWord.Text);
            //            sb.Append(' ');
            //        }
            //        sb.AppendLine();
            //    }
            //}


            string allText = System.IO.File.ReadAllText(@"D:\Avni\Projects\ProjectCaseStudy\Kaizen\StudyCase\dotnet-study-case\WebApi\response.json");
            var JsonObj = UtilityJson.JsonDeserialize<List<dynamic>>(allText).ToList();
            //public virtual IList<NewsAgencyTranslate> translateList { get => (UtilityJson.JsonDeserialize<IList<NewsAgencyTranslate>>(JsonTranslate)); set { JsonTranslate = UtilityJson.JsonSerialize(value); } }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
