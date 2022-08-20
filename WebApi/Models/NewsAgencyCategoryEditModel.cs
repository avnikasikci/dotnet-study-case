using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{

    public class NewsAgencyCategoryEditModel
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public List<NewsAgencyCategoryTranslate> translateList { get; set; }
    }
}
