using MedianMaintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Key> list = Services.FileService.ReadFile();

            MediumElement mediumElement = new MediumElement(list);

            Console.WriteLine(mediumElement.GetMedian());
            Console.ReadKey();
        }
    }
}
