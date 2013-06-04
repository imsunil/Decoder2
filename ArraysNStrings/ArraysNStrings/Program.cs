using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraysNStrings
{
    class Program
    {
        public static void Main(string[] args)
        {
            String str = null;
            String revStr = null;
           
            str = ReadString();
            //revStr = ReverseString(str);

            DisplayStringFromArray(str);



           // WriteString(revStr);
        }

        private static void DisplayStringFromArray(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(str[i]);
                //str[str.Length - 1] = "A";
            }
            Console.WriteLine(str);
            Console.ReadKey();
            //return output;
        }

        private static string ReverseString(string str)
        {
            //int len = str.Length;
            ////Console.WriteLine(len.ToString());
            //int iStart = 0;
            //int iEnd = len - 1;

            ////char temp;
            ////char[] charArray = str.ToCharArray();
            ////Console.WriteLine(charArray);

            //while(iEnd > iStart)
            //{
            //     Char temp = str[iStart];
            //    Console.WriteLine(temp);
            //    str[iStart] =str[iEnd];
            //    str[iEnd] = temp;
            //    iEnd--;
            //    iStart++;
            //    Console.WriteLine(str.ToString());
            //}
            //return str.ToString();

            string output = ""; 
            //for (int i = str.Length - 1; i >= 0; i--)
            //    output += str[i];
                return output;
        }

        private static void WriteString(String str)
        {
            Console.WriteLine(str);
            Console.ReadKey();
        }

        private static string ReadString()
        {
            Console.WriteLine("Hi, please enter a string:");
            return Console.ReadLine();
            
        }
    }
}
