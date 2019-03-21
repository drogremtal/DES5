using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace test
{
    public class General
    {
        int[] IP = new int[] { 57 ,  49, 41 , 33 , 25, 17 , 9 , 1,
                               59 ,  51, 43 , 35, 27, 19, 11, 3,
                               61 ,  53, 45 , 37, 29, 21, 13, 5,
                               63 ,  55, 47 , 39, 31, 23 , 15, 7,
                               56 ,  48, 40 , 32, 24, 16,  8, 0,
                               58 ,  50 , 42 , 34, 26, 18, 10, 2,
                               60 ,  52, 44 , 36, 28, 20, 12, 4,
                               62 ,  54, 46 , 38, 30, 22, 14, 6
        };

        #region S Блоки
        int[,] S1 = new int[,] {
            {14,  4, 13, 1,  2, 15, 11,  8,  3, 10,  6, 12,  5,  9,  0,  7},
            { 0, 15,  7, 4, 14,  2, 13,  1, 10,  6, 12, 11,  9,  5,  3,  8},
            { 4,  1, 14, 8, 13,  6,  2, 11, 15, 12,  9,  7,  3, 10,  5,  0},
            { 15, 12,  8, 2,  4,  9,  1,  7,  5, 11,  3, 14, 10,  0,  6, 13}
        };

        int[,] S2 = new int[,] {
          { 15,  1,  8, 14,  6, 11,  3,  4,  9,  7,  2, 13, 12, 0,  5, 10 },
          {  3, 13,  4,  7, 15,  2,  8, 14, 12,  0,  1, 10,  6, 9, 11,  5 },
          {  0, 14,  7, 11, 10,  4, 13,  1,  5,  8, 12,  6,  9, 3,  2, 15 },
          { 13,  8, 10,  1,  3, 15,  4,  2, 11,  6,  7, 12,  0, 5, 14,  9 }
        };

        int[,] S3 = new int[,] {
           { 10,  0,  9, 14,  6, 3, 15,  5,  1, 13, 12,  7, 11,  4,  2,  8 },
           { 13,  7,  0,  9,  3, 4,  6, 10,  2,  8,  5, 14, 12, 11, 15,  1 },
           { 13,  6,  4,  9,  8,15,  3,  0, 11,  1,  2, 12,  5, 10, 14,  7 },
           {  1, 10, 13,  0,  6, 9,  8,  7,  4, 15, 14,  3, 11,  5,  2, 12 }

        };

        int[,] S4 = new int[,] {
          {  7, 13, 14,  3,  0, 6 ,  9, 10,  1, 2, 8,  5, 11, 12,  4,15 },
          { 13,  8, 11,  5,  6, 15,  0,  3,  4, 7, 2, 12,  1, 10, 14, 9 },
          { 10,  6,  9,  0, 12, 11,  7, 13, 15, 1, 3, 14,  5,  2,  8, 4 },
          {  3,  15,  0,  6, 10, 1, 13,  8,  9, 4, 5, 11, 12,  7,  2,14 }
        };

        int[,] S5 = new int[,] {
            {  2, 12,  4,  1,  7,10, 11,  6,  8, 5,  3,15, 13, 0, 14, 9},
            { 14, 11,  2, 12,  4, 7, 13,  1,  5, 0, 15,10,  3, 9,  8, 6},
            {  4,  2,  1, 11, 10,13,  7,  8, 15, 9, 12, 5,  6, 3,  0,14},
            { 11,  8, 12,  7,  1,14,  2, 13,  6,15,  0, 9, 10, 4,  5, 3}
        };

        int[,] S6 = new int[,] {
           { 12, 1, 10,15,9, 2,  6, 8,  0, 13,  3, 4, 14, 7,  5,11 },
           { 10,15,  4, 2,7,12,  9, 5,  6,  1, 13,14,  0,11,  3, 8 },
           { 9,14, 15, 5,2, 8, 12, 3,  7,  0,  4,10,  1,13, 11, 6 },
           {  4, 3,  2,12,9, 5, 15,10, 11, 14,  1, 7,  6, 0,  8,13 }
        };

        int[,] S7 = new int[,] {
          {  4, 11,  2, 14,  15,  0,  8, 13,  3,12,  9, 7,  5, 10,  6, 1 },
          { 13,  0, 11,  7,   4,  9,  1, 10, 14, 3,  5,12,  2, 15,  8, 6 },
          {  1,  4, 11, 13,  12,  3,  7, 14, 10,15,  6, 8,  0,  5,  9, 2 },
          {  6, 11, 13,  8,   1,  4, 10,  7,  9, 5,  0,15, 14,  2,  3,12 }

        };

        int[,] S8 = new int[,] {
           { 13,  2,  8, 4,  6, 15, 11,  1, 10,  9,  3, 14,  5,  0, 12,  7 },
           {  1, 15, 13, 8, 10,  3,  7,  4, 12,  5,  6, 11,  0, 14,  9,  2 },
           {  7, 11,  4, 1,  9, 12, 14,  2,  0,  6, 10, 13, 15,  3,  5,  8 },
           {  2,  1, 14, 7,  4, 10,  8, 13, 15, 12,  9,  0,  3,  5,  6, 11 }
        };

        #endregion S Блоки

        public int[] PC = new int[] {
                         15,  6,  19,  20,
                         28, 11,  27,  16,
                          0, 14,  22,  25,
                          4, 17,  30,   9,
                          1,  7,  23,  13,
                         31, 26,   2,   8,
                         18, 12,  29,   5,
                         21, 10,   3,  24
        };

        readonly int[] IP_End = new int[] {
            39, 7, 47, 15, 55, 23, 63, 31,
            38, 6, 46, 14, 54, 22, 62, 30,
            37, 5, 45, 13, 53, 21, 61, 29,
            36, 4, 44, 12, 52, 20, 60, 28,
            35, 3, 43, 11, 51, 19, 59, 27,
            34, 2, 42, 10, 50, 18, 58, 26,
            33, 1, 41,  9, 49, 17, 57, 25,
            32, 0, 40,  8, 48, 16, 56, 24
        };



        #region Начальная перестановка IP
        public string SwapIP(string key)
        {
            string swap_key = "";
            for (int i = 0; i < IP.Length; i++)
            {
                swap_key += key[IP[i]];
            }
            return swap_key;
        }
        #endregion Начальная перестановка IP

        #region Деление на L и R
        public string[] SplitIP(string swap_key)
        {
            string[] CD = new string[2];
            string pattern = @".{32}";
            MatchCollection math = Regex.Matches(swap_key, pattern);

            CD[0] = math[0].Value.ToString();
            CD[1] = math[1].Value.ToString();
            return CD;
        }
        #endregion Деление на L и R


        public string GAMMA(string L,string R, string[] keys)
        {

            string res_out="";
                   
            var t = new List<string[]> { };

            var RT = new string[16];
            var LT = new string[16];

            for (int i = 0; i < 16; i++)
            {
                var temp = R;
                R = Function(L,R,keys[i]);
                R = XOR_RL(R, L);
                L = temp;
                RT[i] = R;
                LT[i] = L;
            }

            res_out = R + L;
            
            return EndSwap(res_out);
        }
        #region Конечная перестановка
        public string EndSwap(string s) {
            string res_out = "";
            for (int i = 0; i < 64; i++)
            {
                res_out += s[IP_End[i]];
            }
            return res_out;
        }
        #endregion Конечная перестановка

        public string Function(string L, string R, string key)
        {
            List<int[,]> S = new List<int[,]> { S1, S2, S3, S4, S5, S6, S7, S8 };
            int k;
            int l;
            R = XOR(R,key);
            string pattern = @".{6}";
            MatchCollection math = Regex.Matches(R, pattern);

            string res_out = "";
            string res_bin = "";
            var tut = new string[8];
            /// Гаммирование с S ключами

            for (int i = 0; i < 8; i++)
            {
                var Si = math[i].ToString();


                var temp_k = (Si[0].ToString() + Si[5].ToString());
                var temp_l =Si.Substring(1, 4);
                k = Convert.ToInt32(temp_k, 2);
                l = Convert.ToInt32(temp_l, 2);

                

                var temp = S[i];
                var res = temp[k,l];

                res_bin = Convert.ToString(res,2);
                if (res_bin.Length == 1)
                {
                    res_bin = "000" + res_bin;
                }
                else if (res_bin.Length == 2)
                {
                    res_bin = "00" + res_bin;
                }
                else if (res_bin.Length == 3)
                {
                    res_bin = "0" + res_bin;
                }
                res_out += res_bin;
                tut[i] = res_bin;
            }
           

            return SWAP_PC(res_out);
        }

        #region Перестановка с таблицей P
        public string SWAP_PC(string s)
        {
            string res_out="";
            for (int i = 0; i < 32; i++)
            {
                res_out += s[PC[i]];
            }
              return res_out;
        }

        #endregion Перестановка с таблицей P

        #region ГАммирование с ключом
        public string XOR(string R, string key)
        {
            R = E_table(R);
            string res_out = "";

            for (int i = 0; i < R.Length; i++)
            {
               res_out+= key[i] == R[i] ?  "0" :  "1";
            }

            return res_out;
        }
        #endregion ГАммирование с ключом

        #region Расширение Е
        /// <summary>
        /// Расширение Е
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string E_table(string s)
        {
            string[] E = new string[48];
            //int[] E_T = new int[] {
            //     32,    1,   2,    3,    4,   5 ,
            //      4,    5,   6,    7,    8,   9 ,
            //      8,    9,  10,   11,   12,  13 ,
            //     12,   13,  14,   15,   16,  17 ,
            //     16,   17,  18,   19,   20,  21 ,
            //     20,   21,  22,   23,   24,  25 ,
            //     24,   25,  26,   27,   28,  29 ,
            //     28,   29,  30,   31,   32,   1
            //};

            int[] E_T = new int[] {
                  0,  2,  3, 0, 0,  8,  9, 0, 0, 14, 15, 0,
                  0, 20, 21, 0, 0, 26, 27, 0, 0, 32, 33, 0,
                  0, 38, 39, 0, 0, 44, 45, 0  
            };



            #region
            for (int i = 0; i < s.Length; i++)
            {
               
                if (i == 0)
                {
                    E[1] = s[i].ToString();
                    E[47] = s[i].ToString();
                }
                else if (i == 3)
                {
                    E[4] = s[i].ToString();
                    E[6] = s[i].ToString();
                }
                else if (i == 4)
                {
                    E[5] = s[i].ToString();
                    E[7] = s[i].ToString();
                }
                else if (i == 7)
                {
                    E[10] = s[i].ToString();
                    E[12] = s[i].ToString();
                }
                else if (i == 8)
                {
                    E[11] = s[i].ToString();
                    E[13] = s[i].ToString();
                }
                else if (i == 11)
                {
                    E[16] = s[i].ToString();
                    E[18] = s[i].ToString();
                }
                else if (i == 12)
                {
                    E[17] = s[i].ToString();
                    E[19] = s[i].ToString();
                }
                else if (i == 15)
                {
                    E[22] = s[i].ToString();
                    E[24] = s[i].ToString();
                }
                else if (i == 16)
                {
                    E[23] = s[i].ToString();
                    E[25] = s[i].ToString();
                }
                else if (i == 19)
                {
                    E[28] = s[i].ToString();
                    E[30] = s[i].ToString();
                }
                else if (i == 20)
                {
                    E[29] = s[i].ToString();
                    E[31] = s[i].ToString();
                }
                else if (i == 23)
                {
                    E[34] = s[i].ToString();
                    E[36] = s[i].ToString();
                }
                else if (i == 24)
                {
                    E[35] = s[i].ToString();
                    E[37] = s[i].ToString();
                }
                else if (i == 27)
                {
                    E[40] = s[i].ToString();
                    E[42] = s[i].ToString();
                }
                else if (i == 28)
                {
                    E[41] = s[i].ToString();
                    E[43] = s[i].ToString();
                }
                else if (i == 31)
                {
                    E[0] = s[i].ToString();
                    E[46] = s[i].ToString();
                }
                else
                {
                    E[E_T[i]] = s[i].ToString();

                }
                #endregion


            }

            return string.Join("",E);
            
        }
        #endregion Расширение Е

        #region Гаммировани XOR
        public string XOR_RL(string R, string L)
        {
            string res_out = "";
            for (int i = 0; i < R.Length; i++)
            {
                res_out += L[i] == R[i] ? "0" : "1";
            }
          
            return res_out;
        }
        #endregion


    }
}
