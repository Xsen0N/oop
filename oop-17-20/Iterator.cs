using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class MedStudent
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            while (iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
    public interface IBookIterator
    {
    bool HasNext();
    Book Next();
    }

    public interface IBookNumerable
    {
     IBookIterator CreateNumerator();
    int Count { get; }
    Book this[int index] { get; }
    }
    public class Book
    {
        public string Name { get; set; }
    }

    public class Library : IBookNumerable
    {
        private Book[] books;
        public Library()
        {
            books = new Book[]
            {
            new Book{Name="Анатомия мышц"},
            new Book {Name="Будет больно"},
            new Book {Name="Атлас анатомии и физиологии человека"}
            };
        }
        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }
     public class LibraryNumerator : IBookIterator
     {
        IBookNumerable aggregate;
        int index = 0;
        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Book Next()
        {
            return aggregate[index++];
        }
      }
}
