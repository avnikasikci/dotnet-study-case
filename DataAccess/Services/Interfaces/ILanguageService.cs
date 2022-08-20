using DataAccess.Domain;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface ILanguageService
    {
        IQueryable<Language> GetAll();
        Language SelectById(int Id);
        void Save(Language Language);
        LanguageDTO GetOneDTO(int id);
        List<LanguageDTO> GetAllDTO();

    }
}
