using DataAccess.Domain;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface INewsAgencyCategoryService
    {
        IQueryable<NewsAgencyCategory> GetAll();
        NewsAgencyCategory SelectById(int Id);
        void Save(NewsAgencyCategory kiraci);
        NewsAgencyCategoryDTO GetOneDTO(int id);
        List<NewsAgencyCategoryDTO> GetAllDTO();

    }
}
