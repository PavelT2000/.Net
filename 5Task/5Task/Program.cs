using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] data = new int[4, 3];//0 строка сами числа
            //1 столбец a               //1 строка сколько нужно в итоге
            //2 столбец b               //2 строка скольок нужно в итерации
            //3 столбец c               //3 строка числа до которых нужно увелчить

            int a, b, c, n;
            string[] input = Console.ReadLine().Split(' ');
            data[0, 0] = int.Parse(input[1]);
            data[0, 1] = int.Parse(input[2]);
            data[0, 2] = int.Parse(input[3]);
            n = int.Parse(input[0]);
            string[] input2 = Console.ReadLine().Split(' ');
            int num = int.Parse(input2[0]);
            data[1, 0] = data[0, 0] - num % data[0, 0];
            data[3, 0] = num + data[1, 0];
            data[1, 1] = data[0, 1] - num % data[0, 1];
            data[3, 1] = num + data[1, 1];
            data[1, 2] = data[0, 2] - num % data[0, 2];
            data[3, 2] = num + data[1, 2];
            for (int i = 0; i < input2.Length; i++)
            {
                num = int.Parse(input2[i]);
                if(data[0, 0] - num % data[0, 0] < data[1,0])
                {
                    data[1, 0] = data[0, 0] - num % data[0, 0];
                    data[3, 0] = num + data[1, 0];
                }
                if (data[0, 1] - num % data[0,1] < data[1, 1])
                {
                    data[1, 1] = data[0, 1] - num % data[0, 1];
                    data[3, 1] = num + data[1, 1];
                }
                if (data[0, 2] - num % data[0, 2] < data[1, 2])
                {
                    data[1, 2] = data[0, 2] - num % data[0, 2];
                    data[3, 2] = num + data[1, 2];
                }
            }
            int sum=0;
            List<int> usednums=new List<int>();
            for (int i = 0; i < 3; i++)
            {
                if (!usednums.Contains(data[3,i]))
                {
                    sum += data[1, i];
                    usednums.Add(data[3, i]);
                }
            }

            Console.WriteLine(sum);
            Console.ReadKey();


        }
    }
}
