using ConsoleLibrary.Entitys;

namespace ConsoleLibrary.Repository
{
    public class BookRepository
    {
        ConsoleLibraryContext consoleLibraryContext;
        public Book Book {  get; set; }
        public BookRepository(Book book) 
        { 
            Book = book;        
            consoleLibraryContext = new ConsoleLibraryContext();
        }

        public List<Book> SelectAll()
        {
            var result = consoleLibraryContext.Books.ToList();
            return result;
        }

        public Book Select(int id)
        {
            var result = consoleLibraryContext.Books.Where(book => book.Id == id).FirstOrDefault();
            return result;
        }

        public void Add(Book book) 
        {
            consoleLibraryContext.Books.Add(book);     
            consoleLibraryContext.SaveChanges();
        }
        public void Update(Book book)
        {
            consoleLibraryContext.Books.Update(book);
            consoleLibraryContext.SaveChanges();
        }

        public void Delete(Book book)
        { 
            consoleLibraryContext.Remove(book);
            consoleLibraryContext.SaveChanges();
        }

        public void UpdateById(int id, int newYear)
        {
            var result = consoleLibraryContext.Books.Where(book => book.Id == id).FirstOrDefault();
            result.Year = newYear;
            consoleLibraryContext.SaveChanges();
        }


    }
}
