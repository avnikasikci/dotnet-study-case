using DataAccess.Domain;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Interfaces
{
    public interface INewsAgencyService
    {
        IQueryable<NewsAgency> GetAll();
        NewsAgency SelectById(int Id);
        void Save(NewsAgency newsAgency);
        NewsAgencyDTO GetOneDTO(int id);
        List<NewsAgencyDTO> GetAllDTO();

    }
}
