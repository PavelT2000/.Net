using System;


namespace _1Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine().Split(' ');
            int A = int.Parse(input[0]);
            int B = int.Parse(input[2]);
            int C = int.Parse(input[4]);
            int D = int.Parse(input[6]);
            int sum = A;
            if (B<D)           
                sum += (D-B) * C;
                
            Console.WriteLine(sum);
           

        }
    }
}
