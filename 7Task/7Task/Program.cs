using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _7Task
{
    internal class Program
    {

        public struct Vector
        {
            int x;
            int y;

            public Vector(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public static Vector operator -(Vector a, Vector b)
            {
                Vector c = new Vector();
                c.x = a.x - b.x;
                c.y = a.y - b.y;
                return c;
            }
            public static bool isHappy(Vector vect1, Vector vect2, Vector vect3)
            {
                if ((vect2.x - vect1.x) * (vect3.y - vect1.y) - (vect2.y - vect1.y) * (vect3.x - vect1.x) != 0)
                {
                    return true;
                }
                return false;

            }

        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4 };
            IEnumerable<int> squares = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 2);

            foreach (var square in squares)
            {
                Console.WriteLine(square);
            }





            Console.ReadKey();



        }
        public struct Container
        {
            public int Value;
            public static void Nullify(Container container) => container.Value = 0;
        }

    }
}
