using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Practic.Sorts
{
    abstract class Sort
    {

        protected string file_path
        {
            get
            {
                return $"{this.GetType().Name}_Sort/{this.GetType().Name}_{data.Count.ToString()}.txt";
            }
        }

        protected List<int> data = new List<int>();
        public abstract double sort(List<int> _data);
        protected void save_to_file()
        {
            File.WriteAllLines(file_path, data.Select(i => i.ToString()).ToArray());
        }

    }
}
