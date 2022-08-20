using Buisness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.CouponService
{
    public interface ICouponCodeService
    {
        string Generate(CouponCodeOptions opts);
        string Validate(string code, CouponCodeOptions opts);

    }
}
