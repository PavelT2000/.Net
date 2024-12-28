using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSays
{
    internal class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }


        public void SayHello()
        {
            Console.WriteLine($"Привет меня зовут {name}, мне {age.ToString()} лет");
            
        }

    }
}
