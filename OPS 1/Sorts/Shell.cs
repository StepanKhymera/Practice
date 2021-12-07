using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Shell: Sort
    {
        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            shell_sort();
            
            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }

        private void shell_sort()
        {
            int temp, min, size = data.Count();
            for (int d = size / 2; d != 0; d /= 2)
            {
                for (int i = 0; i < d; i++)
                {
                    for (int j = i; j + d < size; j += d)
                    {

                        min = j + d;
                        for (int k = j + d; k < size; k += d)
                        {
                            if (data[min] > data[k])
                            {
                                min = k;
                            }
                        }

                        if (data[min] < data[j])
                        {
                            temp = data[min];
                            data[min] = data[j];
                            data[j] = temp;
                        }
                    }
                }
            }
        }
    }
}
