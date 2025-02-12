using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input.IndexOf('R') < input.IndexOf('M'))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");


            }
        }
    }
}
