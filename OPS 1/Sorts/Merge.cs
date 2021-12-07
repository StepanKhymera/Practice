using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Merge: Sort
    {


        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            merge_sort(0, data.Count-1);

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }

        private void merge_sort(int left, int right)
        {
            if (left < right)
            {
                int middle = (right + left) / 2;
                merge_sort( left, middle);
                merge_sort( middle + 1, right);
                merge(left, middle, right);
            }
        }

        private void merge(int left, int middle, int right)
        {
            int size = data.Count;

            int n1 = middle - left + 1;
            int n2 = right - middle;

            List<int> L = new List<int>();
            List<int> R = new List<int>();


            for (int l = 0; l < n1; ++l)  L.Add(data[left + l]);
            for (int r = 0; r < n2; ++r)  R.Add(data[middle + 1 + r]);

            int i = 0, j = 0, k = left;
            while ((i < n1) && (j < n2))
            {
                if (L[i] <= R[j])
                {
                    data[k] = L[i];
                    ++i;
                }
                else
                {
                    data[k] = R[j];
                    ++j;
                }
                ++k;
            }

            while (i < n1)
            {
                data[k] = L[i];
                ++i;
                ++k;
            }

            while (j < n2)
            {
                data[k] = R[j];
                ++j;
                ++k;
            }
        
        }
    }
}
