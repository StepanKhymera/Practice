using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Quick: Sort
    {


        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            quick_sort(0, data.Count - 1);

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }
        public double sort_new(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            quick_sort_new(0, data.Count - 1);

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }

        private void quick_sort_new(int start, int end)
        {
            int i = start, j = end, p = data[(i+j)/2], temp ;
            while (true)
            {
                while (data[i] < p) ++i;

                while (data[j] > p) --j;

                if (i < j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    ++i;
                    --j;
                }
                else break;

            }
            if (i < end)
            {
                quick_sort_new(j+1, end);
            }
            if (j > start)
            {
                quick_sort_new(start, j);
            }
        }

        private void quick_sort(int start, int end)
        {
            int i, j, size = data.Count - 1;
            i = start;
            j = end;
            int run = data[i], temp;
            while (i <= j)
            {
                while (data[i] < run) ++i;

                while (data[j] > run) --j;

                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    ++i;
                    --j;
                }
             
            }
            if (i < end)
            {
                quick_sort( i, end);
            }
            if (j > start)
            {
                quick_sort( start, j);
            }
        }
    }
}
