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
    public class NewsAgencyCategoryController : ControllerBase
    {

        private readonly ILogger<NewsAgencyCategoryController> _logger;
        private readonly INewsAgencyCategoryService _NewsAgencyCategoryService;

        public NewsAgencyCategoryController(ILogger<NewsAgencyCategoryController> logger, INewsAgencyCategoryService NewsAgencyCategoryService)
        {
            _logger = logger;
            _NewsAgencyCategoryService = NewsAgencyCategoryService;
        
        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            //var AllNews = _NewsAgencyCategoryService.GetAll().ToList();
            //var result = AllNews.Select(x => new NewsAgencyCategoryEditModel { Id = x.Id, Key = x.Key, translateList = x.translateList.ToList() });
            var result = _NewsAgencyCategoryService.GetAllDTO();
            return Ok(result);
        }
        [HttpGet("GetOne")]
        public IActionResult GetOne(int id)
        {
            var result = _NewsAgencyCategoryService.GetOneDTO(id);

            //var News = _NewsAgencyCategoryService.GetAll().Where(x=>x.Id == id);

            return Ok(result);
        }
        [HttpPost()]
        public IActionResult Create(NewsAgencyCategoryEditModel newsAgencyDTO)
        {
            var Entity = new NewsAgencyCategory();
            Entity.Key = newsAgencyDTO.Key;
            Entity.translateList = newsAgencyDTO.translateList;

            _NewsAgencyCategoryService.Save(Entity);
            newsAgencyDTO.Id = Entity.Id;
            return Ok(newsAgencyDTO);
        }
        [HttpPut()]
        public IActionResult Update(NewsAgencyCategoryEditModel newsAgencyDTO)
        {
            if(newsAgencyDTO.Id <= 0)
            {
                return BadRequest("Not find record");
            }
            //var Entity = new NewsAgency();
            var Entity = _NewsAgencyCategoryService.SelectById(newsAgencyDTO.Id);
            Entity.Key = newsAgencyDTO.Key;
            Entity.translateList = newsAgencyDTO.translateList;
            _NewsAgencyCategoryService.Save(Entity);
            newsAgencyDTO.Id = Entity.Id;

            return Ok(newsAgencyDTO);
        }



    }
}
