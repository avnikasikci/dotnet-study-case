using Buisness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.CouponService
{
    public class CouponCodeService : ICouponCodeService
    {
        private readonly Dictionary<char, int> symbolsDictionary = new Dictionary<char, int>();
        private char[] symbols;
        public CouponCodeService()
        {
            //this.BadWordsList = new List<string>("SHPX PHAG JNAX JNAT CVFF PBPX FUVG GJNG GVGF SNEG URYY ZHSS QVPX XABO NEFR FUNT GBFF FYHG GHEQ FYNT PENC CBBC OHGG SRPX OBBO WVFZ WVMM CUNG'".Split(' '));
            this.SetupSymbolsDictionary();
            //this.randomNumberGenerator = new SecureRandom();
        }
        private void SetupSymbolsDictionary()
        {
            //const string AvailableSymbols = "0123456789ABCDEFGHJKLMNPQRTUVWXY";
            const string AvailableSymbols = "ACDEFGHKLMNPRTXYZ234579";
            this.symbols = AvailableSymbols.ToCharArray();
            //this.symbolsDictionary = new Dictionary<char, int>();
            for (var i = 0; i < this.symbols.Length; i++)
            {
                this.symbolsDictionary.Add(this.symbols[i], i);
            }
        }

        public string Generate(CouponCodeOptions opts)
        {
            var parts = new List<string>();

            // populate the bad words list with this delegate if it was set;
            //if (this.SetBadWordsList != null)
            //{
            //    this.BadWordsList = this.SetBadWordsList.Invoke();
            //}

            // remove empty strings from list
            //this.BadWordsList = this.BadWordsList.Except(new List<string> { string.Empty }).ToList();

            // if  plaintext wasn't set then override
            //if (string.IsNullOrEmpty(opts.Plaintext))
            //{
            //    // not yet implemented
            //    opts.Plaintext = this.GetRandomPlaintext(8);
            //}

            // generate parts and combine
            //do
            //{
            //    for (var i = 0; i < opts.Parts; i++)
            //    {
            //        var sb = new StringBuilder();
            //        for (var j = 0; j < opts.PartLength - 1; j++)
            //        {
            //            sb.Append(this.GetRandomSymbol());
            //        }

            //        var part = sb.ToString();
            //        sb.Append(this.CheckDigitAlg1(part, i + 1));
            //        parts.Add(sb.ToString());
            //    }
            //}
            //while (this.ContainsBadWord(string.Join(string.Empty, parts.ToArray())));
            for (var i = 0; i < opts.Parts; i++)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < opts.PartLength - 1; j++)
                {
                    sb.Append(this.GetRandomSymbol());
                }

                var part = sb.ToString();
                sb.Append(this.CheckDigitAlg1(part, i + 1));
                parts.Add(sb.ToString());
            }
            return string.Join("-", parts.ToArray());

            //throw new NotImplementedException();
        }
        private char CheckDigitAlg1(string data, long check)
        {
            // check's initial value is the part number (e.g. 3 or above)
            // loop through the data chars
            Array.ForEach(
                data.ToCharArray(),
                v =>
                {
                    var k = this.symbolsDictionary[v];
                    check = (check * 19) + k;
                });

            return this.symbols[check % (this.symbols.Length - 1)];
        }
        private char GetRandomSymbol()
        {
            var rng = new SecureRandom();
            var pos = rng.Next(this.symbols.Length);
            return this.symbols[pos];
        }


        public string Validate(string code, CouponCodeOptions opts)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new Exception("Provide a code to be validated");
            }

            // uppercase the code, replace OIZS with 0125
            code = new string(Array.FindAll(code.ToCharArray(), char.IsLetterOrDigit))
                .ToUpper()
                //.Replace("O", "0")
                //.Replace("I", "1")
                //.Replace("Z", "2")
                //.Replace("S", "5")
                ;

            // split in the different parts
            var parts = new List<string>();
            var tmp = code;
            while (tmp.Length > 0)
            {
                parts.Add(tmp.Substring(0, opts.PartLength));
                tmp = tmp.Substring(opts.PartLength);
            }

            // make sure we have been given the same number of parts as we are expecting
            if (parts.Count != opts.Parts)
            {
                return string.Empty;
            }

            // validate each part
            for (var i = 0; i < parts.Count; i++)
            {
                var part = parts[i];

                // check this part has 4 chars
                if (part.Length != opts.PartLength)
                {
                    return string.Empty;
                }

                // split out the data and the check
                var data = part.Substring(0, opts.PartLength - 1);
                var check = part.Substring(opts.PartLength - 1, 1);

                if (Convert.ToChar(check) != this.CheckDigitAlg1(data, i + 1))
                {
                    return string.Empty;
                }
            }

            // everything looked ok with this code
            return string.Join("-", parts.ToArray());
        }
    }
}
