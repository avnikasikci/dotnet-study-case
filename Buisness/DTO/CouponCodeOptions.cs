using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DTO
{
    public class CouponCodeOptions
    {
        public int Parts { get; set; }
        public int PartLength { get; set; }
        public string Plaintext { get; set; }

        public CouponCodeOptions()
        {
            this.Parts = 3;
            this.PartLength = 4;
            this.Plaintext = "test";
        }
    }
}
