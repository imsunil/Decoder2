using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Graph
{
    class AEdge
    {
        private char cStart;
        private char cEnd;
        private int weight;

        public int getWeight()
        {
            return this.weight;
        }

        public char getStart()
        {
            return this.cStart;
        }

        public char getEnd()
        {
            return this.cEnd;
        }
        
        public AEdge(char cStart, char cEnd, int weight)
        {
            this.cStart = cStart;
            this.cEnd = cEnd;
            this.weight = weight;


        }



    }
}
