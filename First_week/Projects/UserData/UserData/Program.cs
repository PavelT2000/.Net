using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            int count;
            Console.WriteLine("Введите количество пользователей");
            count = int.Parse(Console.ReadLine());
            Console.Clear();
            for (int i = 1; i <= count; i++)
            {
                string login, password;
                Console.WriteLine($"Введите логин {i} пользователя");
                login = Console.ReadLine();
                Console.WriteLine($"Введите пароль {i} пользователя");
                password = Console.ReadLine();
                users.Add(new User(login, password));
                Console.Clear();

            }
            foreach (User user in users)
            {
                user.OutData();
            }
            Console.ReadKey();


        }
    }
}
