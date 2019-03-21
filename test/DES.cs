using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test
{
    public class DES
    {
        public string XOR(string init_key, string text)
        {
            string res = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                res += init_key[i] == text[i] ? "0" : "1";                
            }
            return res;
        }


        public string input(string input_text, string key,string init_key) {

            string res_out = "";
            string pattern64 = @".{64}";
            MatchCollection matchCollection64 = Regex.Matches(input_text, pattern64);
            string temp_init = init_key;


            foreach (var item in matchCollection64)
            {
                
                string temp = XOR(temp_init,item.ToString());
                var open_res = new Encoding_._Encoding().Encoding_(key, temp);
                temp_init = open_res;
                res_out += open_res;
            }
            return res_out;
        }


        public string Output(string input_text, string key,string init_key) {

            string res_out = "";
            string pattern64 = @".{64}";
            var matchCollection64 = Regex.Matches(input_text, pattern64); ;
            var temp = init_key;
            var open_res = string.Empty;
            foreach (var item in matchCollection64)
            {
                var items = item.ToString();
               
               open_res = new Encoding_._Decoding().Decoding_(key, items);
               open_res = XOR(temp,open_res);
               Console.WriteLine(items);
               temp = items;              
               res_out += open_res;
            }
            return res_out;
        }


        public string TextToBin(string text) {

            string res_out = "";
                        
            int[] input_n = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                if (Convert.ToString(text[i], 2).Length == 6)
                {
                    res_out += "00" + Convert.ToString(text[i], 2);
                }
                else
                if (Convert.ToString(text[i], 2).Length == 7)
                {
                    res_out += "0" + Convert.ToString(text[i], 2);
                }
                else
                {
                    res_out += Convert.ToString(text[i], 2);
                }
                input_n[i] = Convert.ToInt32(Convert.ToString(text[i], 2), 2);
            }

            if (res_out.Length % 64 != 0)
            {
                while (res_out.Length % 64 != 0)
                {
                    res_out += "0";
                }
            }
            
            return res_out;
        }

        public string BinToText(string text) {
            string res_out = "";

            string pattern8 = @".{8}";
            MatchCollection matchCollection8 = Regex.Matches(text, pattern8);

            foreach (var item in matchCollection8)
            {
                var temp = Convert.ToInt64(item.ToString(), 2);
                res_out += Convert.ToChar(temp);
            }


            return res_out;
        }

        public string HexToBin(string text)
        {
            string res = ""; ;
            
            return res;
        }
    }
}
