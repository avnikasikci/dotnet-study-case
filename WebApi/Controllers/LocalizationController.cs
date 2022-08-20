using DataAccess.Domain;
using DataAccess.DTO;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalizationController : ControllerBase
    {

        private readonly ILogger<LocalizationController> _logger;
        private readonly ILocalizationService _LocalizationService;

        public LocalizationController(ILogger<LocalizationController> logger, ILocalizationService LocalizationService)
        {
            _logger = logger;
            _LocalizationService = LocalizationService;

        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            //var AllNews = _LocalizationService.GetAll();
            var AllLocale = _LocalizationService.GetAllDTO();

            return Ok(AllLocale);
        }
        [HttpGet("GetOne")]
        public IActionResult GetOne(int id)
        {
            //var News = _LocalizationService.GetAll().Where(x => x.Id == id);
            var Locale = _LocalizationService.GetOneDTO(id);

            return Ok(Locale);
        }
        [HttpPost()]
        public IActionResult Create(LocalizationEditModel LocalizationDTO)
        {
            var Entity = new Localization();
            Entity.Key = LocalizationDTO.Key;
            Entity.AllLangValue = LocalizationDTO.AllLangValue;
            Entity.Active = LocalizationDTO.Active;

            _LocalizationService.Save(Entity);
            LocalizationDTO.Id = Entity.Id;
            return Ok(LocalizationDTO);
        }
        [HttpPut()]
        public IActionResult Update(LocalizationEditModel LocalizationDTO)
        {
            if (LocalizationDTO.Id <= 0)
            {
                return BadRequest("Not find record");
            }
            //var Entity = new Language();
            var Entity = _LocalizationService.SelectById(LocalizationDTO.Id);
            if (Entity.Id <= 0)
            {
                return BadRequest("Not find record");

            }
            Entity.Key = LocalizationDTO.Key;
            Entity.AllLangValue = LocalizationDTO.AllLangValue;
            Entity.Active = LocalizationDTO.Active;

            _LocalizationService.Save(Entity);


            LocalizationDTO.Id = Entity.Id;
            return Ok(LocalizationDTO);
        }



    }
}
