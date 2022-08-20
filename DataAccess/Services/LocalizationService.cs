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
    public class LocalizationService : ILocalizationService
    {
        private readonly IRepository<Localization> _LocalizationRepository;


        public LocalizationService(IRepository<Localization> LocalizationRepository)
        {
            _LocalizationRepository = LocalizationRepository;
       
        }
        public LocalizationDTO GetOneDTO(int id)
        {
            var result = this.GetAll().Where(x => x.Id == id).Select(x => new LocalizationDTO
            {
                Id = x.Id,
                Key = x.Key,
                AllLangValue = x.AllLangValue,
             
            }).ToList().FirstOrDefault();
            return result;

        }
        public List<LocalizationDTO> GetAllDTO()
        {
            var result = this.GetAll().Select(x => new LocalizationDTO
            {
                Id = x.Id,
                Key = x.Key,
                AllLangValue = x.AllLangValue,
            }).ToList();
            return result;

        }


        public IQueryable<Localization> GetAll()
        {
            return _LocalizationRepository.All;
            
        }

        public void Save(Localization Localization)
        {
            if(Localization.Id != 0)
            {
                _LocalizationRepository.Update(Localization);
            }
            else
            {
                _LocalizationRepository.Insert(Localization);

            }
            _LocalizationRepository.SaveChanges();

        }

        public Localization SelectById(int Id)
        {
            return _LocalizationRepository.SelectById(Id);
        }
    }
}
