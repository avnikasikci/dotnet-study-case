using DataAccess.Domain;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface ILocalizationService
    {
        IQueryable<Localization> GetAll();
        Localization SelectById(int Id);
        void Save(Localization Localization);

        LocalizationDTO GetOneDTO(int id);
        List<LocalizationDTO> GetAllDTO();
    }
}
