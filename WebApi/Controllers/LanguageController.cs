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
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {

        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageService _LanguageService;

        public LanguageController(ILogger<LanguageController> logger, ILanguageService LanguageService)
        {
            _logger = logger;
            _LanguageService = LanguageService;
        
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            var AllNews = _LanguageService.GetAll();
           
            return Ok(AllNews);
        }
        [HttpGet("GetOne")]
        public IActionResult GetOne(int id)
        {
            var News = _LanguageService.GetAll().Where(x=>x.Id == id);

            return Ok(News);
        }
        [HttpPost()]
        public IActionResult Create(LanguageEditModel LanguageEditModel)
        {
            var Entity = new Language();
            Entity.Name = LanguageEditModel.Name;
            Entity.Culture = LanguageEditModel.Culture;
            Entity.Icon = LanguageEditModel.Icon;
            Entity.Active = LanguageEditModel.Active;
            Entity.Approved = LanguageEditModel.Approved;
            
            _LanguageService.Save(Entity);
            LanguageEditModel.Id = Entity.Id;
            return Ok(LanguageEditModel);

        }
        [HttpPut()]
        public IActionResult Update(LanguageEditModel LanguageEditModel)
        {
            if(LanguageEditModel.Id <= 0)
            {
                return BadRequest("Not find record");
            }
            //var Entity = new Language();
            var Entity =_LanguageService.SelectById(LanguageEditModel.Id);
            Entity.Name = LanguageEditModel.Name;
            Entity.Culture = LanguageEditModel.Culture;
            Entity.Icon = LanguageEditModel.Icon;
            Entity.Active = LanguageEditModel.Active;
            Entity.Approved = LanguageEditModel.Approved;
            _LanguageService.Save(Entity);

            LanguageEditModel.Id = Entity.Id;
            return Ok(LanguageEditModel);
        }



    }
}
