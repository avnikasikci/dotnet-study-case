using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcrConsole
{
    public class OcrModel
    {
        public string locale { get; set; }
        public string description { get; set; }
        public boundingPoly boundingPoly { get; set; }
        //public List<vertices> boundingPoly { get; set; }
    }
    public class boundingPoly
    {
        public List<vertices> vertices { get; set; }
    }
    public class vertices {
        public int x { get; set; }
        public int y { get; set; }

    }
    public class OcrResult
    {
        public int Line { get; set; }
        public string Text { get; set; }
    }
}
