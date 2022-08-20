using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{

    public class NewsAgencyEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NewsAgencyTranslate> translateList { get; set; }
    }
}
