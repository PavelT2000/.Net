using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, res;
            char op;
            Console.WriteLine("This calculator can do operations(/ * + -) with two numbers");
            Console.WriteLine("Enter first number");
            num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter operation(/ * + -)");
            op = Console.ReadLine()[0];
            switch (op)
            {
                case '/':
                    res = num1 / num2;
                    break;

                case '-':
                    res = num1 - num2;
                    break;

                case '*':
                    res = num1 * num2;
                    break;

                case '+':
                    res = num1 + num2;
                    break;



                default:
                    Console.WriteLine("Something went wrong");
                    return;

            }
            Console.WriteLine("Result is: " + res.ToString());
            Console.ReadKey();
        }
    }
}
