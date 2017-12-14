using System.Collections.Generic;

namespace Heap
{
    public class Heap
    {
        public Heap(List<int> heapArray)
        {
            HeapArray = heapArray;
        }

        public List<int> HeapArray { get; }

        public void Heapify()
        {
            for (var k = (HeapArray.Count - 1) / 2; k >= 0; k--)
                RepairOutside(k);
        }

        private void RepairOutside(int k0)
        {
            var size = HeapArray.Count;
            for (int k = k0; k < (size-1)/2; k++)
            {
                var k1 = 2 * k + 1;
                var k2 = k1 + 1;
                if (k2<size && HeapArray[k2] < HeapArray[k1])
                {
                    k1 = k2;
                    if (HeapArray[k] < HeapArray[k1])
                    {
                        break;
                    }
                }
            }
        }

        public List<int> TreeSort()
        {
            Heapify();
            var n0 = HeapArray.Count;
            for (int n = n0; n>0 ;)
            {
                var tmp = HeapArray[0];
                HeapArray[0] = HeapArray[n-1];
                HeapArray[n - 1] = tmp;
                n--;
                RepairOutside(0);
            }
            return HeapArray;
        }

    }
}