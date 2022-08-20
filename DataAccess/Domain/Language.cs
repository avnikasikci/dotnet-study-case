using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class Language//
    {
        public int Id { get; set; }
        public string Culture { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
    }
}
