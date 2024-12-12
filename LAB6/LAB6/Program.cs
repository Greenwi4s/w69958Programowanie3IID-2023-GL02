using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntity<TEntity>
{
    TEntity Id { get; set; }
}

public interface ICreated
{
    DateTime CreatedDate { get; set; }
}

public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
{
    void Create(T entity);
    void Update(T entity);
    T Get(TEntity id);
    IEnumerable<T> GetAll();
    void Delete(TEntity id);
}

public interface IBookRepository : IBaseRepository<Book, int>
{
    List<Book> GetBooksByAuthor(string author); 
    List<Book> GetBooksByYear(int year); 
}


public interface IPersonRepository : IBaseRepository<Person, int>
{
    List<Book> GetBooksBorrowedByPerson(int personId); 
    void AddBookToPerson(int personId, Book book); 
}


public class Book : IEntity<int>, ICreated
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearOfPublication { get; set; }
    public DateTime CreatedDate { get; set; }
}


public class Person : IEntity<int>, ICreated
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>(); 
    public DateTime CreatedDate { get; set; }
}


public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new List<Book>();

    public void Create(Book book)
    {
        _books.Add(book);
    }

    public void Update(Book book)
    {
        var existingBook = Get(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.YearOfPublication = book.YearOfPublication;
            existingBook.CreatedDate = book.CreatedDate;
        }
    }

    public Book Get(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    public void Delete(int id)
    {
        var book = Get(id);
        if (book != null)
        {
            _books.Remove(book);
        }
    }


    public List<Book> GetBooksByAuthor(string author)
    {
        return _books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }


    public List<Book> GetBooksByYear(int year)
    {
        return _books.Where(b => b.YearOfPublication == year).ToList();
    }
}


public class PersonRepository : IPersonRepository
{
    private readonly List<Person> _people = new List<Person>();

    public void Create(Person person)
    {
        _people.Add(person);
    }

    public void Update(Person person)
    {
        var existingPerson = Get(person.Id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Age = person.Age;
            existingPerson.CreatedDate = person.CreatedDate;
        }
    }

    public Person Get(int id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Person> GetAll()
    {
        return _people;
    }

    public void Delete(int id)
    {
        var person = Get(id);
        if (person != null)
        {
            _people.Remove(person);
        }
    }


    public List<Book> GetBooksBorrowedByPerson(int personId)
    {
        var person = Get(personId);
        return person?.BorrowedBooks ?? new List<Book>();
    }

    public void AddBookToPerson(int personId, Book book)
    {
        var person = Get(personId);
        if (person != null && !person.BorrowedBooks.Contains(book))
        {
            person.BorrowedBooks.Add(book);
        }
    }
}

class Program
{
    static void Main()
    {

        IBookRepository bookRepository = new BookRepository();
        IPersonRepository personRepository = new PersonRepository();


        var book1 = new Book { Id = 1, Title = "Book One", Author = "Author A", YearOfPublication = 2020, CreatedDate = DateTime.Now };
        var book2 = new Book { Id = 2, Title = "Book Two", Author = "Author B", YearOfPublication = 2021, CreatedDate = DateTime.Now };
        var book3 = new Book { Id = 3, Title = "Book Three", Author = "Author A", YearOfPublication = 2020, CreatedDate = DateTime.Now };


        bookRepository.Create(book1);
        bookRepository.Create(book2);
        bookRepository.Create(book3);

        var person = new Person { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, CreatedDate = DateTime.Now };


        personRepository.Create(person);


        personRepository.AddBookToPerson(person.Id, book1);
        personRepository.AddBookToPerson(person.Id, book3);


        var borrowedBooks = personRepository.GetBooksBorrowedByPerson(person.Id);
        Console.WriteLine($"Books borrowed by {person.FirstName} {person.LastName}:");
        foreach (var book in borrowedBooks)
        {
            Console.WriteLine($"- {book.Title}");
        }

        var booksByAuthorA = bookRepository.GetBooksByAuthor("Author A");
        Console.WriteLine("\nBooks by Author A:");
        foreach (var book in booksByAuthorA)
        {
            Console.WriteLine($"- {book.Title}");
        }


        var booksFrom2020 = bookRepository.GetBooksByYear(2020);
        Console.WriteLine("\nBooks from the year 2020:");
        foreach (var book in booksFrom2020)
        {
            Console.WriteLine($"- {book.Title}");
        }
    }
}
