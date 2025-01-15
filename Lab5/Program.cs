using System;

namespace Lab5
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
    
    public interface IDateCreated
    {
        DateTime DateCreated { get; set; }
    }

    public class Book : IEntity<int>, IDateCreated
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
    }

    public class Person : IEntity<int>, IDateCreated
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Book> ListOfBooks { get; set; }
    }
    
    public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
    {
        void Create(T entity);
        void Update(T entity);
        List<T> GetAll();
        T Get(TEntity id);
        void Delete(TEntity id);
    }
    
    public interface IBookRepository : IBaseRepository<Book, int>
    {
        string NameOfBookRepository { get; set; }
        int NumberOfBooks { get; set; }
        int KeyToRepository { get; set; }
    }
    
    public interface IPersonRepository : IBaseRepository<Person, int>
    {
        string NameOfPersonRepository { get; set; }
        int NumberOfPersons { get; set; }
        int KeyToRepository { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zadanie #1");
            Circle circle = new Circle();
            circle.CalulateArea();
            
            Square square = new Square();
            square.CalulateArea();
            
            Console.WriteLine("\nZadanie #2");
            Car car = new Car();
            car.CurrentSpeed = 20;
            car.Color = "Black";
            Console.WriteLine(car.CurrentSpeed);
            car.Start();
            car.Stop();
            
            Bike bike = new Bike();
            bike.Color = "White";
            bike.CurrentStateNormal = true;
            bike.BreakingNow = false;
            bike.IsBreakingNow();
            bike.Start();
            bike.BreakingNow = true;
            bike.IsBreakingNow();
            bike.Stop();
        }
    }
}