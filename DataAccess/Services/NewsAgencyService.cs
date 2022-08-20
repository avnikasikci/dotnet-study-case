using DataAccess.Domain;
using DataAccess.DTO;
using DataAccess.Repository;
using DataAccess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class NewsAgencyService : INewsAgencyService
    {
        private readonly IRepository<NewsAgency> _NewsAgencyRepository;
        private readonly ILanguageService _LanguageService;
        private readonly INewsAgencyCategoryService _NewsAgencyCategoryService;


        public NewsAgencyService(IRepository<NewsAgency> NewsAgencyRepository, ILanguageService LanguageService, INewsAgencyCategoryService NewsAgencyCategoryService)
        {
            _NewsAgencyRepository = NewsAgencyRepository;
            _LanguageService = LanguageService;
            _NewsAgencyCategoryService = NewsAgencyCategoryService;
       
        }
  
        public NewsAgencyDTO GetOneDTO(int id)
        {

            var result = this.GetAll().ToList().Where(x => x.Id == id).Select(x => new NewsAgencyDTO
            {
                Id = x.Id,
                Name = x.Name,
                translateList = (from translate in x.translateList.ToList()
                                 join lang in _LanguageService.GetAll().ToList() on translate.LocaleId equals lang.Id
                                 join category in _NewsAgencyCategoryService.GetAll().ToList() on translate.CategoryId equals category.Id
                                 select new NewsAgencyTranslateDTO()
                                 {
                                     LocaleId = translate.LocaleId,
                                     LocaleName = lang.Name,
                                     CategoryId = translate.CategoryId,
                                     CategoryName = category.translateList.ToList().Where(x=>x.LocaleId == translate.LocaleId).FirstOrDefault().Name ?? "",
                                     Title = translate.Title,
                                     Detail = translate.Detail,
                                     ImageUrls = translate.ImageUrls,
                                 }).ToList()

                //x.translateList.Select(translate => new NewsAgencyCategoryTranslateDTO { LocaleId = translate.LocaleId, Name = translate.Name, LocaleName)

            }).ToList().FirstOrDefault();

            return result;

        }
        public List<NewsAgencyDTO> GetAllDTO()
        {

            var result = this.GetAll().ToList().Select(x => new NewsAgencyDTO
            {
                Id = x.Id,
                Name = x.Name,
                translateList = (from translate in x.translateList.ToList()
                                 join lang in _LanguageService.GetAll().ToList() on translate.LocaleId equals lang.Id
                                 join category in _NewsAgencyCategoryService.GetAll().ToList() on translate.CategoryId equals category.Id
                                 select new NewsAgencyTranslateDTO()
                                 {
                                     LocaleId = translate.LocaleId,
                                     LocaleName = lang.Name,
                                     CategoryId = translate.CategoryId,
                                     CategoryName = category.translateList.ToList().Where(x => x.LocaleId == translate.LocaleId).FirstOrDefault().Name ?? "",
                                     Title = translate.Title,
                                     Detail = translate.Detail,
                                     ImageUrls = translate.ImageUrls,
                                 }).ToList()

                //x.translateList.Select(translate => new NewsAgencyCategoryTranslateDTO { LocaleId = translate.LocaleId, Name = translate.Name, LocaleName)

            }).ToList();
            return result;

        }

        public IQueryable<NewsAgency> GetAll()
        {
            return _NewsAgencyRepository.All;
            
        }

        public void Save(NewsAgency newsAgency)
        {
            if(newsAgency.Id != 0)
            {
                _NewsAgencyRepository.Update(newsAgency);
            }
            else
            {
                _NewsAgencyRepository.Insert(newsAgency);

            }
            _NewsAgencyRepository.SaveChanges();

        }

        public NewsAgency SelectById(int Id)
        {
            return _NewsAgencyRepository.SelectById(Id);
        }
    }
}
