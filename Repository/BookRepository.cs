using ConsoleLibrary.Entitys;

namespace ConsoleLibrary.Repository
{
    public class BookRepository: VirtualReository<Book>
    {
        ConsoleLibraryContext consoleLibraryContext;
        public Book Book {  get; set; }
        public BookRepository(Book book) 
        { 
            Book = book;        
        }

        public override List<Book> SelectAll()
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                var result = consoleLibraryContext.Books.ToList();
                return result;
            }
        }

        public override Book Select(int id)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                var result = consoleLibraryContext.Books.Where(book => book.Id == id).FirstOrDefault();
                return result;
            }
        }

        public override void Add(Book entity)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                consoleLibraryContext.Books.Add(entity);
                consoleLibraryContext.SaveChanges();
            }
        }

        public override void Update(Book entity)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                consoleLibraryContext.Books.Update(entity);
                consoleLibraryContext.SaveChanges();
            }
        }

        public override void Delete(Book entity)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                consoleLibraryContext.Remove(entity);
                consoleLibraryContext.SaveChanges();
            }
        }

        public override void UpdateById(int id, int newYear)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                var result = consoleLibraryContext.Books.Where(book => book.Id == id).FirstOrDefault();
                result.Year = newYear;
                consoleLibraryContext.SaveChanges();
            }
        }
    }
}
