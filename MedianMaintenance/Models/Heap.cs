using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance.Models
{
    public class Heap
    {
        protected Key[] pq { get; set; }
        protected int N = 0;
        public Heap(int maxN)
        {
            pq = new Key[maxN + 1];
        }
        public bool IsEmpty()
        {
            return N == 0;
        }
        public int Size()
        {
            return N;
        }
        
        protected bool Less(int i,int j)
        {
            return pq[i].CompareTo(pq[j])<0;
        }

        protected bool Bigger(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }

        protected void Exch(int i,int j)
        {
            Key t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }

        public Key Peek()
        {
            return pq[1];
        }

        public void Print()
        {
            foreach(var item in pq)
            {
                if(item!=null)
                Console.WriteLine(item.ToString());
            }
        }
    }
}
