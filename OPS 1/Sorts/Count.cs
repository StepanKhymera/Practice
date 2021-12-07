using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Count: Sort
    {

        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            count_sort();

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }

        private void count_sort()
        {
            int max = data.Max(), min = data.Min(), size = data.Count;
             
            int abs_min = Math.Abs(min);
            int indx_size = Math.Abs(max) + abs_min + 1;
            List<int> indx = new List<int>(indx_size);
            for (int i = 0; i < indx_size; ++i) { indx.Add(0); }

            for (int i = 0; i < size; ++i)
            {
                ++indx[data[i] + abs_min];
            }

            for (int i = min, j = 0; i <= max; ++i)
            {
                while ((indx[i + abs_min]--) > 0)
                {
                    data[j++] = i;

                }
            }
        }
    }
}
