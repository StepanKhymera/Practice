using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    class Bucket: Sort
    {

        public override double sort(List<int> _data)
        {
            data = _data;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan timeSpan;
            stopWatch.Start();

            data = bucket_sort(data, 7);

            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            save_to_file();
            return timeSpan.TotalMilliseconds;
        }

        private List<int> bucket_sort(List<int> input, int k)
        {
            
            int min = input.Min();
            double max = input.Max();
            List<List<int>> buckets = new List<List<int>>();
            for(int i = 0; i < k; ++i) { buckets.Add(new List<int>()); }
            for(int i = 0; i < input.Count; ++i)
            {
                buckets[(int)Math.Floor(k * (input[i] + -min) / (max + -min +1))].Add(input[i]);
            }
            for(int i = 0; i < k; ++i)
            {
                if (buckets[i].Count > 1 && buckets[i].First() != buckets[i].Last())
                    buckets[i] = bucket_sort(buckets[i], 4);
            }
            List<int> result = new List<int>();
            for(int i = 0; i < k; ++i)
            {
                result.AddRange(buckets[i]);
            }
            return result;
        }
    }
}
