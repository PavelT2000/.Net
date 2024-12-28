

using System;

namespace PersonSays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person misha=new Person("Миша", 31);
            misha.SayHello();
            Console.ReadKey();

        }
    }
}
