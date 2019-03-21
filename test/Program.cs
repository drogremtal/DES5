using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {


            //var open_res = new Encoding_._Encoding().Encoding_(key, open_text);
            //var enc_text = new Encoding_._Decoding().Decoding_(key, encod_text);


            string init_vector = "0000000100100011010001010110011110001001101010111100110111101111"; // 0123456789ABCDEF
            string key =         "0001001100110100010101110111100110011011101111001101111111110001";
  
            string in_text = "SomeTextSomeTextSomeTextSomeTextSomeTextSomeText";

            Console.WriteLine("Открытый текст :" + in_text);

            var bin = new DES().TextToBin(in_text);

            var enc_text = new DES().input(bin,key,init_vector);

            var res_out = new DES().BinToText(enc_text);
            Console.WriteLine("Зашифрованный текст");
            Console.WriteLine(res_out); 
            Console.WriteLine("----------------------------------------");


            var dec_text = new DES().Output(enc_text,key,init_vector);
            //var dec_bin = new DES().TextToBin(res_out);
            res_out = new DES().BinToText(dec_text);

            Console.WriteLine("Расшифрованный текст");
            Console.WriteLine(res_out);
            Console.WriteLine("----------------------------------------");
            Console.ReadKey();
            
            FileStream file = new FileStream("output.txt",FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(res_out);
            sw.Close();
        }
    }
}
