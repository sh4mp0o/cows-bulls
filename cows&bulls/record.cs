using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cows_bulls
{
    [Serializable]
    public class Record:IComparable<Record>
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
        public int CompareTo(Record other)
        {
            if (this.score > other.score) return 1;
            else if (this.score < other.score) return -1;
            return 0;
        }
    }
}
