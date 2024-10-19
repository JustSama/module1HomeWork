using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Copies { get; set; }

    public Book(string title, string author, int copies)
    {
        Title = title;
        Author = author;
        Copies = copies;
    }
}

public class Reader
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Reader(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private List<Reader> readers = new List<Reader>();

    public void AddBook(Book book) => books.Add(book);
    public void RegisterReader(Reader reader) => readers.Add(reader);

    public void BorrowBook(int readerId, string bookTitle)
    {
        Book book = books.Find(b => b.Title == bookTitle);
        if (book != null && book.Copies > 0)
        {
            book.Copies--;
            Console.WriteLine($"{bookTitle} выдан читателю {readerId}.");
        }
        else
        {
            Console.WriteLine($"Книга {bookTitle} недоступна.");
        }
    }

    public void ReturnBook(string bookTitle)
    {
        Book book = books.Find(b => b.Title == bookTitle);
        if (book != null)
        {
            book.Copies++;
            Console.WriteLine($"{bookTitle} возвращена.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Library library = new Library();

        
        library.AddBook(new Book("Гарри Поттер", "Дж. Роулинг", 3));
        library.AddBook(new Book("1984", "Дж. Оруэлл", 2));

       
        library.RegisterReader(new Reader("Алексей", 1));
        library.RegisterReader(new Reader("Марина", 2));

        
        library.BorrowBook(1, "Гарри Поттер");
        library.ReturnBook("Гарри Поттер");
    }
}
