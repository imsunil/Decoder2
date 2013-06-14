using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Graph
{
    class ANode
    {
        private char m_ID;
        private int data;
        private bool m_visited;
        private List<AEdge> m_Edges = new List<AEdge>();
        
        public ANode(char ID, int dada)
        { 
        
        }

        public void AddEdge(char cEnd, int weight)
        {
        AEdge edge = new AEdge((m_ID,cEnd,weight);
        m_Edges.Add(edge)
        }

        public void DeleteEdge(char cEnd)
        {
        //AEdge edge = new AEdge((m_ID,cEnd,weight);
        
            for(int i=0; i<m_Edges.Count();i++)
            {
                AEdge edge = m_Edges(i);
                if (edge.getEnd == cEnd)
                {
                    m_Edges.erase(m_Edges.begin() + i);
                    break;
                }

            }
        }

    }
}
