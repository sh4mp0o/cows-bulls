using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cows_bulls
{
    [Serializable]
    public class Record:IComparer<Record>
    {
        public string name;
        public int score;
        public DateTime date;
        public Record(string name, int score)
        {
            this.date = DateTime.Now;
            this.name = name;
            this.score = score;
        }

        public int Compare(Record x, Record y)
        {
            if (x.score > y.score) return 1;
            else if (x.score < y.score) return -1;
            return 0;
        }
    }
}
