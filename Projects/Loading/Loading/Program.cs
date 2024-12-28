using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Начало");
            while(true) 
            await Task.Run(Loading);

            async Task Loading()
            {
                Console.Clear();
                Console.WriteLine("Загрузка.");
                Task.Delay(1000).Wait() ;
                Console.Clear();
                Console.WriteLine("Загрузка..");
                Task.Delay(1000).Wait();
                Console.Clear();
                Console.WriteLine("Загрузка...");
                Task.Delay(1000).Wait();
                Console.Clear();
                Console.WriteLine("Загрузка....");
                Task.Delay(1000).Wait();

            }
        }
    }
}
