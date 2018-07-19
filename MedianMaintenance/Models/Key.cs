using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance.Models
{
    public class Key
    {
        public int KeyValue { get; set; }

        public Key(int key)
        {
            this.KeyValue = key;
        }

        public int CompareTo(Key value)
        {
            return this.KeyValue.CompareTo(value.KeyValue);
        }

        public override string ToString()
        {
            return KeyValue.ToString();
        }

        public static bool operator >(Key a, Key b)
        {
            return a.KeyValue > b.KeyValue;
        }

        public static bool operator <(Key a, Key b)
        {
            return a.KeyValue < b.KeyValue;
        }
    }
}
