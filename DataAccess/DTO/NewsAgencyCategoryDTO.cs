using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{

    public class NewsAgencyCategoryDTO
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public List<NewsAgencyCategoryTranslateDTO> translateList { get; set; }
    }
    public class NewsAgencyCategoryTranslateDTO
    {
        public int LocaleId { get; set; }
        public string LocaleName { get; set; }
        public string Name { get; set; }
    }
}
