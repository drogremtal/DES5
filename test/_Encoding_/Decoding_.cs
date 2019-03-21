using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Encoding_
{
    public class _Decoding
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="text">текст</param>
        /// <returns></returns>
        public string Decoding_(string key, string text)
        {
            string result = new KeyClass().SwapPC_1(key);

            var CD = new KeyClass().Split(result);
            var res = new KeyClass().Shift(CD);

            var res_c = res[0];
            var res_d = res[1];

            var keys = new KeyClass().SwapPC_2(res);

            Array.Reverse(keys);

            var IPTExt = new General().SwapIP(text);
            var R_L = new General().SplitIP(IPTExt);
            string L = R_L[0];
            string R = R_L[1];

            var res_texts = new General().GAMMA(L, R, keys);

            var resout = Convert.ToInt64(res_texts, 2);
            var tt = Convert.ToString(resout, 16);

           
            return res_texts;
        }
    }
}
