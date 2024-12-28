using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book
    {
        private string name;
        private string author;
        private int? releaseYear;
        public Book(string name)
        {
            this.name = name;
            author = "";
            releaseYear = null;
        }

        public Book(string name, string Author):this(name)
        {
            
            this.author = Author;
            this.releaseYear = null;
        }
        public Book(string name, string author, int? releaseYear) : this(name, author)
        {
            this.releaseYear = releaseYear;
        }

        public int? GetYearOfRelease()
        {
            return releaseYear;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название:{name,-22}, {(author == "" ? "Автор не известен" : "Автор:" + author),-22}," +
                $" {(releaseYear == null ? "Год выпуска не известен" : "Год выпуска:" + releaseYear),-22}");

        }
    }
}
