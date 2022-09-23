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
            Shop sh = new Shop(Properties.Resources.ShopName, "ТЦ \"Рассвет\"", list);
            sh.GetShopName();
            while (true)
            {
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "help": Command.HelpCommand();break;
                    case "addbook": sh.AddABook(Command.AddBookCommand()); break;
                    case "removebook": sh.DeleteBookByIndex(Command.RemoveBookCommand()); break;
                    case "removebookname": sh.DeleteBookByName(Command.RemoveBookCommandName()); break;
                    default: Console.WriteLine("Не удалось распознать команду. Наберите help для списка команд"); break;
                }
                    
            }
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
        public void GetShopName () 
        {
            Console.WriteLine("Добро пожаловать в {0} по адресу {1}", Name, Address);
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

    class Command 
    {
        public static void HelpCommand() 
        {
            Console.WriteLine("Используйте addbook для добавления книги, removebook для удаления книги по индексу, removebookname для удаления книги по имени,getbooks для списка книг:");
        }
        public static Book AddBookCommand()
        {
            Book book;
            Console.Write("Введите имя книги: ");
            string name = Console.ReadLine();
            Console.Write("Введите издательство книги: ");
            string publishing = Console.ReadLine();
            Console.Write("Введите жанр книги: ");
            string genre = Console.ReadLine();
            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();
            Console.Write("Введите количество страниц книги: ");
            int numberpage = Int32.Parse(Console.ReadLine());
            Console.Write("Введите год издания книги: ");
            int yearofpublishing = Int32.Parse(Console.ReadLine());
            Console.Write("Введите цену книги: ");
            int price = Int32.Parse(Console.ReadLine());
            book = new Book(name, publishing, genre, author, numberpage, yearofpublishing, price);
            return book;
        }
        public static int RemoveBookCommand()
        {
            Console.WriteLine("Укажите индекс удаляемой книги:");
            return Int32.Parse(Console.ReadLine());

        }
        public static string RemoveBookCommandName()
        {
            Console.WriteLine("Укажите имя удаляемой книги");
            return Console.ReadLine();
        }
        public static void GetAllBookCommand()
        {
            Console.WriteLine("Список книг в магазине:");
        }
    }
}