
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZereDividingCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a,b;
            Console.WriteLine("Введите делимое");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("Введите делитель");
            b=int.Parse(Console.ReadLine());
            try
            {
                if (b == 0)
                    throw new Exception("Такое тупое!!! На ноль делить нельзя");
                else
                    Console.WriteLine($"Ответ: {a / b}");
            }
            catch (Exception e) { Console.WriteLine(    e.ToString()); }

        }
    }
}
