using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите набор чисел через пробел");
            string[] numsStr = Console.ReadLine().Split();
            long sum = 0;
            foreach (string str in numsStr)
            {
                sum += Convert.ToInt32(str);
            }
            Console.WriteLine($"Сумма:{sum}");
            Console.ReadKey();
        }

    }
}
