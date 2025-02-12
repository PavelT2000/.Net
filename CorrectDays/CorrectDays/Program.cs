using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectDays
{
    internal class Program
    {
        public static string[] input2;
        static void Main(string[] args)
        {
            string[] input1=Console.ReadLine().Split(' ');
            int n, m;
            n = int.Parse(input1[0]);
            m = int.Parse(input1[1]);
            
            input2 = Console.ReadLine().Split(' ');
            List<int> list = new List<int>();
            for(int i = 2; i < input2.Length; i+=1)
            {
                list.Add(int.Parse(input2[i]));
            }
            list.Sort((b1,b2)=>compar(b1,b2));
            int days = 0;
            int corrects = 0;
            foreach (int i in list)
            {
                if (i >= int.Parse(input2[1]))
                {
                    corrects +=i-int.Parse(input2[1]);
                }
                else if (i <= int.Parse(input2[0]))
                {
                    corrects += Math.Abs(i - int.Parse(input2[0]));
                }
                days++;
                if (days == m)
                    break;
            }
            Console.WriteLine(corrects);




            Console.ReadKey();

            


        }
        public static int compar(int a, int b)
        {
            if (a >= int.Parse(input2[1]))
            {
                a -=int.Parse(input2[1]);
            }
            else if(a <= int.Parse(input2[0]))
            {
                a =Math.Abs(a- int.Parse(input2[0]));
            }
            else
            {
                a = 0;
            }
            if (b >= int.Parse(input2[1]))
            {
                b -= int.Parse(input2[1]);
            }
            else if (b <= int.Parse(input2[0]))
            {
                b = Math.Abs(b - int.Parse(input2[0]));
            }
            else
            {
                b = 0;
            }
            return a>=b ? 1:-1;
        }
    }
}
