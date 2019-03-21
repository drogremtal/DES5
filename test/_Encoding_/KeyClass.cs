using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test
{
    public class KeyClass
    {
        public string SwapPC_1(string key)
        {
            int[] PC_1 = new int[] {56,48,40,32,24,16,8,0,57,49,41,33,25,17,9,1,58,50,52,34,26,18,10,2,59,51,42,35,
                           62,54,46,38,30,22,14,6,61,53,45,37,29,21,13,5,60,52,44,36,28,20,12,4,27,19,11,3 };

            string swap_key = "";

            for (int i = 0; i < PC_1.Length; i++)
            {
                swap_key += key[PC_1[i]];
            }
            return swap_key;
        }

        public string[] Split(string swap_key)
        {
            string[] CD = new string[2];
            string pattern = @".{28}";
            MatchCollection math = Regex.Matches(swap_key, pattern);

            CD[0] = math[0].Value.ToString();
            CD[1] = math[1].Value.ToString();
            return CD;
        }

        public List<string[]> Shift(string[] CD)
        {
            string[] res_c = new string[16];
            string[] res_d = new string[16];
            var res = new List<string[]>() { };
            string C = CD[0];
            string D = CD[1];


            for (int i = 0; i < 16; i++)
            {

                if (i == 0 || i == 1|| i == 8 || i == 15)
                {
                    C = new KeyClass().LeftShift(C);
                    D = new KeyClass().LeftShift(D);
                }
                else
                {
                    C = new KeyClass().LeftShift(C);
                    D = new KeyClass().LeftShift(D);
                    C = new KeyClass().LeftShift(C);
                    D = new KeyClass().LeftShift(D);
                }
                res_c[i] = C;
                res_d[i] = D;
            }



            res.Add(res_c);
            res.Add(res_d);

            return res;

        }

        public string LeftShift(string s)
        {
            string[] res = new string[28];

            for (int i = 0; i < s.Length; i++)
            {
                res[i] = s[i].ToString();
            }

            var temp = res[0];
            Array.Copy(res, 1, res, 0, res.Length - 1);
            res[res.Length - 1] = temp;

            s = String.Join("", res);


            return s;
        }

        public string[] SwapPC_2(List<string[]> s) {

            var res_C = s[0];
            var res_D = s[1];
            var res = new string[res_C.Length];

            for (int i = 0; i < res_C.Length; i++)
            {
                res[i] = res_C[i] + res_D[i];
            }

            string[] res_out = new string[res.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res_out[i] = SWAPPC2(res[i]);              
            }

            return res_out;
        }

        public string SWAPPC2(string s)
        {
            int[] PC_2 = new int[] {
                 13,   16,  10, 23,  0,  4,
                  2,   27,  14,  5, 20, 9,
                 22,   18,  11,  3, 25,  7,
                 15,    6,  26, 19, 12,  1,
                 40,   51,  30, 36, 46, 54,
                 29,   39,  50, 44, 32, 47,
                 43,   48,  38, 55, 33, 52,
                 45,   41,  49, 35, 28, 31
            };

            string res="";
            for (int i = 0; i < 48; i++)
            {
                res +=s[PC_2[i]];
            }

            return res;
        }
    }
}
