using MedianMaintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance.Services
{
    class FileService
    {
        private const string FILENAME = @"I:/Median.txt"; 
        public static List<Key> ReadFile()
        {
            List<Key> keys = new List<Key>();

            string[] lines = System.IO.File.ReadAllLines(FILENAME);

            foreach(var item in lines)
            {
                if(int.TryParse(item, out int value))
                {
                    keys.Add(new Key(value));
                }
            }

            return keys;
        }
    }
}
