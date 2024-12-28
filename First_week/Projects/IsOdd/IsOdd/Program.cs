using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            number =int.Parse(Console.ReadLine());
            Console.WriteLine( (number & 1) == 1 ? "odd" : "even");
            Console.ReadKey();
        }
    }
}
