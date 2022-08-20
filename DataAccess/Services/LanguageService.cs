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
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _LanguageRepository;


        public LanguageService(IRepository<Language> LanguageRepository)
        {
            _LanguageRepository = LanguageRepository;
       
        }


        public IQueryable<Language> GetAll()
        {
            return _LanguageRepository.All;
            
        }
        public LanguageDTO GetOneDTO(int id)
        {
            var result = this.GetAll().Where(x=>x.Id == id).Select(x => new LanguageDTO
            {
                Id = x.Id,
                Name = x.Name,
                Culture = x.Culture,
                Icon = x.Icon,
                Approved = x.Approved
            }).ToList().FirstOrDefault();
            return result;

        }
        public List<LanguageDTO> GetAllDTO()
        {
            var result = this.GetAll().Select(x => new LanguageDTO
            {
                Id = x.Id,
                Name = x.Name,
                Culture = x.Culture,
                Icon = x.Icon,
                Approved = x.Approved
            }).ToList();
            return result;           

        }

        public void Save(Language Language)
        {
            if(Language.Id != 0)
            {
                _LanguageRepository.Update(Language);
            }
            else
            {
                _LanguageRepository.Insert(Language);

            }
            _LanguageRepository.SaveChanges();

        }

        public Language SelectById(int Id)
        {
            return _LanguageRepository.SelectById(Id);
        }
    }
}
