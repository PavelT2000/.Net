using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burley
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ans="";
            int a = int.Parse(Console.ReadLine());
            for (int i = 0; i < a; i++)
            {
                int b = int.Parse(Console.ReadLine());
                if (b >= 7)
                {
                    int numBits;
                    do
                    {
                        numBits = 0;
                        for (int j = 0; j < 32; j++)
                        {
                            if ((b >> j) % 2 == 1)
                            {
                                numBits++;
                            }
                        }
                        if (numBits < 3)
                        {
                            b--;
                        }

                    } while (numBits < 3);

                    for (int j = 0; j < 32; j++)
                    {
                        if ((b >> j) % 2 == 1 && numBits > 3)
                        {
                            b = b ^ (1 >> j);
                            numBits--;
                        }
                    }
                    
                    ans += b.ToString() + "\n";
                }
                else
                {
                    ans += "-1\n";
                }






            }
            Console.WriteLine(ans);
            




        }
    }
}
