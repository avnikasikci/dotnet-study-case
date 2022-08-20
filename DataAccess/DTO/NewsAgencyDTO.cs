using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{

    public class NewsAgencyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NewsAgencyTranslateDTO> translateList { get; set; }
    }
    public class NewsAgencyTranslateDTO
    {
        //public int Id { get; set; }
        //public int NewsAgencyId { get; set; }
        public int LocaleId { get; set; }
        public string LocaleName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrls { get; set; }
        //public string Category { get; set; }
        //public bool Active { get; set; }
        //public virtual NewsAgency NewsAgency { get; set; }
    }
}
