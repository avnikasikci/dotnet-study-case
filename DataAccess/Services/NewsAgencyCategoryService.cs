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
    public class NewsAgencyCategoryService : INewsAgencyCategoryService
    {
        private readonly IRepository<NewsAgencyCategory> _NewsAgencyCategoryRepository;
        private readonly ILanguageService _LanguageService;


        public NewsAgencyCategoryService(IRepository<NewsAgencyCategory> NewsAgencyCategoryRepository, ILanguageService LanguageService)
        {
            _NewsAgencyCategoryRepository = NewsAgencyCategoryRepository;
            _LanguageService = LanguageService;

        }
        public NewsAgencyCategoryDTO GetOneDTO(int id)
        {

            var result = this.GetAll().ToList().Where(x => x.Id == id).Select(x => new NewsAgencyCategoryDTO
            {
                Id = x.Id,
                Key = x.Key,
                translateList = (from translate in x.translateList.ToList()
                                 join lang in _LanguageService.GetAll().ToList() on translate.LocaleId equals lang.Id
                                 select new NewsAgencyCategoryTranslateDTO()
                                 {
                                     LocaleId = translate.LocaleId,
                                     Name = translate.Name,
                                     LocaleName = lang.Name
                                 }).ToList()

                //x.translateList.Select(translate => new NewsAgencyCategoryTranslateDTO { LocaleId = translate.LocaleId, Name = translate.Name, LocaleName)

            }).ToList().FirstOrDefault();

            return result;

        }
        public List<NewsAgencyCategoryDTO> GetAllDTO()
        {
            var result = this.GetAll().ToList().Select(x => new NewsAgencyCategoryDTO
            {
                Id = x.Id,
                Key = x.Key,
                translateList = (from translate in x.translateList.ToList()
                                 join lang in _LanguageService.GetAll().ToList() on translate.LocaleId equals lang.Id
                                 select new NewsAgencyCategoryTranslateDTO()
                                 {
                                     LocaleId = translate.LocaleId,
                                     Name = translate.Name,
                                     LocaleName = lang.Name
                                 }).ToList()
            }).ToList();
            return result;

        }

        public IQueryable<NewsAgencyCategory> GetAll()
        {
            return _NewsAgencyCategoryRepository.All;

        }

        public void Save(NewsAgencyCategory NewsAgencyCategory)
        {
            if (NewsAgencyCategory.Id != 0)
            {
                _NewsAgencyCategoryRepository.Update(NewsAgencyCategory);
            }
            else
            {
                _NewsAgencyCategoryRepository.Insert(NewsAgencyCategory);

            }
            _NewsAgencyCategoryRepository.SaveChanges();

        }

        public NewsAgencyCategory SelectById(int Id)
        {
            return _NewsAgencyCategoryRepository.SelectById(Id);
        }
    }
}
