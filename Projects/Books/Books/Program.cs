using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>();
            list.Add(new Book("Bible"));
            list.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
            list.Add(new Book("Pride and Prejudice", "Jane Austen", 1813));
            list.Add(new Book("Harry Potter", "J. K. Rowling", 1990));
            list.Add(new Book("1984", "George Orwell", 1949));
            Console.WriteLine("Books:");
            foreach (Book book in list)
            {
                book.ShowInfo();
            }
            list.Sort(delegate (Book b1, Book b2)
            {
                return b1.GetYearOfRelease() > b2.GetYearOfRelease() ? 1 : -1;
            }
            );
            Console.WriteLine("\n\nSorted books:");
            foreach (Book book in list)
            {
                book.ShowInfo();
            }
            Console.ReadKey();
        }
    }
}
