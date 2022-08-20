using DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{

    public class LocalizationEditModel
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public Dictionary<string, string> AllLangValue
        {
            get; set;
        }
        public bool Active { get; set; }
    }
}
