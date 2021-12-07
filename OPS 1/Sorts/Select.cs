using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Select : Sort
    {

        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            select_sort();

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }
        public void select_sort()
        {
            int temp, min, size = data.Count;

            for (int i = 0; i < size - 1; ++i)
            {
                min = data.IndexOf(data.GetRange(i + 1, size - i - 1).Min());
                if (data[min] < data[i])
                {
                    temp = data[min];
                    data[min] = data[i];
                    data[i] = temp;
                }
            }
        }
    }
}
