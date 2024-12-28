using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mas = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(MaxFromMas(mas));
            Console.ReadKey();
        }

        static int MaxFromMas(int[] mas)
        {
            int max = mas[0];
            foreach (int i in mas)
            {
                max = max < i ? i : max;
            }
            return max;
        }
    }
}
