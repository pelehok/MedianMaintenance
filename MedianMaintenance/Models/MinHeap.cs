using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance.Models
{
    class MinHeap : Heap
    {
        public MinHeap(int maxN) : base(maxN) { }

        public void Insert(Key key)
        {
            pq[++N] = key;
            Swim(N);
        }

        public void Swim(int k)
        {
            while (k > 1 && Bigger(k / 2, k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }

        public void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Bigger(j, j + 1)) j++;
                if (!Bigger(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }

        public Key DelMin()
        {
            Key min = pq[1];
            Exch(1, N--);
            pq[N + 1] = null;
            Sink(1);
            return min;
        }
    }
}
