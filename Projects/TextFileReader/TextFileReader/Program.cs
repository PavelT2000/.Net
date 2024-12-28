using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Input();
            Console.ReadKey();
        }
        static void Input()
        {
            string path;
            FileReader fr=new FileReader();
            Console.WriteLine("Введите путь к файлу");
            path = Console.ReadLine();
            try
            {
                Console.WriteLine(fr.ReadFile(path));
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());   
                Console.WriteLine("Попробуй ещё раз");
                Input();
            }
            

        }
    }
}
