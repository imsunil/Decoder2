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
            String newStr = null;
           
           str = ReadString();
           //revStr = ReverseString(str);
           //revStr = ReverseStringByWords(str);
           //FindFirstRepeatedCharacter(str);
           //IsStringAnAnagram(str);
           IsStringAPalndrome(str);
            
            WriteString(newStr);
        }

        private static void IsStringAPalndrome(string str)
        {
            throw new NotImplementedException();
        }

        private static void IsStringAnAnagram(string str)
        {
            ///Guard Clause
            string str1 = str.ToUpper();
            string str2 = ReadString();
            
            //convert string to uppe
            str2 = str2.ToUpper();
            Console.WriteLine(str1 + " " + str2);
                if (str1.Length != str2.Length || str1.Length == 0)
            {
                Console.WriteLine("Strings are not Anangrams");
                return;
            }

            
           //create lookup table
            int[] A = new int[128];
            //for (int i = 0; i < 128; i++) { A[i] = 0; }
            for (int i = 0; i <str1.Length; i++)
            {
                A[str1[i]]++;
                A[str2[i]]--;
            }
                
            for(int i=0; i<128;i++)
                {
                    //Console.WriteLine(i + A[i]);  
                if(A[i] !=0) 
                  {
                  Console.WriteLine("Not Anagrams");
                  return;
                  }
                }
                    Console.WriteLine("ANAGRAMS");
                
            //next check 128 vs 256 bytes
            //all combinations of a string are anagrams.
            // check without changing case.

            
        }

        private static void FindFirstRepeatedCharacter(string str)
        {
           //guard clauses
            if (str.Length == 0 || str.Length == 1)
            {
                Console.WriteLine("String empty or single character");
                return;
            }

            //createlookup table & check values(for kicks)
            bool[] lookUpTable= new bool[128];
            for(int i = 0;i<str.Length;i++)
            {
                if(lookUpTable[str[i]])
                {
                Console.WriteLine("Repeats");
                }
                else
                {
                    
                    lookUpTable[str[i]]=true; 
                }

            }



            //try find repeated character
            //other questions are type of encoding 128 vs 256 and chinese characters, also questiosn about case sensitive characters


        }

        //private static void DisplayStringFromArray(string str)
        //{
        //    for (int i = str.Length - 1; i >= 0; i--)
        //    {
        //        Console.WriteLine(str[i]);
        //        //str[str.Length - 1] = "A";
        //    }
        //    Console.WriteLine(str);
        //    Console.ReadKey();
        //    //return output;
        //}

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
            for (int i = str.Length - 1; i >= 0; i--)
            {
                output += str[i];
            }
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
