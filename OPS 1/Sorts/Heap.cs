using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Heap: Sort
    {

        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            heap_sort();

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }

        private void heap_sort()
        {
            heapify();
            int temp;
            for (int end = data.Count - 1; end >= 0; --end)
            {
                temp = data[0];
                data[0] = data[end];
                data[end] = temp;

                siftDown(0, end - 1);
            }
        }

        private void siftDown(int start, int end)
        {
            int root = start, child, swap, temp;
            while (2 * root + 1 <= end)
            {
                child = 2 * root + 1;
                swap = root;
                if(data[swap] < data[child])
                {
                    swap = child;
                }
                if( child +1 <= end && data[swap] < data[child+1])
                {
                    swap = child + 1;
                }
                if (swap == root)
                {
                    return;
                } else
                {
                    temp = data[root];
                    data[root] = data[swap];
                    data[swap] = temp;
                    root = swap;
                }
            }
        }

        private void heapify()
        {
            for( int start = (int)Math.Floor((data.Count - 2) / 2.0); start >= 0; --start)
            {
                siftDown(start, data.Count-1);
            }
        }
    }
}
