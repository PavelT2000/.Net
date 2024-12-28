using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину пароля");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine(GeneratePassword(length));
            Console.ReadKey();

        }
        static string GeneratePassword(int length)
        {
            Random random = new Random();
            string password = "";
            for (int i = 0; i < length; i++)
            {
                int val;
                val = random.Next(('9' - '0'+1) + ('Z' - 'A'+1) + ('z' - 'a'+1));
                if (val <= '9' - '0')
                {
                    val += '0';
                    password += ((char)val);
                }
                else if (val <= ('A' - 'Z'))
                {
                    val += 'A'- ('9' - '0'+1);
                    password += ((char)val);
                }
                else
                {
                    val += 'a'- ('9' - '0' + 1)- ('Z' - 'A' + 1);
                    password += ((char)val);
                }
            }
            return password;
        }
    }
}
