using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6Task
{
    internal class Program
    {
        public static List<int> list;
        public static int s;
        static void Main(string[] args)
        {
            int ans=0;
            string[] input1=Console.ReadLine().Split(' ');
            int n=int.Parse(input1[0]);
            s=int.Parse(input1[1]);
            string[] input2=Console.ReadLine().Split(' ');
            list=new List<int>();
            for(int i=0; i<n; i++)
            {
                list.Add(int.Parse(input2[i]));
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    ans += f(i, j);
                }
            }
            Console.WriteLine(ans);
            Console.ReadKey();

        }
        static int f(int x, int y)
        {
            int sum = 0;
            int count = 1;
            for(int i=x-1; i<=y-1;i++)
            {
                sum += list[i];
                if(sum>s)
                {
                    sum=list[i];
                    count++;
                }
            }
            return count;

        }

    }
}
