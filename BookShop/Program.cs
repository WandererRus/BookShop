using System.Collections;
using System.Collections.Generic;

namespace BookShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> list = new List<Book>();
            list.Add(new Book("Оно", "America", "Horror", "Stephen King", 700, 1995, 1000));
            list.Add(new Book("Оно2", "America", "Horror", "Stephen King", 700, 1995, 1000));
            list.Add(new Book("Оно3", "America", "Horror", "Stephen King", 700, 1995, 1000));
            Shop sh = new Shop("Читай-город", "ТЦ \"Рассвет\"", list);
            sh.GetAllBooks();
            Console.WriteLine();
            sh.AddABook(new Book("Оно4", "America", "Horror", "Stephen King", 700, 1995, 1000));
            sh.GetAllBooks();
            Console.WriteLine();
            sh.DeleteBookByName("Оно4");
            sh.GetAllBooks();
            Console.WriteLine();
            sh.DeleteBookByIndex(0);
            sh.GetAllBooks();
            Console.WriteLine();
        }
    }
    class Book : IEnumerable, IComparable
    {
        public string Name { get; set; }
        public string Publishing { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int NumberPages { get; set; }
        public int YearOfPublishing { get; set; }
        public int Price { get; set; }

        public Book (string name, string publishing, string genre, string author, int numberpages, int yearofpublishing, int price) 
        {
            Name = name;
            Publishing = publishing;
            Genre = genre;
            Author = author;
            NumberPages = numberpages;
            YearOfPublishing = yearofpublishing;
            Price = price;
        }
        public override string ToString()
        {
            return Name + " " + Publishing + " " + Genre + " " + Author + " " + NumberPages.ToString() + " " + 
                YearOfPublishing.ToString() + " " + Price.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Name).GetEnumerator();
        }

        public int CompareTo(object? obj)
        {
            return Name.CompareTo((string?)obj);
        }

        public int Compare(object? obj, object? obj2)
        {
            return ((Book)obj).Name.CompareTo((string?)obj2);
        }
    }

    class Shop
    {
        List<Book> Books;
        string Name { get; set; }
        string Address { get; set; }
        public Shop (string name, string address, List<Book> books)
        {
            Name = name;
            Address = address;
            Books = books;
        }
        public void GetAllBooks() 
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
            }
        }
        public void AddABook(Book book)
        {
            Books.Add(book);
        }
        public void DeleteBookByName(string name)
        {
            int index = -1;
            foreach (Book book in Books)
            {
                if (book.CompareTo(name) == 0) index = Books.IndexOf(book);
            }
            if (index >= 0) Books.RemoveAt(index);
        }
        public void DeleteBookByIndex(int index)
        {
            Books.RemoveAt(index);
        }
    }
}