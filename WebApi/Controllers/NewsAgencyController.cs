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
    [Route("api/[controller]")]
    [ApiController]
    public class NewsAgencyController : ControllerBase
    {

        private readonly INewsAgencyService _NewsAgencyService;

        public NewsAgencyController( INewsAgencyService NewsAgencyService)
        {
            _NewsAgencyService = NewsAgencyService;
        
        }
        //[HttpGet()]
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            //var AllNews = _NewsAgencyService.GetAll().ToList();
            //var result = AllNews.Select(x => new NewsAgencyEditModel { Id = x.Id, Name = x.Name, translateList = x.translateList.ToList() });
            var result = _NewsAgencyService.GetAllDTO();
            return Ok(result);
        }
        [HttpGet("GetOne")]
        public IActionResult GetOne(int id)
        {
            //var News = _NewsAgencyService.GetAll().Where(x=>x.Id == id);
            var result = _NewsAgencyService.GetOneDTO(id);

            return Ok(result);
        }
        [HttpPost()]
        public IActionResult Create(NewsAgencyEditModel newsAgencyDTO)
        {
            var Entity = new NewsAgency();
            Entity.Name = newsAgencyDTO.Name;
            Entity.translateList = newsAgencyDTO.translateList;
            
            _NewsAgencyService.Save(Entity);
            newsAgencyDTO.Id = Entity.Id;
            return Ok(newsAgencyDTO);
        }
        [HttpPut()]
        public IActionResult Update(NewsAgencyEditModel newsAgencyDTO)
        {
            if(newsAgencyDTO.Id <= 0)
            {
                return BadRequest("Not find record");
            }
            //var Entity = new NewsAgency();
            var Entity =_NewsAgencyService.SelectById(newsAgencyDTO.Id);
            Entity.Name = newsAgencyDTO.Name;
            Entity.translateList = newsAgencyDTO.translateList;
            _NewsAgencyService.Save(Entity);

            newsAgencyDTO.Id = Entity.Id;
            return Ok(newsAgencyDTO);
        }



    }
}
