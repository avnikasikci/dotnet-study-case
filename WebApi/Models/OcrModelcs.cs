using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class OcrModelcs
    {
        public string locale { get; set; }
        public string description { get; set; }
        //public string boundingPoly { get; set; }
        public List<vertices> boundingPoly { get; set; }
    }
    public class vertices {
        public int x { get; set; }
        public int y { get; set; }

    }
}
