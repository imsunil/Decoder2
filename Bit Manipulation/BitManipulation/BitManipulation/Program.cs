using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitManipulation
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read number and position
            int i;
            int pos;
            //GetInput(ref i,ref pos);
            GetInput(out i, out pos);

            //bool result = GetBit(i, pos);
           // bool result = SetBit(i, pos);
            bool result = ClearBit(i, pos);

            if (result)
                Console.WriteLine("Bit is Set");
            else
                Console.WriteLine("Bit is Not Set");
            Console.ReadKey();



        }

        private static bool ClearBit(int i, int pos)
        {
            //throw new NotImplementedException();
            int mask = 1 << pos;
            mask = ~mask;
            return ((i ^ (i & mask)) != 0);
        }

        private static bool SetBit(int i, int pos)
        {
            //throw new NotImplementedException();
            int mask = 1 << pos;
            //i |= mask;

            return ((i ^ (i | mask)) != 0); //OR with mask will sent the bit, then xor with self to get this is see if  the bit indeed got set

        }

        private static bool GetBit(int i, int pos)
        {
            //throw new NotImplementedException();
            int mask = 1 << pos;
            return ((i & mask) != 0);

        }

        private static void GetInput(out int i, out int pos)
        {
            Console.WriteLine("Please Enter Integer: ");
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Position: ");
            pos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Interget and Position is: " + i + " & " + pos);
            Console.ReadKey();
        }

       // //private static void GetInput(int ref i; int ref pos)
       // {
       //     //throw new NotImplementedException();
       //// Console.WriteLine("Please Enter input: :);
        
            
       // }



        //Learnings: position start at 0th power of 2, 1 power of 2 etc
        //operation with mask gives the result we need to check with 0 to say if bit was set or no

        
    }
}
